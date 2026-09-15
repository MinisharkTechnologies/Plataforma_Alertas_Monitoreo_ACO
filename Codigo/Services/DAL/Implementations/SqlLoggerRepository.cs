using System.Data;
using Microsoft.Data.SqlClient;
using Services.DAL.Interfaces;
using Services.DAL.Tools;
using Services.DomainModel;

namespace Services.DAL.Implementations
{
    /// <summary>
    /// Persiste entradas de bitácora en la tabla Logs de la base Services (ADO.NET, REQ-ARQ-003).
    /// En caso de error técnico lanza <see cref="Services.DomainModel.Exceptions.DataAccessException"/>.
    /// </summary>
    public class SqlLoggerRepository : ILoggerRepository
    {
        private const string InsertarSql = @"
            INSERT INTO dbo.Logs (Fecha, Nivel, Mensaje, Excepcion, Usuario, Capa)
            VALUES (@Fecha, @Nivel, @Mensaje, @Excepcion, @Usuario, @Capa);";

        /// <inheritdoc />
        public void Registrar(LogEntry entrada)
        {
            SqlHelper.EjecutarComando(
                InsertarSql,
                CommandType.Text,
                new SqlParameter("@Fecha", entrada.Fecha),
                new SqlParameter("@Nivel", entrada.Nivel.ToString()),
                new SqlParameter("@Mensaje", entrada.Mensaje),
                new SqlParameter("@Excepcion", (object?)entrada.Excepcion ?? DBNull.Value),
                new SqlParameter("@Usuario", (object?)entrada.Usuario ?? DBNull.Value),
                new SqlParameter("@Capa", (object?)entrada.Capa ?? DBNull.Value));
        }
    }
}
