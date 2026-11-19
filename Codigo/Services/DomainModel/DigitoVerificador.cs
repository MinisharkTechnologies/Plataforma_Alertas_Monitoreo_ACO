using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Services.DomainModel
{
    /// <summary>
    /// Cálculo de dígitos verificadores (integridad de datos, DVH/DVV) como SERVICIO TÉCNICO del
    /// sistema, reutilizable por cualquier módulo:
    /// el DVH firma los campos escalares de una fila y el DVV firma el conjunto de DVH de una tabla.
    /// La MISMA rutina se usa al escribir y al auditar, garantizando firmas reproducibles.
    /// Tiene dos puntos de entrada según el origen de los datos: entidades (reflexión sobre
    /// propiedades) y filas leídas con ADO (pares columna → valor).
    /// </summary>
    public static class DigitoVerificador
    {
        // ---------- Entidades (EF / POCO) ----------

        /// <summary>Calcula el DVH de una entidad: SHA-256 (hex) sobre sus campos escalares ordenados por nombre.</summary>
        public static string CalcularDVH(object entidad)
        {
            var campos = new SortedDictionary<string, string>(StringComparer.Ordinal);
            foreach (System.Reflection.PropertyInfo propiedad in entidad.GetType().GetProperties())
            {
                if (propiedad.Name == "DVH" || !propiedad.CanRead)
                {
                    continue;
                }
                System.Type tipo = propiedad.PropertyType;
                if (tipo != typeof(string) && !tipo.IsValueType)
                {
                    continue; // navegaciones u objetos complejos: no participan de la firma
                }
                campos[propiedad.Name] = Formatear(propiedad.GetValue(entidad));
            }

            var cuerpo = new StringBuilder();
            foreach (KeyValuePair<string, string> campo in campos)
            {
                cuerpo.Append(campo.Key).Append('=').Append(campo.Value).Append('|');
            }
            return Hash(cuerpo.ToString());
        }

        /// <summary>Calcula el DVV de una tabla a partir de entidades: SHA-256 (hex) sobre su nombre y los DVH ordenados por Id.</summary>
        public static string CalcularDVV(string tabla, System.Collections.Generic.IEnumerable<(int Id, string? Dvh)> filas)
        {
            var cuerpo = new StringBuilder();
            cuerpo.Append(tabla).Append('#');
            foreach ((int Id, string? Dvh) fila in filas.OrderBy(f => f.Id))
            {
                cuerpo.Append(fila.Id).Append(':').Append(fila.Dvh ?? "∅").Append('|');
            }
            return Hash(cuerpo.ToString());
        }

        // ---------- Filas leídas con ADO (columna → valor) ----------

        /// <summary>Calcula el DVH de una fila a partir de sus campos (columna → valor CLR).</summary>
        public static string CalcularDVH(System.Collections.Generic.IEnumerable<KeyValuePair<string, object?>> campos)
        {
            var orden = new System.Collections.Generic.SortedDictionary<string, string>(StringComparer.Ordinal);
            foreach (KeyValuePair<string, object?> campo in campos)
            {
                if (string.Equals(campo.Key, "DVH", StringComparison.OrdinalIgnoreCase)) continue;
                orden[campo.Key] = Formatear(campo.Value);
            }

            var cuerpo = new StringBuilder();
            foreach (KeyValuePair<string, string> campo in orden)
            {
                cuerpo.Append(campo.Key).Append('=').Append(campo.Value).Append('|');
            }
            return Hash(cuerpo.ToString());
        }

        /// <summary>Calcula el DVV de una tabla: SHA-256 sobre su nombre y los DVH ordenados por clave.</summary>
        public static string CalcularDVV(string tabla, System.Collections.Generic.IEnumerable<(string Clave, string? Dvh)> filas)
        {
            var cuerpo = new StringBuilder();
            cuerpo.Append(tabla).Append('#');
            foreach ((string Clave, string? Dvh) fila in filas.OrderBy(f => f.Clave, StringComparer.Ordinal))
            {
                cuerpo.Append(fila.Clave).Append(':').Append(fila.Dvh ?? "∅").Append('|');
            }
            return Hash(cuerpo.ToString());
        }

        /// <summary>Formatea un valor escalar de forma determinista (invariante; decimales redondeados a 4 posiciones).</summary>
        public static string Formatear(object? valor) => valor switch
        {
            null => string.Empty,
            DBNull => string.Empty,
            string texto => texto,
            bool booleano => booleano ? "1" : "0",
            DateTime fecha => fecha.ToString("yyyy-MM-ddTHH:mm:ss.fffffff", CultureInfo.InvariantCulture),
            decimal numero => decimal.Round(numero, 4).ToString("0.####", CultureInfo.InvariantCulture),
            float numero => numero.ToString("0.####", CultureInfo.InvariantCulture),
            double numero => numero.ToString("0.####", CultureInfo.InvariantCulture),
            System.Enum enumeracion => enumeracion.ToString(),
            IFormattable formateable => formateable.ToString(null, CultureInfo.InvariantCulture),
            _ => valor.ToString() ?? string.Empty
        };

        private static string Hash(string contenido)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(contenido));
            return Convert.ToHexString(bytes);
        }
    }
}
