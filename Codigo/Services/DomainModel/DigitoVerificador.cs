using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Services.DomainModel
{
    /// <summary>
    /// Cálculo de dígitos verificadores (integridad de datos, DVH/DVV) para la base Services.
    /// Idéntico en espíritu al DVH/DVV de Negocio (DVH = SHA-256 sobre campos escalares ordenados
    /// por nombre; DVV = SHA-256 sobre nombre de tabla + DVH de cada fila ordenada por clave), con
    /// la diferencia de que acá los valores llegan como pares (columna, valor) leídos con
    /// SqlDataReader, no como entidades EF. La MISMA rutina firma al escribir y al auditar.
    /// </summary>
    public static class DigitoVerificador
    {
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

        /// <summary>Formatea un valor escalar de forma determinista (invariante).</summary>
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
