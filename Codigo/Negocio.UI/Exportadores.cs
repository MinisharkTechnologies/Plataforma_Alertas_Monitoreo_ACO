using System.IO.Compression;
using System.Text;
using Negocio.BLL;
using Negocio.DomainModel;

namespace Negocio.UI
{
    /// <summary>
    /// Renderizadores de exportación de la capa de presentación (REQ-FUNC-013): generan el
    /// archivo real del historial clínico unificado en PDF (escritor mínimo sin dependencias)
    /// o en Excel (.xlsx OOXML generado como paquete ZIP).
    /// </summary>
    public static class Exportadores
    {
        /// <summary>Carpeta de exportaciones del usuario (Documentos\OpenRIN\Exportaciones).</summary>
        public static string CarpetaExportacion()
        {
            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string carpeta = Path.Combine(documentos, "OpenRIN", "Exportaciones");
            Directory.CreateDirectory(carpeta);
            return carpeta;
        }

        /// <summary>Escribe el historial exportado con el nombre sugerido por la BLL. Devuelve la ruta absoluta.</summary>
        public static string EscribirHistorial(ExportacionHistorial exportacion, string paciente, string formato)
        {
            string ruta = Path.Combine(CarpetaExportacion(), exportacion.NombreArchivoSugerido);
            if (string.Equals(formato, "Excel", StringComparison.OrdinalIgnoreCase))
            {
                EscribirXlsx(ruta, paciente, exportacion.Items);
            }
            else
            {
                EscribirPdf(ruta, paciente, exportacion.Items);
            }
            return ruta;
        }

        // ------------------------------------------------------------------ PDF

        private static readonly Encoding Latin1 = Encoding.Latin1;

        /// <summary>
        /// Escribe un PDF mínimo válido (PDF 1.4, una página, Helvetica) con el historial.
        /// Sin dependencias externas: objetos, stream de contenido y tabla xref calculadas a mano.
        /// </summary>
        private static void EscribirPdf(string ruta, string paciente, List<ItemHistorial> items)
        {
            var lineas = new List<string>
            {
                "OpenRIN - Historial clinico unificado",
                $"Paciente: {paciente}",
                $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                new string('-', 100)
            };
            foreach (ItemHistorial item in items)
            {
                string cuerpo = $"{item.Fecha:dd/MM/yyyy} | {item.Tipo} | {item.Descripcion}";
                lineas.AddRange(Envolver(cuerpo, 105));
            }

            using var ms = new MemoryStream();
            var offsets = new List<long>();

            void Escribir(string texto)
            {
                byte[] bytes = Latin1.GetBytes(texto);
                ms.Write(bytes, 0, bytes.Length);
            }

            Escribir("%PDF-1.4\n");

            offsets.Add(ms.Length);
            Escribir("1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n");

            offsets.Add(ms.Length);
            Escribir("2 0 obj\n<< /Type /Pages /Kids [3 0 R] /Count 1 >>\nendobj\n");

            offsets.Add(ms.Length);
            Escribir("3 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] " +
                     "/Resources << /Font << /F1 4 0 R >> >> /Contents 5 0 R >>\nendobj\n");

            offsets.Add(ms.Length);
            Escribir("4 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>\nendobj\n");

            var contenido = new StringBuilder();
            contenido.Append("BT\n/F1 10 Tf\n14 TL\n40 750 Td\n");
            foreach (string linea in lineas.Take(52))
            {
                contenido.Append('(').Append(EscaparPdf(linea)).Append(") Tj\nT*\n");
            }
            if (lineas.Count > 52)
            {
                contenido.Append("( ... ) Tj\n");
            }
            contenido.Append("ET\n");
            byte[] contenidoBytes = Latin1.GetBytes(contenido.ToString());

            offsets.Add(ms.Length);
            Escribir($"5 0 obj\n<< /Length {contenidoBytes.Length} >>\nstream\n");
            ms.Write(contenidoBytes, 0, contenidoBytes.Length);
            Escribir("\nendstream\nendobj\n");

            long inicioXref = ms.Length;
            var xref = new StringBuilder();
            xref.Append("xref\n0 6\n0000000000 65535 f \n");
            foreach (long offset in offsets)
            {
                xref.Append(offset.ToString("0000000000")).Append(" 00000 n \n");
            }
            xref.Append("trailer\n<< /Size 6 /Root 1 0 R >>\nstartxref\n").Append(inicioXref).Append("\n%%EOF\n");
            Escribir(xref.ToString());

            File.WriteAllBytes(ruta, ms.ToArray());
        }

        private static string EscaparPdf(string texto)
        {
            var sb = new StringBuilder(texto.Length);
            foreach (char c in texto)
            {
                if (c == '(' || c == ')' || c == '\\')
                {
                    sb.Append('\\').Append(c);
                }
                else if (c >= ' ' && c <= 'ÿ')
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append('?');
                }
            }
            return sb.ToString();
        }

        private static IEnumerable<string> Envolver(string texto, int ancho)
        {
            string resto = texto;
            while (resto.Length > ancho)
            {
                int corte = resto.LastIndexOf(' ', ancho);
                if (corte <= 0)
                {
                    corte = ancho;
                }
                yield return resto[..corte];
                resto = "    " + resto[(corte + 1 > resto.Length ? resto.Length : corte + 1)..].TrimStart();
            }
            yield return resto;
        }

        // ------------------------------------------------------------------ XLSX

        /// <summary>
        /// Escribe un archivo .xlsx mínimo válido (paquete OOXML compuesto por ZIP + XML) con el
        /// historial en una hoja llamada "Historial", usando cadenas en línea.
        /// </summary>
        private static void EscribirXlsx(string ruta, string paciente, List<ItemHistorial> items)
        {
            using FileStream fs = File.Create(ruta);
            using var zip = new ZipArchive(fs, ZipArchiveMode.Create);

            Agregar(zip, "[Content_Types].xml",
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Types xmlns=\"http://schemas.openxmlformats.org/package/2006/content-types\">" +
                "<Default Extension=\"rels\" ContentType=\"application/vnd.openxmlformats-package.relationships+xml\"/>" +
                "<Default Extension=\"xml\" ContentType=\"application/xml\"/>" +
                "<Override PartName=\"/xl/workbook.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml\"/>" +
                "<Override PartName=\"/xl/worksheets/sheet1.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml\"/>" +
                "</Types>");

            Agregar(zip, "_rels/.rels",
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
                "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument\" Target=\"xl/workbook.xml\"/>" +
                "</Relationships>");

            Agregar(zip, "xl/workbook.xml",
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<workbook xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" " +
                "xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">" +
                "<sheets><sheet name=\"Historial\" sheetId=\"1\" r:id=\"rId1\"/></sheets></workbook>");

            Agregar(zip, "xl/_rels/workbook.xml.rels",
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
                "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet\" Target=\"worksheets/sheet1.xml\"/>" +
                "</Relationships>");

            var hoja = new StringBuilder();
            hoja.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            hoja.Append("<worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\"><sheetData>");
            int fila = 1;
            AgregarFila(hoja, fila++, new[] { "Paciente", paciente, "Generado", DateTime.Now.ToString("dd/MM/yyyy HH:mm") });
            AgregarFila(hoja, fila++, new[] { "Fecha", "Tipo", "Descripcion" });
            foreach (ItemHistorial item in items)
            {
                AgregarFila(hoja, fila++, new[] { item.Fecha.ToString("dd/MM/yyyy"), item.Tipo, item.Descripcion });
            }
            hoja.Append("</sheetData></worksheet>");
            Agregar(zip, "xl/worksheets/sheet1.xml", hoja.ToString());
        }

        private static void AgregarFila(StringBuilder hoja, int numeroFila, string[] celdas)
        {
            hoja.Append("<row r=\"").Append(numeroFila).Append("\">");
            string[] columnas = { "A", "B", "C", "D" };
            for (int i = 0; i < celdas.Length && i < columnas.Length; i++)
            {
                hoja.Append("<c r=\"").Append(columnas[i]).Append(numeroFila).Append("\" t=\"inlineStr\"><is><t>")
                    .Append(EscaparXml(celdas[i]))
                    .Append("</t></is></c>");
            }
            hoja.Append("</row>");
        }

        private static string EscaparXml(string texto)
            => texto.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");

        private static void Agregar(ZipArchive zip, string nombre, string contenido)
        {
            ZipArchiveEntry entrada = zip.CreateEntry(nombre);
            using Stream stream = entrada.Open();
            byte[] bytes = Encoding.UTF8.GetBytes(contenido);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
