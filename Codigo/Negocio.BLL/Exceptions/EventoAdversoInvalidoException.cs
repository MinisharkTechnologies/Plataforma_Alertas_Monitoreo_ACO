using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>El evento adverso informado no es valido (codigo EVENTO_ADVERSO_INVALIDO).</summary>
    public class EventoAdversoInvalidoException : NegocioBusinessException
    {
        public EventoAdversoInvalidoException(string detalle, Exception? innerException = null)
            : base(detalle, "EVENTO_ADVERSO_INVALIDO", innerException)
        {
        }
    }
}
