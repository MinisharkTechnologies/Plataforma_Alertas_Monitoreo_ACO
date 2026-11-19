using System;

namespace Services.DomainModel.Exceptions
{
    /// <summary>
    /// Base de las excepciones controladas del sistema: su mensaje está pensado para el usuario,
    /// por eso la pantalla lo muestra tal cual en lugar de «Error inesperado».
    /// Cada excepción lleva un <see cref="Codigo"/> estable (para bitácora y clasificación) y la
    /// fecha/hora en que se produjo, siguiendo el mismo criterio que las excepciones de dominio
    /// del proyecto de referencia de la cátedra.
    /// </summary>
    public class ReglaNegocioException : Exception
    {
        /// <summary>Código estable del error (por ejemplo «PACIENTE_DUPLICADO»).</summary>
        public string Codigo { get; protected set; }

        /// <summary>Momento en que se produjo el error.</summary>
        public DateTime FechaHora { get; }

        public ReglaNegocioException(string mensaje, Exception? innerException = null, string codigo = "REGLA_NEGOCIO")
            : base(mensaje, innerException)
        {
            Codigo = codigo;
            FechaHora = DateTime.Now;
        }
    }
}