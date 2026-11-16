namespace Services.DomainModel.Exceptions
{
    /// <summary>La base de datos está alterada (dígitos verificadores inválidos) y no puede operarse con seguridad.</summary>
    public class IntegridadVulneradaException : ReglaNegocioException
    {
        public IntegridadVulneradaException(string mensaje) : base(mensaje)
        {
        }
    }
}
