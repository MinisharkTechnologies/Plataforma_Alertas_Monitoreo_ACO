using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>La alerta solicitada no existe (codigo ALERTA_NO_ENCONTRADA).</summary>
    public class AlertaNoEncontradaException : NegocioBusinessException
    {
        public int? IdAlerta { get; }

        public AlertaNoEncontradaException(int? idAlerta = null, Exception? innerException = null)
            : base(idAlerta == null
                ? "La alerta solicitada no existe."
                : $"No existe la alerta con Id {idAlerta}.",
                "ALERTA_NO_ENCONTRADA", innerException)
        {
            IdAlerta = idAlerta;
        }
    }
}
