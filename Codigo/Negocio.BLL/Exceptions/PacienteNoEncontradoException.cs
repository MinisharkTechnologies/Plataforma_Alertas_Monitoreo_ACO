using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>El paciente no existe o fue dado de baja (codigo PACIENTE_NO_ENCONTRADO).</summary>
    public class PacienteNoEncontradoException : NegocioBusinessException
    {
        public string? DNI { get; }

        public PacienteNoEncontradoException(string? dni = null, Exception? innerException = null)
            : base(dni == null
                ? "El paciente solicitado no existe o fue dado de baja."
                : $"No existe un paciente activo con el documento {dni}.",
                "PACIENTE_NO_ENCONTRADO", innerException)
        {
            DNI = dni;
        }
    }
}
