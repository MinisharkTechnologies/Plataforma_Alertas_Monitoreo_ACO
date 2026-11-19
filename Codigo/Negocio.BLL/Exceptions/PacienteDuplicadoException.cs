using System;

namespace Negocio.BLL.Exceptions
{
    /// <summary>Ya existe un paciente con ese documento (codigo PACIENTE_DUPLICADO).</summary>
    public class PacienteDuplicadoException : NegocioBusinessException
    {
        public string DNI { get; }

        public PacienteDuplicadoException(string dni, Exception? innerException = null)
            : base($"Ya existe un paciente con el documento {dni}. Verifique los datos antes de continuar.",
                "PACIENTE_DUPLICADO", innerException)
        {
            DNI = dni;
        }
    }
}
