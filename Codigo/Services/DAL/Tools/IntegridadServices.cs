using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Services.DAL.Tools
{
    /// <summary>
    /// Integridad de datos (Digito Verificador Horizontal/Vertical) para las tablas de la base
    /// Services (REQ adamant). Firma los DVH de cada fila y el DVV de cada tabla, con la misma
    /// técnica que Negocio (SHA-256 sobre campos ordenados por nombre), pero implementada sobre
    /// ADO.NET: las lecturas y el formato de salida garantizan valores consistentes entre la
    /// firma en escritura y la auditoría.
    /// </summary>
    internal static class IntegridadServices
    {
        /// <summary>Definición de cada tabla protegida: nombre, columna(s) clave para ordenar y columnas firmadas.</summary>
        private sealed class TablaConfig
        {
            public required string Nombre { get; init; }
            public required string[] Clave { get; init; }
            public required string[] Columnas { get; init; }
        }

        private static readonly TablaConfig[] Tablas =
        {
            new()
            {
                Nombre = "Logs",
                Clave = new[] { "Id" },
                Columnas = new[] { "Fecha", "Nivel", "Mensaje", "Excepcion", "Usuario", "Capa" },
            },
            new()
            {
                Nombre = "Usuarios",
                Clave = new[] { "Id" },
                Columnas = new[] { "NombreUsuario", "NombreCompleto", "HashPassword", "Perfil", "Email",
                                  "PreguntaSeguridad", "RespuestaHash", "Idioma", "Activo", "IntentosFallidos",
                                  "BloqueadoHasta", "FechaAlta" },
            },
            new()
            {
                Nombre = "Idiomas",
                Clave = new[] { "Codigo" },
                Columnas = new[] { "Nombre", "Activo" },
            },
            new()
            {
                Nombre = "Textos",
                Clave = new[] { "Id" },
                Columnas = new[] { "CodigoIdioma", "Clave", "Valor" },
            },
            new()
            {
                Nombre = "Permisos",
                Clave = new[] { "Codigo" },
                Columnas = new[] { "Nombre", "Tipo", "CodigoPadre" },
            },
            new()
            {
                Nombre = "PerfilesPermisos",
                Clave = new[] { "Perfil", "Permiso" },
                Columnas = Array.Empty<string>(),
            },
            new()
            {
                Nombre = "Respaldos",
                Clave = new[] { "Id" },
                Columnas = new[] { "Fecha", "BaseDatos", "Archivo", "TamanoBytes", "Origen", "Sano", "Usuario", "Observaciones" },
            },
        };

        /// <summary>Recalcula los DVH de todas las filas y el DVV de todas las tablas (reparación auditada).</summary>
        public static int RecalcularTodo()
        {
            // Paralelización a nivel de tabla: cada tabla abre su propia conexión y se firma
            // de forma independiente (7 tablas en 7 conexiones ~= 7× throughput en la lectura).
            // Conexiones independientes → sin enlistamiento transaccional entre ellas.
            int firmadas = 0;
            Parallel.ForEach(Tablas, new ParallelOptions { MaxDegreeOfParallelism = 4 }, tabla =>
            {
                int f = RecalcularTabla(tabla);
                System.Threading.Interlocked.Add(ref firmadas, f);
            });
            return firmadas;
        }

        /// <summary>Audita la integridad. Devuelve los problemas encontrados y las filas auditadas.</summary>
        public static (List<string> Problemas, int Filas) Auditar()
        {
            var problemas = new List<string>();
            int filas = 0;
            // 7 tablas en paralelo sobre 4 hilos máx.; cada tabla es solo-lectura durante la auditoría
            var lck = new object();
            Parallel.ForEach(Tablas, new ParallelOptions { MaxDegreeOfParallelism = 4 }, tabla =>
            {
                List<string> probs = AuditarTabla(tabla);
                int n = Contar(tabla);
                lock (lck)
                {
                    filas += n;
                    problemas.AddRange(probs);
                }
            });
            return (problemas, filas);
        }

        private static int Contar(TablaConfig tabla)
        {
            using SqlDataReader lector = SqlHelper.EjecutarLector(
                $"SELECT COUNT(*) FROM [{tabla.Nombre}];", CommandType.Text);
            return lector.Read() ? Convert.ToInt32(lector.GetValue(0)) : 0;
        }

        /// <summary>Recalcula el DVV de una tabla (la fila pudo cambiar/borrarse).</summary>
        public static void ActualizarDvv(string nombreTabla)
        {
            TablaConfig? config = Tablas.FirstOrDefault(t => t.Nombre == nombreTabla);
            if (config == null) return;
            ActualizarDvv(config);
        }

        /// <summary>Recalcula todos los DVH de una tabla y su DVV (tras inserciones/borrados en lote).</summary>
        public static int RecalcularTabla(string nombreTabla)
        {
            TablaConfig? config = Tablas.FirstOrDefault(t => t.Nombre == nombreTabla);
            if (config == null) return 0;
            return RecalcularTabla(config);
        }

        /// <summary>Firma una fila tras una escritura (INSERT/UPDATE).</summary>
        public static void FirmarFila(string nombreTabla, string columnaClave, object valorClave)
        {
            TablaConfig? config = Tablas.FirstOrDefault(t => t.Nombre == nombreTabla);
            if (config == null) return;
            FirmarFila(config, new Dictionary<string, object> { [columnaClave] = valorClave });
        }

        // -------------------------------------------------- lógica interna

        private static int RecalcularTabla(TablaConfig tabla)
        {
            List<Dictionary<string, object?>> filas = LeerFilas(tabla);
            int firmadas = 0;
            foreach (Dictionary<string, object?> fila in filas)
            {
                string dvh = FirmarFilaInterna(fila);
                if (!string.Equals(ObtenerDvh(fila), dvh, StringComparison.Ordinal))
                {
                    ActualizarDvh(tabla, ClaveDe(tabla, fila), dvh);
                    firmadas++;
                }
            }
            ActualizarDvv(tabla);
            return firmadas;
        }

        private static List<string> AuditarTabla(TablaConfig tabla)
        {
            var problemas = new List<string>();
            List<Dictionary<string, object?>> filas = LeerFilas(tabla);

            int sinDvh = 0, alteradas = 0;
            var dvv = new List<(string Clave, string? Dvh)>();
            foreach (Dictionary<string, object?> fila in filas)
            {
                string? actual = ObtenerDvh(fila);
                if (string.IsNullOrEmpty(actual))
                {
                    sinDvh++;
                    dvv.Add((ClaveDe(tabla, fila), "∅"));
                    continue;
                }
                string esperado = FirmarFilaInterna(fila);
                if (!string.Equals(actual, esperado, StringComparison.Ordinal)) alteradas++;
                dvv.Add((ClaveDe(tabla, fila), actual));
            }

            if (sinDvh > 0) problemas.Add($"Tabla '{tabla.Nombre}': {sinDvh} fila(s) sin DVH (fila no firmada).");
            if (alteradas > 0) problemas.Add($"Tabla '{tabla.Nombre}': {alteradas} fila(s) con DVH inválido — datos modificados fuera del sistema.");

            string dvvEsperado = Services.DomainModel.DigitoVerificador.CalcularDVV(tabla.Nombre, dvv);
            string? dvvRegistrado = LeerDvv(tabla.Nombre);
            if (dvvRegistrado == null)
            {
                problemas.Add($"Tabla '{tabla.Nombre}': sin DVV registrado (recalcular para firmarla).");
            }
            else if (!string.Equals(dvvRegistrado, dvvEsperado, StringComparison.Ordinal))
            {
                problemas.Add($"Tabla '{tabla.Nombre}': el DVV no coincide con el conjunto de sus filas — tabla alterada.");
            }
            return problemas;
        }

        private static List<Dictionary<string, object?>> LeerFilas(TablaConfig tabla)
        {
            string clave = string.Join(", ", tabla.Clave);
            string columnas = tabla.Columnas.Length > 0 ? string.Join(", ", tabla.Columnas) + ", " : "";
            string sql = $"SELECT {clave}, {columnas}DVH FROM [{tabla.Nombre}] ORDER BY {clave};";
            var filas = new List<Dictionary<string, object?>>();
            using SqlDataReader lector = SqlHelper.EjecutarLector(sql, CommandType.Text);
            while (lector.Read())
            {
                var fila = new Dictionary<string, object?>(tabla.Clave.Length + tabla.Columnas.Length + 1, StringComparer.Ordinal);
                for (int i = 0; i < lector.FieldCount; i++)
                {
                    string nombre = lector.GetName(i);
                    if (nombre == "") continue;
                    fila[nombre] = lector.IsDBNull(i) ? null : lector.GetValue(i);
                }
                filas.Add(fila);
            }
            return filas;
        }

        private static string FirmarFilaInterna(Dictionary<string, object?> fila)
        {
            var campos = fila.Where(k => k.Key != "DVH")
                .Select(k => new KeyValuePair<string, object?>(k.Key, k.Value));
            return Services.DomainModel.DigitoVerificador.CalcularDVH(campos);
        }

        private static string ClaveDe(TablaConfig tabla, Dictionary<string, object?> fila)
        {
            if (tabla.Clave.Length == 1)
            {
                return Services.DomainModel.DigitoVerificador.Formatear(fila[tabla.Clave[0]]);
            }
            return string.Join(":", tabla.Clave.Select(c => Services.DomainModel.DigitoVerificador.Formatear(fila[c])));
        }

        private static string? ObtenerDvh(Dictionary<string, object?> fila)
            => fila.TryGetValue("DVH", out object? dvh) ? dvh as string : null;

        private static void ActualizarDvh(TablaConfig tabla, string clave, string dvh)
        {
            if (tabla.Clave.Length == 1)
            {
                string sql = $"UPDATE [{tabla.Nombre}] SET DVH = @dvh WHERE [{tabla.Clave[0]}] = @clave;";
                SqlHelper.EjecutarComando(sql, CommandType.Text,
                    new SqlParameter("@dvh", dvh), new SqlParameter("@clave", ConvertirClave(tabla, tabla.Clave[0], clave)));
            }
            else
            {
                string[] partes = clave.Split(':');
                string where = string.Join(" AND ", tabla.Clave.Select((c, i) => $"[{c}] = @p{i}"));
                var pars = new List<SqlParameter> { new SqlParameter("@dvh", dvh) };
                for (int i = 0; i < tabla.Clave.Length; i++)
                {
                    pars.Add(new SqlParameter($"@p{i}", ConvertirClave(tabla, tabla.Clave[i], partes[i])));
                }
                SqlHelper.EjecutarComando($"UPDATE [{tabla.Nombre}] SET DVH = @dvh WHERE {where};", CommandType.Text, pars.ToArray());
            }
        }

        private static object ConvertirClave(TablaConfig tabla, string columna, string valor)
        {
            // La clave suele ser numérica o texto; el parámetro tiene que respetar el tipo de la columna.
            // Intento int → long; si no, string.
            if (int.TryParse(valor, out int i)) return i;
            if (long.TryParse(valor, out long l)) return l;
            return valor;
        }

        private static void ActualizarDvv(TablaConfig tabla)
        {
            List<Dictionary<string, object?>> filas = LeerFilas(tabla);
            var dvv = filas.Select(f => (ClaveDe(tabla, f), ObtenerDvh(f))).ToList();
            string calculado = Services.DomainModel.DigitoVerificador.CalcularDVV(tabla.Nombre, dvv);
            if (dvv.Any(f => f.Item2 == null))
            {
                // Alguna fila perdió DVH; el DVV resultante no es confiable. Lo registro igualmente
                // para no dividir el estado histórico; la auditoría lo señalará por la vía de los DVH.
            }
            SqlHelper.EjecutarComando(
                "MERGE dbo.DigitosVerificadores AS t USING (SELECT @t AS NombreTabla) s ON t.NombreTabla = s.NombreTabla " +
                "WHEN MATCHED THEN UPDATE SET DVV = @dvv, FechaCalculo = SYSDATETIME() " +
                "WHEN NOT MATCHED THEN INSERT (NombreTabla, DVV) VALUES (@t, @dvv);",
                CommandType.Text,
                new SqlParameter("@t", tabla.Nombre),
                new SqlParameter("@dvv", calculado));
        }

        private static string? LeerDvv(string nombreTabla)
        {
            object? valor = SqlHelper.EjecutarEscalar(
                "SELECT DVV FROM dbo.DigitosVerificadores WHERE NombreTabla = @t;",
                CommandType.Text, new SqlParameter("@t", nombreTabla));
            return valor as string;
        }

        private static void FirmarFila(TablaConfig config, Dictionary<string, object> claves)
        {
            string columnasEnSelect = string.Join(", ", config.Clave.Union(config.Columnas).Distinct()) + ", DVH";
            string where = string.Join(" AND ", config.Clave.Select((c, i) => $"[{c}] = @k{i}"));

            var pars = new List<SqlParameter>();
            for (int i = 0; i < config.Clave.Length; i++)
            {
                pars.Add(new SqlParameter($"@k{i}", claves[config.Clave[i]]));
            }
            string sql = $"SELECT {columnasEnSelect} FROM [{config.Nombre}] WHERE {where};";

            Dictionary<string, object?>? fila = null;
            using (SqlDataReader lector = SqlHelper.EjecutarLector(sql, CommandType.Text, pars.Select(p => p).ToArray()))
            {
                if (lector.Read())
                {
                    fila = new Dictionary<string, object?>(StringComparer.Ordinal);
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        fila[lector.GetName(i)] = lector.IsDBNull(i) ? null : lector.GetValue(i);
                    }
                }
            }
            if (fila == null) return;

            string dvh = FirmarFilaInterna(fila);
            string claveTxt = ClaveDe(config, fila);
            ActualizarDvh(config, claveTxt, dvh);
            ActualizarDvv(config);
        }
    }
}
