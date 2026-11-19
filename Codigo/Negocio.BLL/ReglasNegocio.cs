using Negocio.DomainModel.Exceptions;
using Services.DomainModel;
using Services.Facade;
using Services.DomainModel.Exceptions;

namespace Negocio.BLL
{
    /// <summary>
    /// Reglas transversales de la capa de lógica de negocio: rechazo auditado de operaciones
    /// inválidas. Toda validación fallida queda registrada en bitácora con nivel Warning
    /// (capa Negocio), tal como exige el REQ-ARQ-007.
    /// </summary>
    internal static class ReglasNegocio
    {
        /// <summary>Capa usada en los registros de bitácora del módulo Negocio.</summary>
        public const string Capa = "Negocio";

        /// <summary>Registra el rechazo en bitácora y devuelve la excepción lista para lanzar.</summary>
        public static ValidacionNegocioException Rechazar(List<string> errores, string contexto, string usuarioResponsable)
        {
            try
            {
                BitacoraService.Registrar(LogLevel.Warning,
                    $"Rechazado: {contexto} — {string.Join(" | ", errores)}",
                    null, usuarioResponsable, Capa);
                return new ValidacionNegocioException(errores);
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ReglaNegocioException("No se pudo registrar el rechazo de la operación en la bitácora.", ex, "REGLA_NEGOCIO_BITACORA_FALLIDA");
            }
        }
    }
}
