// Genera la documentación de OpenRIN a partir de contenido.mjs:
//   - Ayuda en línea (OpenRIN-Ayuda.chm) y Manual del programador (OpenRIN-ManualProgramador.chm), con hhc.exe (HTML Help Workshop)
//   - Manuales en Word con el formato de la Carpeta Modelo 2020.1: Manual de Instalación, Guía del Usuario,
//     Guía de Operación y Guía de Mantenimiento
// Uso:  node construir_documentacion.mjs <carpeta de capturas> <carpeta de salida> [ruta de hhc.exe]
import fs from 'fs';
import path from 'path';
import { spawnSync } from 'child_process';
import { createRequire } from 'module';
import { USUARIO, INSTALACION, OPERACION, MANTENIMIENTO, PROGRAMADOR } from './contenido.mjs';

const require = createRequire(import.meta.url);
const docx = require('docx');
const {
  Document, Packer, Paragraph, TextRun, Table, TableRow, TableCell, WidthType, ShadingType, BorderStyle, AlignmentType, HeadingLevel,
  Header, Footer, PageNumber, ImageRun, TableOfContents, LevelFormat, PageBreak, VerticalAlign,
} = docx;

const CAPTURAS = path.resolve(process.argv[2] || 'capturas');
const SALIDA = path.resolve(process.argv[3] || 'salida');
const HHC = process.argv[4] || 'C:/ortmp/hh/hhc.exe';
const CODIGO = path.resolve(import.meta.dirname, '../../Codigo');
fs.mkdirSync(SALIDA, { recursive: true });

const FECHA = '30/10/2026';
const esc = (s) => String(s).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
const pngSize = (f) => { const b = fs.readFileSync(f); return [b.readUInt32BE(16), b.readUInt32BE(20)]; };

// ============================================================ HTML (CHM)
const CSS = `body{font-family:Segoe UI,Arial,sans-serif;font-size:10pt;color:#1c2b3a;margin:0;background:#fff}
.cab{background:#2a62b0;color:#fff;padding:12px 22px}.cab small{opacity:.85}
.cont{padding:14px 26px 30px;max-width:980px}h1{font-size:18pt;color:#1e4278;margin:4px 0 12px}h2{font-size:13pt;color:#2a62b0;margin:20px 0 6px}
p{line-height:1.5;margin:7px 0}li{line-height:1.5;margin:3px 0}img{max-width:100%;border:1px solid #c5d3e6;margin:8px 0}
.cap{font-size:8.5pt;color:#5a6b80;margin:-4px 0 12px;font-style:italic}.nota{background:#fff6e5;border-left:4px solid #c9922e;padding:8px 12px;margin:10px 0}
table{border-collapse:collapse;margin:10px 0;width:100%}th{background:#2a62b0;color:#fff;text-align:left;padding:5px 8px}td{border:1px solid #c5d3e6;padding:5px 8px;vertical-align:top}
pre{background:#f3f6fa;border:1px solid #c5d3e6;padding:8px 10px;overflow:auto;font-family:Consolas,monospace;font-size:9pt}a{color:#2a62b0}`;

function bloqueHtml(b, imgDir) {
  if (b.p) return `<p>${esc(b.p)}</p>`;
  if (b.h) return `<h2>${esc(b.h)}</h2>`;
  if (b.ul) return `<ul>${b.ul.map((x) => `<li>${esc(x)}</li>`).join('')}</ul>`;
  if (b.ol) return `<ol>${b.ol.map((x) => `<li>${esc(x)}</li>`).join('')}</ol>`;
  if (b.nota) return `<div class="nota"><b>Nota.</b> ${esc(b.nota)}</div>`;
  if (b.cod) return `<pre>${esc(b.cod)}</pre>`;
  if (b.img) return `<img src="${imgDir}/${b.img}" alt="${esc(b.cap || '')}"/>${b.cap ? `<div class="cap">${esc(b.cap)}</div>` : ''}`;
  if (b.tabla) return `<table><tr>${b.tabla.cab.map((c) => `<th>${esc(c)}</th>`).join('')}</tr>${b.tabla.filas.map((f) => `<tr>${f.map((c) => `<td>${esc(c)}</td>`).join('')}</tr>`).join('')}</table>`;
  return '';
}
const paginaHtml = (titulo, cuerpo, producto) => `<!DOCTYPE html><html lang="es"><head><meta charset="utf-8"><title>${esc(titulo)}</title><style>${CSS}</style></head><body>
<div class="cab"><b>OpenRIN</b> &mdash; ${esc(producto)}<br><small>Plataforma integral de alertas y monitoreo para pacientes anticoagulados</small></div><div class="cont"><h1>${esc(titulo)}</h1>${cuerpo}</div></body></html>`;

// Compila un CHM. temas: [{archivo, titulo, html, grupo?}]
function compilarChm({ nombre, titulo, producto, temas, imagenes, salida }) {
  const dir = path.join(process.env.TEMP || 'C:/Temp', 'chm_' + nombre);
  fs.rmSync(dir, { recursive: true, force: true });
  fs.mkdirSync(path.join(dir, 'img'), { recursive: true });
  for (const i of imagenes) fs.copyFileSync(path.join(CAPTURAS, i), path.join(dir, 'img', i));
  for (const t of temas) fs.writeFileSync(path.join(dir, t.archivo), paginaHtml(t.titulo, t.html, producto), 'utf8');
  const ansi = (s) => Buffer.from(s, 'latin1');
  const hhp = `[OPTIONS]\r\nCompatibility=1.1 or later\r\nCompiled file=${nombre}.chm\r\nContents file=${nombre}.hhc\r\nDefault topic=${temas[0].archivo}\r\nDisplay compile progress=No\r\nFull-text search=Yes\r\nIndex file=${nombre}.hhk\r\nLanguage=0x2C0A Español (Argentina)\r\nTitle=${titulo}\r\n\r\n[FILES]\r\n${temas.map((t) => t.archivo).join('\r\n')}\r\n${imagenes.map((i) => 'img\\' + i).join('\r\n')}\r\n`;
  const li = (t) => `<LI><OBJECT type="text/sitemap"><param name="Name" value="${t.titulo}"><param name="Local" value="${t.archivo}"></OBJECT>`;
  const cab = '<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN"><HTML><HEAD><meta name="GENERATOR" content="OpenRIN"></HEAD><BODY>';
  fs.writeFileSync(path.join(dir, nombre + '.hhp'), ansi(hhp));
  fs.writeFileSync(path.join(dir, nombre + '.hhc'), ansi(`${cab}<OBJECT type="text/site properties"><param name="Window Styles" value="0x800025"></OBJECT><UL>${temas.map(li).join('\r\n')}</UL></BODY></HTML>`));
  fs.writeFileSync(path.join(dir, nombre + '.hhk'), ansi(`${cab}<UL>${[...temas].sort((a, b) => a.titulo.localeCompare(b.titulo, 'es')).map(li).join('\r\n')}</UL></BODY></HTML>`));
  const r = spawnSync(HHC, [path.join(dir, nombre + '.hhp')], { encoding: 'utf8' });
  const chm = path.join(dir, nombre + '.chm');
  if (!fs.existsSync(chm)) throw new Error('hhc no generó el CHM: ' + r.stdout + r.stderr);
  fs.copyFileSync(chm, salida);
  console.log('CHM:', salida, Math.round(fs.statSync(salida).size / 1024) + ' KB');
}

// ---- Ayuda en línea (D02)
{
  const temas = USUARIO.map((s) => ({ archivo: s.id + '.htm', titulo: s.titulo, html: s.bloques.map((b) => bloqueHtml(b, 'img')).join('\n') }));
  const imgs = new Set(); USUARIO.forEach((s) => s.bloques.forEach((b) => b.img && imgs.add(b.img)));
  compilarChm({ nombre: 'OpenRIN-Ayuda', titulo: 'OpenRIN - Ayuda en linea', producto: 'Ayuda en línea', temas, imagenes: [...imgs], salida: path.join(SALIDA, 'OpenRIN-Ayuda.chm') });
}

// ---- Referencia de clases (a partir de los comentarios XML del código)
function referenciaApi() {
  const proyectos = [['Negocio.UI', 'Presentación'], ['Negocio.BLL', 'Lógica de negocio'], ['Negocio.DomainModel', 'Dominio'], ['Negocio.DAL', 'Acceso a datos de negocio'], ['Services', 'Servicios técnicos']];
  const out = [];
  const recorrer = (d, acc = []) => { for (const e of fs.readdirSync(d, { withFileTypes: true })) { const p = path.join(d, e.name); if (e.isDirectory()) { if (!['bin', 'obj', 'Migrations'].includes(e.name)) recorrer(p, acc); } else if (e.name.endsWith('.cs') && !e.name.endsWith('.Designer.cs')) acc.push(p); } return acc; };
  for (const [proy, etiqueta] of proyectos) {
    const filas = [];
    for (const f of recorrer(path.join(CODIGO, proy))) {
      const t = fs.readFileSync(f, 'utf8');
      const re = /((?:\s*\/\/\/[^\n]*\n)+)\s*(?:\[[^\]]*\]\s*)*(public|internal)\s+(?:static\s+|sealed\s+|abstract\s+|partial\s+)*(class|record|enum|interface|struct)\s+(\w+)/g;
      let m;
      while ((m = re.exec(t))) {
        const sum = (m[1].match(/<summary>([\s\S]*?)<\/summary>/) || [, ''])[1].replace(/\s*\/\/\/\s?/g, ' ').replace(/<[^>]+>/g, '').replace(/\s+/g, ' ').trim();
        filas.push([m[4], m[3], sum || '—']);
      }
    }
    filas.sort((a, b) => a[0].localeCompare(b[0]));
    out.push({ proyecto: proy, etiqueta, filas });
  }
  return out;
}

// ---- Manual del programador (CHM)
{
  const temas = PROGRAMADOR.map((s) => ({ archivo: s.id + '.htm', titulo: s.titulo, html: s.bloques.map((b) => bloqueHtml(b, 'img')).join('\n') }));
  const api = referenciaApi();
  let total = 0;
  for (const a of api) {
    total += a.filas.length;
    temas.push({ archivo: 'api_' + a.proyecto.replace(/\W/g, '_') + '.htm', titulo: 'Referencia: ' + a.proyecto, html: `<p>Clases, registros, enumeraciones e interfaces del proyecto <b>${esc(a.proyecto)}</b> (${esc(a.etiqueta)}), con la descripción de su comentario XML.</p>` + bloqueHtml({ tabla: { cab: ['Tipo', 'Clase', 'Descripción'], filas: a.filas.map((f) => [f[1], f[0], f[2]]) } }, 'img') });
  }
  console.log('Referencia de clases:', total, 'tipos');
  compilarChm({ nombre: 'OpenRIN-ManualProgramador', titulo: 'OpenRIN - Manual del programador', producto: 'Manual del programador', temas, imagenes: [], salida: path.join(SALIDA, 'OpenRIN-ManualProgramador.chm') });
}

// ============================================================ WORD (formato Carpeta Modelo 2020.1)
const CM = (cm) => Math.round(cm * 567);
const ARIAL = 'Arial';
const borde = { style: BorderStyle.SINGLE, size: 4, color: '999999' };
const bordes = { top: borde, bottom: borde, left: borde, right: borde };
const ANCHO = 11906 - CM(3) - CM(2); // ancho útil de A4 con márgenes izq 3 cm y der 2 cm

const run = (t, o = {}) => new TextRun({ text: t, font: ARIAL, size: o.size || 24, bold: o.bold, italics: o.italics, color: o.color });
const parrafo = (t, o = {}) => new Paragraph({ spacing: { after: 120, line: 276 }, alignment: o.alineacion, children: [run(t, o)] });

function celda(t, w, o = {}) {
  return new TableCell({ width: { size: w, type: WidthType.DXA }, borders: bordes, margins: { top: 50, bottom: 50, left: 90, right: 90 }, verticalAlign: VerticalAlign.TOP,
    shading: o.fondo ? { fill: o.fondo, type: ShadingType.CLEAR, color: 'auto' } : undefined,
    children: String(t).split('\n').map((l) => new Paragraph({ children: [run(l, { size: o.size || 20, bold: o.bold })] })) });
}
function tablaDocx(cab, filas) {
  const n = cab.length; const w = Array.from({ length: n }, () => Math.floor(ANCHO / n));
  if (n === 2) { w[0] = Math.floor(ANCHO * 0.34); w[1] = ANCHO - w[0]; }
  if (n === 3) { w[0] = Math.floor(ANCHO * 0.22); w[1] = Math.floor(ANCHO * 0.30); w[2] = ANCHO - w[0] - w[1]; }
  return new Table({ width: { size: ANCHO, type: WidthType.DXA }, columnWidths: w, rows: [
    new TableRow({ tableHeader: true, children: cab.map((c, i) => celda(c, w[i], { fondo: 'D9E2F3', bold: true })) }),
    ...filas.map((f) => new TableRow({ cantSplit: true, children: f.map((c, i) => celda(c, w[i])) })),
  ] });
}
function bloqueDocx(b, listas) {
  if (b.p) return [parrafo(b.p, { alineacion: AlignmentType.JUSTIFIED })];
  if (b.h) return [new Paragraph({ heading: HeadingLevel.HEADING_3, keepNext: true, spacing: { before: 200, after: 100 }, children: [run(b.h, { size: 26, bold: true })] })];
  if (b.ul) return b.ul.map((x) => new Paragraph({ numbering: { reference: 'vinetas', level: 0 }, spacing: { after: 60 }, children: [run(x)] }));
  if (b.ol) { const ref = 'num' + (listas.n++); listas.refs.push(ref); return b.ol.map((x) => new Paragraph({ numbering: { reference: ref, level: 0 }, spacing: { after: 60 }, children: [run(x)] })); }
  if (b.nota) return [new Paragraph({ spacing: { before: 100, after: 140 }, border: { left: { style: BorderStyle.SINGLE, size: 18, color: 'C9922E', space: 8 } }, indent: { left: 200 }, shading: { type: ShadingType.CLEAR, fill: 'FFF6E5', color: 'auto' }, children: [run('Nota. ', { bold: true }), run(b.nota)] })];
  if (b.cod) return b.cod.split('\n').map((l) => new Paragraph({ shading: { type: ShadingType.CLEAR, fill: 'F3F6FA', color: 'auto' }, children: [new TextRun({ text: l || ' ', font: 'Consolas', size: 19 })] }));
  if (b.tabla) return [tablaDocx(b.tabla.cab, b.tabla.filas), parrafo('')];
  if (b.img) {
    const f = path.join(CAPTURAS, b.img); const [w, h] = pngSize(f);
    const ancho = Math.min(w, 600); const alto = Math.round(h * ancho / w);
    const maxAlto = 430; const k = alto > maxAlto ? maxAlto / alto : 1;
    return [
      new Paragraph({ alignment: AlignmentType.CENTER, keepNext: true, spacing: { before: 100, after: 40 }, children: [new ImageRun({ type: 'png', data: fs.readFileSync(f), transformation: { width: Math.round(ancho * k), height: Math.round(alto * k) } })] }),
      ...(b.cap ? [new Paragraph({ alignment: AlignmentType.CENTER, spacing: { after: 160 }, children: [run(b.cap, { size: 20, italics: true, color: '555555' })] })] : []),
    ];
  }
  return [];
}

function documentoWord({ archivo, titulo, seccion, secciones, historial }) {
  const listas = { n: 0, refs: [] };
  const cuerpo = [];
  secciones.forEach((s, i) => {
    cuerpo.push(new Paragraph({ heading: HeadingLevel.HEADING_2, pageBreakBefore: i > 0, spacing: { before: 120, after: 140 }, children: [run(`${i + 1}. ${s.titulo}`, { size: 28, bold: true })] }));
    s.bloques.forEach((b) => cuerpo.push(...bloqueDocx(b, listas)));
  });

  const dato = (k, v, w1, w2) => [celda(k, w1, { fondo: 'E8EEF8', bold: true, size: 20 }), celda(v, w2, { size: 20 })];
  const wA = [1300, 3100, 1300, ANCHO - 5700];
  const caratula = [
    new Paragraph({ alignment: AlignmentType.CENTER, spacing: { before: 0, after: 60 }, children: [run('UNIVERSIDAD ABIERTA INTERAMERICANA', { size: 28, bold: true })] }),
    new Paragraph({ alignment: AlignmentType.CENTER, spacing: { after: 200 }, children: [run('Facultad de Tecnología Informática', { size: 26, bold: true })] }),
    new Table({ width: { size: ANCHO, type: WidthType.DXA }, columnWidths: wA, rows: [
      new TableRow({ children: [...dato('Materia', 'Prácticas Profesionalizantes III', wA[0], wA[1]), ...dato('Docente', 'Weingand, Gastón Matías', wA[2], wA[3])] }),
      new TableRow({ children: [...dato('Alumno', 'Muñiz Cortés, Carlos Santiago', wA[0], wA[1]), ...dato('Legajo', 'B00000955-VCO', wA[2], wA[3])] }),
      new TableRow({ children: [...dato('Localización', 'Colegio Leonardo Da Vinci, Curso Noche', wA[0], wA[1]), ...dato('Comisión', 'VCO-21-23 · Turno Noche', wA[2], wA[3])] }),
      new TableRow({ children: [...dato('Año de cursada', '2026', wA[0], wA[1]), ...dato('Versión', `1.0 · ${FECHA}`, wA[2], wA[3])] }),
    ] }),
    new Paragraph({ spacing: { before: 1500, after: 120 }, alignment: AlignmentType.CENTER, children: [run('OpenRIN', { size: 72, bold: true, color: '1E4278' })] }),
    new Paragraph({ alignment: AlignmentType.CENTER, spacing: { after: 600 }, children: [run('Plataforma Integral de Alertas y Monitoreo para Pacientes Anticoagulados', { size: 26 })] }),
    new Paragraph({ alignment: AlignmentType.CENTER, spacing: { after: 100 }, children: [run(titulo, { size: 40, bold: true })] }),
    new Paragraph({ alignment: AlignmentType.CENTER, children: [run(seccion, { size: 26 })] }),
    new Paragraph({ children: [new PageBreak()] }),
  ];
  const indice = [
    new Paragraph({ heading: HeadingLevel.HEADING_1, spacing: { after: 160 }, children: [run('Historial de revisión', { size: 28, bold: true })] }),
    parrafo('El historial expone los cambios que ha tenido el documento a través del tiempo.'),
    tablaDocx(['Fecha', 'Versión', 'Autor', 'Descripción'], historial),
    new Paragraph({ heading: HeadingLevel.HEADING_1, spacing: { before: 400, after: 160 }, children: [run('Índice', { size: 28, bold: true })] }),
    new TableOfContents('Índice', { hyperlink: true, headingStyleRange: '1-3' }),
    new Paragraph({ children: [new PageBreak()] }),
  ];
  const encabezado = new Header({ children: [
    new Paragraph({ spacing: { after: 0 }, children: [run('UNIVERSIDAD ABIERTA INTERAMERICANA — Facultad de Tecnología Informática', { size: 16, bold: true, color: '1F3864' })] }),
    new Paragraph({ spacing: { after: 0 }, children: [run('Prácticas Profesionalizantes III — Weingand, Gastón Matías — Colegio Leonardo Da Vinci, Curso Noche — Comisión VCO-21-23 — Turno Noche — Año 2026', { size: 15 })] }),
    new Paragraph({ spacing: { after: 0 }, border: { bottom: { style: BorderStyle.SINGLE, size: 6, color: '1F3864', space: 2 } }, children: [run(`${titulo} — OpenRIN — Muñiz Cortés, Carlos Santiago — Legajo B00000955-VCO — Sección: ${seccion}`, { size: 15 })] }),
  ] });
  const pie = new Footer({ children: [new Paragraph({ alignment: AlignmentType.CENTER, children: [new TextRun({ children: [PageNumber.CURRENT], font: ARIAL, size: 22 })] })] });
  const numeraciones = [{ reference: 'vinetas', levels: [{ level: 0, format: LevelFormat.BULLET, text: '•', alignment: AlignmentType.LEFT, style: { paragraph: { indent: { left: 720, hanging: 360 } } } }] },
    ...Array.from({ length: listas.n }, (_, i) => ({ reference: 'num' + i, levels: [{ level: 0, format: LevelFormat.DECIMAL, text: '%1.', alignment: AlignmentType.LEFT, style: { paragraph: { indent: { left: 720, hanging: 360 } } } }] }))];
  const doc = new Document({
    features: { updateFields: true }, creator: 'Muñiz Cortés, Carlos Santiago', title: `${titulo} - OpenRIN`,
    styles: { default: { document: { run: { font: ARIAL, size: 24 } } }, paragraphStyles: [
      { id: 'Heading1', name: 'Heading 1', basedOn: 'Normal', next: 'Normal', quickFormat: true, run: { size: 28, bold: true, font: ARIAL }, paragraph: { spacing: { before: 240, after: 160 }, outlineLevel: 0 } },
      { id: 'Heading2', name: 'Heading 2', basedOn: 'Normal', next: 'Normal', quickFormat: true, run: { size: 28, bold: true, font: ARIAL }, paragraph: { spacing: { before: 240, after: 160 }, outlineLevel: 1 } },
      { id: 'Heading3', name: 'Heading 3', basedOn: 'Normal', next: 'Normal', quickFormat: true, run: { size: 26, bold: true, font: ARIAL }, paragraph: { spacing: { before: 200, after: 100 }, outlineLevel: 2 } },
    ] },
    numbering: { config: numeraciones },
    sections: [{
      properties: { titlePage: true, page: { size: { width: 11906, height: 16838 }, margin: { left: CM(3), right: CM(2), top: CM(4), bottom: CM(1.5), header: CM(1), footer: CM(0.6) } } },
      headers: { default: encabezado, first: new Header({ children: [new Paragraph({ children: [] })] }) },
      footers: { default: pie, first: new Footer({ children: [new Paragraph({ children: [] })] }) },
      children: [...caratula, ...indice, ...cuerpo],
    }],
  });
  return Packer.toBuffer(doc).then((buf) => { fs.writeFileSync(path.join(SALIDA, archivo), buf); console.log('Word:', archivo, Math.round(buf.length / 1024) + ' KB'); });
}

const autor = 'Muñiz, Carlos';
const hist = (desc) => [[FECHA, 'v1.0', autor, desc]];
await documentoWord({ archivo: 'D01 - Manual de Instalacion.docx', titulo: 'Manual de Instalación', seccion: 'D01. Manual de Instalación', secciones: INSTALACION, historial: hist('Versión inicial: instalador OpenRIN-Setup.exe, requisitos, pasos y solución de problemas.') });
await documentoWord({ archivo: 'D03a - Guia del Usuario.docx', titulo: 'Guía del Usuario', seccion: 'D03. Material de apoyo — Guía del Usuario', secciones: USUARIO, historial: hist('Versión inicial: guía por módulo con capturas de la aplicación.') });
await documentoWord({ archivo: 'D03b - Guia de Operacion.docx', titulo: 'Guía de Operación', seccion: 'D03. Material de apoyo — Guía de Operación', secciones: OPERACION, historial: hist('Versión inicial: rutinas, respaldos, integridad e incidentes.') });
await documentoWord({ archivo: 'D03c - Guia de Mantenimiento.docx', titulo: 'Guía de Mantenimiento', seccion: 'D03. Material de apoyo — Guía de Mantenimiento', secciones: MANTENIMIENTO, historial: hist('Versión inicial: componentes, configuración, actualización y diagnóstico.') });
console.log('Documentación generada en', SALIDA);
