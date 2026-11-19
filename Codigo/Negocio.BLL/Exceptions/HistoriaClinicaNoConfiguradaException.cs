using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>El paciente no tiene historia clinica configurada (codigo HISTORIA_CLINICA_NO_CONFIGURADA).</summary>
    public class HistoriaClinicaNoConfiguradaException : NegocioBusinessException
    {
        public int IdPaciente { get; }

        public HistoriaClinicaNoConfiguradaException(int idPaciente, Exception? innerException = null)
            : base($"El paciente {idPaciente} no tiene una historia clinica configurada.",
                "HISTORIA_CLINICA_NO_CONFIGURADA", innerException)
        {
            IdPaciente = idPaciente;
        }
    }
}
