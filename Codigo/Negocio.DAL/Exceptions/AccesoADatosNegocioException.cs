using System;
using Services.DomainModel.Exceptions;

namespace Negocio.DAL.Exceptions
{
    /// <summary>
    /// Error de acceso a datos de la capa DAL de Negocio: envuelve cualquier fallo del motor
    /// (conexión, timeout, restricción de integridad) para que las capas superiores nunca
    /// reciban una excepción genérica del proveedor.
    /// </summary>
    public class AccesoADatosNegocioException : AccesoADatosException
    {
        /// <summary>Operación de datos que falló (por ejemplo «Pacientes.BuscarActivos»).</summary>
        public string Operacion { get; }

        public AccesoADatosNegocioException(string operacion, Exception innerException)
            : base($"No se pudo acceder a los datos ({operacion}). {innerException.Message}", innerException, "ACCESO_A_DATOS_NEGOCIO")
        {
            Operacion = operacion;
        }

        public AccesoADatosNegocioException(string operacion, string mensaje, Exception? innerException = null)
            : base(mensaje, innerException, "ACCESO_A_DATOS_NEGOCIO")
        {
            Operacion = operacion;
        }
    }
}