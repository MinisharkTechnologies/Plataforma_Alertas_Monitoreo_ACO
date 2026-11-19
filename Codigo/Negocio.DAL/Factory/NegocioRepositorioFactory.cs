using Negocio.DAL.Interfaces;

namespace Negocio.DAL.Factory
{
    /// <summary>
    /// Fábrica de repositorios de la capa de datos de Negocio.
    /// Delega en la fábrica por reflexión compartida de Services (que resuelve, a partir del
    /// archivo de configuración, qué clase implementa cada interfaz) para que exista un único
    /// mecanismo de creación en todo el sistema, pero expuesta desde la capa de Negocio.
    /// </summary>
    public static class NegocioRepositorioFactory
    {
        /// <summary>Crea el repositorio configurado para la interfaz indicada.</summary>
        public static TInterfaz Crear<TInterfaz>(params object[] argumentos) where TInterfaz : class
            => Services.DAL.Factory.RepositorioFactory.Crear<TInterfaz>(null, argumentos);
    }
}
