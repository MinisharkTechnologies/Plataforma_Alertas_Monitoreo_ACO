using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>El seguimiento clinico no pudo registrarse (codigo SEGUIMIENTO_INVALIDO).</summary>
    public class SeguimientoClinicoInvalidoException : NegocioBusinessException
    {
        public SeguimientoClinicoInvalidoException(string detalle, Exception? innerException = null)
            : base(detalle, "SEGUIMIENTO_INVALIDO", innerException)
        {
        }
    }
}
