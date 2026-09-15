using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Services.DomainModel.Exceptions;

namespace Services.DAL.Tools
{
    /// <summary>
    /// Helper ADO.NET del módulo Services: ejecuta comandos parametrizados contra SQL Server,
    /// normaliza valores nulos y envuelve errores técnicos en <see cref="DataAccessException"/>
    /// para no filtrar detalles de conexión hacia las capas superiores (REQ-ARQ-004).
    /// </summary>
    internal static class SqlHelper
    {
        private static string ObtenerConexion()
        {
            string? cadena = ConfigurationManager.ConnectionStrings["ServicesDB"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(cadena))
            {
                throw new InvalidOperationException(
                    "Falta la cadena de conexión 'ServicesDB' en la configuración de la aplicación.");
            }
            return cadena;
        }

        /// <summary>Ejecuta un comando de escritura y devuelve la cantidad de filas afectadas.</summary>
        public static int EjecutarComando(string textoComando, CommandType tipo, params SqlParameter[] parametros)
        {
            NormalizarNulos(parametros);
            try
            {
                using (SqlConnection conexion = new SqlConnection(ObtenerConexion()))
                using (SqlCommand comando = new SqlCommand(textoComando, conexion))
                {
                    comando.CommandType = tipo;
                    if (parametros.Length > 0)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("No se pudo completar la operación contra la base de datos.", ex);
            }
        }

        /// <summary>Ejecuta un comando y devuelve el primer valor del primer registro.</summary>
        public static object? EjecutarEscalar(string textoComando, CommandType tipo, params SqlParameter[] parametros)
        {
            NormalizarNulos(parametros);
            try
            {
                using (SqlConnection conexion = new SqlConnection(ObtenerConexion()))
                using (SqlCommand comando = new SqlCommand(textoComando, conexion))
                {
                    comando.CommandType = tipo;
                    if (parametros.Length > 0)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    conexion.Open();
                    return comando.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("No se pudo completar la operación contra la base de datos.", ex);
            }
        }

        /// <summary>Ejecuta un comando y devuelve un lector de datos (la conexión se cierra junto al lector).</summary>
        public static SqlDataReader EjecutarLector(string textoComando, CommandType tipo, params SqlParameter[] parametros)
        {
            NormalizarNulos(parametros);
            try
            {
                SqlConnection conexion = new SqlConnection(ObtenerConexion());
                using (SqlCommand comando = new SqlCommand(textoComando, conexion))
                {
                    comando.CommandType = tipo;
                    if (parametros.Length > 0)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    conexion.Open();
                    return comando.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("No se pudo completar la operación contra la base de datos.", ex);
            }
        }

        private static void NormalizarNulos(SqlParameter[] parametros)
        {
            foreach (SqlParameter parametro in parametros)
            {
                if (parametro.Value == null)
                {
                    parametro.Value = DBNull.Value;
                }
            }
        }
    }
}
