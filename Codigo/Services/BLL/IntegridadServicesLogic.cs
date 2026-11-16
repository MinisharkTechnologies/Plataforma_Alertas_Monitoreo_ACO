using System;
using System.Collections.Generic;
using Services.DAL;
using Services.DAL.Tools;
using Services.DomainModel;

namespace Services.BLL
{
    /// <summary>
    /// Integridad de datos (DVH/DVV) para la base Services: verifica que las tablas de la base
    /// Services hayan sido escritas con sus dígitos válidos, exactamente como hace IntegridadLogic
    /// en Negocio para su propia. Detecta filas modificadas fuera de la aplicación y las informa;
    /// también expone la reparación (recálculo auditado). Lo crítico son los datos de seguridad,
    /// de idioma de textos y del catálogo de permisos — todos escriben vía repositorios, que firman
    /// en cada escritura.
    /// </summary>
    internal static class IntegridadServicesLogic
    {
        /// <summary>Resultado de la auditoría: tablas verificadas y problemas hallados.</summary>
        public sealed record ResultadoAuditoria(List<string> Problemas, int FilasAuditadas);

        /// <summary>Audita la integridad de todas las tablas de Services. Devuelve problemas y filas auditadas.</summary>
        public static ResultadoAuditoria Auditar()
        {
            try
            {
                var r = DAL.Tools.IntegridadServices.Auditar();
                return new ResultadoAuditoria(r.Problemas, r.Filas);
            }
            catch (Exception ex)
            {
                Services.Facade.ExceptionManager.ManejarExcepcion(ex, "Verificación de integridad (Services)", mostrarMensaje: false);
                return new ResultadoAuditoria(new List<string>
                {
                    "No se pudo verificar la integridad de la base Services: " + (ex.Message ?? "error"),
                }, 0);
            }
        }

        /// <summary>Recalcula los dígitos verificadores de Services (reparación auditada).</summary>
        public static int RecalcularTodo()
        {
            return DAL.Tools.IntegridadServices.RecalcularTodo();
        }
    }
}
