using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>El valor de RIN esta fuera del rango terapeutico (codigo RIN_FUERA_DE_RANGO).</summary>
    public class RINFueraDeRangoException : NegocioBusinessException
    {
        public decimal Valor { get; }
        public decimal LimiteInferior { get; }
        public decimal LimiteSuperior { get; }

        public RINFueraDeRangoException(decimal valor, decimal limiteInferior, decimal limiteSuperior, Exception? innerException = null)
            : base($"El valor de RIN {valor:0.0} esta fuera del rango terapeutico del paciente "
                   + $"({limiteInferior:0.0} a {limiteSuperior:0.0}).", "RIN_FUERA_DE_RANGO", innerException)
        {
            Valor = valor;
            LimiteInferior = limiteInferior;
            LimiteSuperior = limiteSuperior;
        }
    }
}
