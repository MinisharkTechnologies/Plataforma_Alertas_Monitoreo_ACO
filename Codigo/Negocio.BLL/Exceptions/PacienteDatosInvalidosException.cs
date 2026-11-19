using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>Los datos del paciente no son validos (codigo PACIENTE_DATOS_INVALIDOS).</summary>
    public class PacienteDatosInvalidosException : NegocioBusinessException
    {
        public PacienteDatosInvalidosException(string detalle, Exception? innerException = null)
            : base(detalle, "PACIENTE_DATOS_INVALIDOS", innerException)
        {
        }
    }
}
