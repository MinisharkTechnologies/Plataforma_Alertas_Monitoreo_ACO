// Genera los manuales de la entrega final con el esquema del profesor:
//   Manual-de-instalacion.pdf, Manual-de-usuario.pdf, Manual de Programacion (documento).pdf
//   y el Manual del Programador (ayuda .chm).chm
// Uso:  node construir_manuales.mjs <carpeta de capturas> <carpeta de salida> [ruta de hhc.exe] [ruta de msedge.exe]
import fs from 'fs';
import path from 'path';
import { spawnSync } from 'child_process';
import { INSTALACION, USUARIO, PROGRAMACION, META } from './manuales.mjs';

const CAPTURAS = path.resolve(process.argv[2] || 'capturas');
const SALIDA = path.resolve(process.argv[3] || 'salida');
const HHC = process.argv[4] || 'C:/ortmp/hh/hhc.exe';
const EDGE = process.argv[5] || 'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe';
// Sube desde esta carpeta hasta encontrar la raíz del repo (la que contiene Codigo/).
let RAIZ = path.resolve(import.meta.dirname);
while (!fs.existsSync(path.join(RAIZ, 'Codigo', 'Services'))) {
  const padre = path.dirname(RAIZ);
  if (padre === RAIZ) throw new Error('No encuentro la raíz del repositorio (carpeta Codigo/) desde ' + import.meta.dirname);
  RAIZ = padre;
}
const CODIGO = path.join(RAIZ, 'Codigo');
fs.mkdirSync(SALIDA, { recursive: true });
const TEMP = path.join(process.env.TEMP || 'C:/Temp', 'manuales_openrin');
fs.rmSync(TEMP, { recursive: true, force: true });
fs.mkdirSync(TEMP, { recursive: true });

const esc = (s) => String(s).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');

// ------------------------------------------------------------ referencia de clases por espacio de nombres
function referenciaApi() {
  const recorrer = (d, acc = []) => { for (const e of fs.readdirSync(d, { withFileTypes: true })) { const p = path.join(d, e.name); if (e.isDirectory()) { if (!['bin', 'obj', 'Migrations'].includes(e.name)) recorrer(p, acc); } else if (e.name.endsWith('.cs') && !e.name.endsWith('.Designer.cs')) acc.push(p); } return acc; };
  const porNs = new Map();
  for (const proy of ['Negocio.UI', 'Negocio.BLL', 'Negocio.DomainModel', 'Negocio.DAL', 'Services']) {
    for (const f of recorrer(path.join(CODIGO, proy))) {
      const t = fs.readFileSync(f, 'utf8');
      const ns = (t.match(/^\s*namespace\s+([\w.]+)/m) || [, proy])[1];
      const re = /((?:\s*\/\/\/[^\n]*\n)+)\s*(?:\[[^\]]*\]\s*)*(public|internal)\s+(?:static\s+|sealed\s+|abstract\s+|partial\s+)*(class|record|enum|interface|struct)\s+(\w+)/g;
      let m;
      while ((m = re.exec(t))) {
        const sum = (m[1].match(/<summary>([\s\S]*?)<\/summary>/) || [, ''])[1].replace(/\s*\/\/\/\s?/g, ' ').replace(/<[^>]+>/g, '').replace(/\s+/g, ' ').trim();
        if (!porNs.has(ns)) porNs.set(ns, []);
        porNs.get(ns).push([m[3], m[4], sum || '—']);
      }
    }
  }
  return [...porNs.entries()].sort((a, b) => a[0].localeCompare(b[0])).map(([ns, filas]) => ({ ns, filas: filas.sort((a, b) => a[1].localeCompare(b[1])) }));
}

// ------------------------------------------------------------ numeración y HTML
function numerar(secciones, prefijo = '', nivel = 2) {
  secciones.forEach((s, i) => {
    s.num = prefijo ? `${prefijo}.${i + 1}` : String(i + 1);
    s.nivel = nivel;
    if (s.sub) numerar(s.sub, s.num, nivel + 1);
  });
}
function aplanar(secciones, acc = []) { for (const s of secciones) { acc.push(s); if (s.sub) aplanar(s.sub, acc); } return acc; }

function imagenSrc(img, modo) {
  const ruta = img.startsWith('..') ? path.resolve(RAIZ, 'Documentacion/Manuales', img) : path.join(CAPTURAS, img);
  if (modo === 'chm') return { archivo: path.basename(ruta), ruta };
  return { src: 'data:image/png;base64,' + fs.readFileSync(ruta).toString('base64') };
}
function bloqueHtml(b, modo, imgs) {
  if (b.p) return `<p>${esc(b.p)}</p>`;
  if (b.h) return `<h4>${esc(b.h)}</h4>`;
  if (b.ul) return `<ul>${b.ul.map((x) => `<li>${esc(x)}</li>`).join('')}</ul>`;
  if (b.ol) return `<ol>${b.ol.map((x) => `<li>${esc(x)}</li>`).join('')}</ol>`;
  if (b.nota) return `<div class="aviso"><b>Nota:</b> ${esc(b.nota)}</div>`;
  if (b.importante) return `<div class="aviso imp"><b>Importante:</b> ${esc(b.importante)}</div>`;
  if (b.cod) return `<pre>${esc(b.cod)}</pre>`;
  if (b.tabla) return `<table><thead><tr>${b.tabla.cab.map((c) => `<th>${esc(c)}</th>`).join('')}</tr></thead><tbody>${b.tabla.filas.map((f) => `<tr>${f.map((c) => `<td>${esc(c)}</td>`).join('')}</tr>`).join('')}</tbody></table>`;
  if (b.img) {
    const i = imagenSrc(b.img, modo);
    if (modo === 'chm') { imgs.add(i); return `<div class="fig"><img src="img/${i.archivo}"/><div class="cap">${esc(b.cap || '')}</div></div>`; }
    return `<div class="fig"><img src="${i.src}"/><div class="cap">${esc(b.cap || '')}</div></div>`;
  }
  return '';
}
const CSS = `@page{size:A4;margin:20mm 20mm 20mm 20mm}
body{font-family:Calibri,Carlito,'Segoe UI',Arial,sans-serif;font-size:10.5pt;color:#1f2933;line-height:1.45}
h1.tit{font-size:26pt;color:#1f4e79;text-align:center;margin:30px 0 4px;border-bottom:2px solid #2e75b6;padding-bottom:12px}
.sub{text-align:center;font-size:14pt;color:#3c4858;margin:14px 0 4px}.meta{text-align:center;font-size:9pt;color:#5a6b80;margin:3px 0}
h2.toc{font-size:16pt;color:#1f4e79;border-bottom:2px solid #2e75b6;padding-bottom:3px;margin:40px 0 10px}
.toc ul{list-style:none;padding-left:16px;margin:2px 0}.toc>ul{padding-left:6px}.toc li{margin:1px 0;font-size:9.5pt}.toc li:before{content:'\\2022\\00a0'}
h2.s{font-size:17pt;color:#1f4e79;margin:26px 0 8px;page-break-after:avoid}h3.s{font-size:13pt;color:#2e75b6;margin:18px 0 6px;page-break-after:avoid}
h4.s{font-size:11pt;color:#2e75b6;margin:12px 0 4px;page-break-after:avoid}h4{font-size:11pt;color:#1f4e79;margin:12px 0 4px}
p{margin:6px 0;text-align:left}ul,ol{margin:5px 0 8px 22px;padding-left:12px}li{margin:2px 0}
table{border-collapse:collapse;width:100%;margin:8px 0;font-size:9.5pt;page-break-inside:auto}th{background:#1f4e79;color:#fff;text-align:left;padding:5px 8px;border:1px solid #1f4e79}
td{border:1px solid #c9d3df;padding:4px 8px;vertical-align:top}tr{page-break-inside:avoid}tr:nth-child(even) td{background:#f6f9fc}
.aviso{background:#fff7d6;border-left:4px solid #e0b100;padding:6px 10px;margin:8px 0;font-size:10pt;page-break-inside:avoid}.imp{background:#fde9e7;border-left-color:#c0392b}
pre{background:#f1f4f8;border:1px solid #d3dbe5;padding:7px 10px;font-family:Consolas,'Courier New',monospace;font-size:8.8pt;white-space:pre-wrap;word-break:break-word;page-break-inside:avoid}
.fig{text-align:left;margin:8px 0;page-break-inside:avoid}.fig img{max-width:100%;max-height:420px;border:1px solid #c9d3df}.cap{font-size:9pt;color:#3c4858;margin-top:2px}
code{font-family:Consolas,monospace}`;

function cuerpoSecciones(secs, modo, imgs, api) {
  let h = '';
  for (const s of secs) {
    h += `<h${s.nivel} class="s" id="s${s.num.replace(/\./g, '_')}">${s.num}. ${esc(s.titulo)}</h${s.nivel}>`;
    (s.bloques || []).forEach((b) => { h += bloqueHtml(b, modo, imgs); });
    if (s.api) {
      for (const g of api) {
        h += `<h3 class="s">Espacio de nombres ${esc(g.ns)}</h3>` + bloqueHtml({ tabla: { cab: ['Tipo', 'Nombre', 'Descripción'], filas: g.filas } }, modo, imgs);
      }
    }
    if (s.sub) h += cuerpoSecciones(s.sub, modo, imgs, api);
  }
  return h;
}
function tocHtml(secs) {
  return `<ul>${secs.map((s) => `<li>${s.num}. ${esc(s.titulo)}${s.sub ? tocHtml(s.sub) : ''}</li>`).join('')}</ul>`;
}

// La referencia de clases agrega un apartado por espacio de nombres (también en el índice, como en el manual de referencia)
function prepararDocumento(doc, api) {
  const d = JSON.parse(JSON.stringify(doc));
  numerar(d.secciones);
  for (const s of d.secciones) if (s.api) { s.sub = api.map((g) => ({ titulo: `Espacio de nombres ${g.ns}`, _soloIndice: true })); numerar(d.secciones); }
  return d;
}

async function pdf(doc, archivo, api) {
  const d = prepararDocumento(doc, api);
  // en el cuerpo, los apartados por espacio de nombres ya se imprimen dentro de s.api
  const cuerpoSecs = d.secciones.map((s) => (s.api ? { ...s, sub: undefined } : s));
  const imgs = new Set();
  const cuerpo = cuerpoSecciones(cuerpoSecs, 'pdf', imgs, api);
  const html = `<!DOCTYPE html><html lang="es"><head><meta charset="utf-8"><title>${esc(d.titulo)} - OpenRIN</title><style>${CSS}</style></head><body>
<h1 class="tit">${esc(d.titulo)}</h1><div class="sub">${esc(d.subtitulo)}</div><div class="sub" style="font-size:11pt">${esc(d.detalle)}</div>
<div class="meta">${esc(META.materia)}</div><div class="meta">Autor: ${esc(META.autor)} - Legajo ${esc(META.legajo)}</div><div class="meta">Versión ${esc(META.version)}</div>
<h2 class="toc">Tabla de contenido</h2><div class="toc">${tocHtml(d.secciones)}</div>${cuerpo}</body></html>`;
  const base = archivo.replace(/\W+/g, '_');
  const f = path.join(TEMP, base + '.html');
  fs.writeFileSync(f, html, 'utf8');
  const salida = path.join(SALIDA, archivo);
  const r = spawnSync(EDGE, ['--headless=new', '--disable-gpu', '--no-pdf-header-footer', '--no-first-run', '--user-data-dir=' + path.join(TEMP, 'edge_perfil'), `--print-to-pdf=${salida}`, 'file:///' + f.replace(/\\/g, '/')], { encoding: 'utf8', timeout: 180000 });
  for (let i = 0; i < 60 && !fs.existsSync(salida); i++) Atomics.wait(new Int32Array(new SharedArrayBuffer(4)), 0, 0, 1000);
  await new Promise((r2) => setTimeout(r2, 1500));
  if (!fs.existsSync(salida)) throw new Error('Edge no generó el PDF: status=' + r.status + ' ' + r.stderr + r.stdout);
  console.log('PDF:', archivo, Math.round(fs.statSync(salida).size / 1024) + ' KB');
}

// ------------------------------------------------------------ CHM del programador
function chm(doc, api, nombreArchivo) {
  const d = prepararDocumento(doc, api);
  const dir = path.join(TEMP, 'chm');
  fs.mkdirSync(path.join(dir, 'img'), { recursive: true });
  const temas = [];
  const imgs = new Set();
  const CSSCHM = CSS.replace(/@page\{[^}]*\}/, '') + 'body{margin:0}.cab{background:#1f4e79;color:#fff;padding:10px 20px}.cont{padding:10px 24px 28px;max-width:960px}';
  const pagina = (titulo, cuerpo) => `<!DOCTYPE html><html lang="es"><head><meta charset="utf-8"><title>${esc(titulo)}</title><style>${CSSCHM}</style></head><body><div class="cab"><b>OpenRIN</b> &mdash; Manual de programaci&oacute;n</div><div class="cont">${cuerpo}</div></body></html>`;
  let n = 0;
  for (const s of d.secciones) {
    const archivo = `t${String(++n).padStart(2, '0')}.htm`;
    const secCuerpo = s.api ? { ...s, sub: undefined } : s;
    const cuerpo = cuerpoSecciones([{ ...secCuerpo, nivel: 2 }].map((x) => ({ ...x, sub: x.sub ? x.sub.map((y) => ({ ...y, nivel: 3 })) : undefined })), 'chm', imgs, api);
    temas.push({ archivo, titulo: `${s.num}. ${s.titulo}`, html: pagina(s.titulo, cuerpo) });
  }
  const nombre = 'OpenRIN-ManualProgramador';
  for (const t of temas) fs.writeFileSync(path.join(dir, t.archivo), t.html, 'utf8');
  for (const i of imgs) fs.copyFileSync(i.ruta, path.join(dir, 'img', i.archivo));
  const ansi = (s) => Buffer.from(s, 'latin1');
  const li = (t) => `<LI><OBJECT type="text/sitemap"><param name="Name" value="${t.titulo}"><param name="Local" value="${t.archivo}"></OBJECT>`;
  const cab = '<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN"><HTML><HEAD><meta name="GENERATOR" content="OpenRIN"></HEAD><BODY>';
  fs.writeFileSync(path.join(dir, nombre + '.hhp'), ansi(`[OPTIONS]\r\nCompatibility=1.1 or later\r\nCompiled file=${nombre}.chm\r\nContents file=${nombre}.hhc\r\nDefault topic=${temas[0].archivo}\r\nDisplay compile progress=No\r\nFull-text search=Yes\r\nIndex file=${nombre}.hhk\r\nLanguage=0x2C0A Español (Argentina)\r\nTitle=OpenRIN - Manual del programador\r\n\r\n[FILES]\r\n${temas.map((t) => t.archivo).join('\r\n')}\r\n${[...imgs].map((i) => 'img\\' + i.archivo).join('\r\n')}\r\n`));
  fs.writeFileSync(path.join(dir, nombre + '.hhc'), ansi(`${cab}<OBJECT type="text/site properties"><param name="Window Styles" value="0x800025"></OBJECT><UL>${temas.map(li).join('\r\n')}</UL></BODY></HTML>`));
  fs.writeFileSync(path.join(dir, nombre + '.hhk'), ansi(`${cab}<UL>${[...temas].sort((a, b) => a.titulo.localeCompare(b.titulo, 'es')).map(li).join('\r\n')}</UL></BODY></HTML>`));
  spawnSync(HHC, [path.join(dir, nombre + '.hhp')], { encoding: 'utf8' });
  const generado = path.join(dir, nombre + '.chm');
  if (!fs.existsSync(generado)) throw new Error('hhc no generó el CHM');
  fs.copyFileSync(generado, path.join(SALIDA, nombreArchivo));
  console.log('CHM:', nombreArchivo, Math.round(fs.statSync(generado).size / 1024) + ' KB');
}

const api = referenciaApi();
console.log('Referencia de clases:', api.reduce((a, g) => a + g.filas.length, 0), 'tipos en', api.length, 'espacios de nombres');
await pdf(INSTALACION, 'Manual-de-instalacion.pdf', api);
await pdf(USUARIO, 'Manual-de-usuario.pdf', api);
await pdf(PROGRAMACION, 'Manual de Programacion (documento).pdf', api);
chm(PROGRAMACION, api, 'Manual del Programador (ayuda .chm).chm');
