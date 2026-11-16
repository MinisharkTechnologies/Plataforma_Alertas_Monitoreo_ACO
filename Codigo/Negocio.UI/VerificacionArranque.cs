using System.Collections.Generic;
using System.Linq;
using Negocio.BLL;
using Negocio.DAL.Context;

namespace Negocio.UI
{
    /// <summary>
    /// Verificación de integridad (DVH/DVV) ejecutada en el arranque de la aplicación,
    /// antes de mostrar cualquier ventana (requisito T08). Audita a la vez la integridad
    /// de OpenRIN_Negocio (dominio clínico) y la de OpenRIN_Services (seguridad, idiomas,
    /// permisos, bitácora, respaldos), y devuelve un único resultado que incluye los
    /// problemas detectados en AMBAS bases. Si hay alteraciones, el flujo principal
    /// muestra la pantalla de alerta y no habilita el ingreso.
    /// </summary>
    internal static class VerificacionArranque
    {
        /// <summary>Audita la integridad de ambas bases. Devuelve null si la auditoría no pudo ejecutarse.</summary>
        public static ResultadoAuditoria? Auditar()
        {
            try
            {
                // --- Negocio ---
                ResultadoAuditoria rNegocio;
                using (var contexto = new NegocioDbContext())
                {
                    rNegocio = new IntegridadLogic(contexto).Auditar();
                }

                // --- Services ---
                var rServices = Services.BLL.IntegridadServicesLogic.Auditar();

                var tablas = new List<string>(rNegocio.TablasVerificadas);
                tablas.AddRange(new[] { "Logs", "Usuarios", "Idiomas", "Textos", "Permisos", "PerfilesPermisos", "Respaldos" });

                var problemas = new List<string>(rNegocio.Problemas);
                problemas.AddRange(rServices.Problemas);

                var alterados = new List<RegistroAlterado>(rNegocio.Alterados);

                return new ResultadoAuditoria(tablas, problemas, rNegocio.FilasAuditadas + rServices.FilasAuditadas, alterados);
            }
            catch (System.Exception ex)
            {
                Services.Facade.ExceptionManager.ManejarExcepcion(ex, "Verificación de integridad (arranque)", mostrarMensaje: false);
                return null;
            }
        }
    }
}
