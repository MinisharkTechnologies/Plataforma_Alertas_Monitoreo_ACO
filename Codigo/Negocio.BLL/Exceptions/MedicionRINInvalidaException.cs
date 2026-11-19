using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>La medicion de RIN no es valida (codigo MEDICION_RIN_INVALIDA).</summary>
    public class MedicionRINInvalidaException : NegocioBusinessException
    {
        public MedicionRINInvalidaException(string detalle, Exception? innerException = null)
            : base(detalle, "MEDICION_RIN_INVALIDA", innerException)
        {
        }
    }
}
