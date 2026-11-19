using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>El turno solicitado no esta disponible (codigo TURNO_NO_DISPONIBLE).</summary>
    public class TurnoNoDisponibleException : NegocioBusinessException
    {
        public TurnoNoDisponibleException(string detalle, Exception? innerException = null)
            : base(detalle, "TURNO_NO_DISPONIBLE", innerException)
        {
        }
    }
}
