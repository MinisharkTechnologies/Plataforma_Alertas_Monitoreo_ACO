using System.ComponentModel;

namespace Negocio.UI
{
    /// <summary>
    /// Indica si el código se está ejecutando dentro del diseñador de Visual Studio
    /// (tiempo de diseño) y no en la aplicación real (tiempo de ejecución).
    /// Los constructores lo consultan para no tocar la base de datos ni servicios
    /// mientras el diseñador instancia el formulario para dibujarlo.
    /// </summary>
    internal static class Disenio
    {
        /// <summary>True cuando corre dentro del diseñador de formularios de Visual Studio.</summary>
        public static bool Activo =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime;
    }
}
