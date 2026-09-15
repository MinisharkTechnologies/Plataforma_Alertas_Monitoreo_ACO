using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Services.DomainModel;

namespace Services.BLL.Localization
{
    /// <summary>
    /// Núcleo de internacionalización (REQ-ARQ-001): administra la cultura activa y resuelve los
    /// textos desde los archivos de recursos (.resx) del proyecto.
    /// El ResourceManager interno cachea los recursos por cultura; el cambio de idioma en caliente
    /// se logra alternando la cultura activa (sin recompilar ni reiniciar la aplicación).
    /// Si una clave no existe para la cultura solicitada, el ResourceManager cae automáticamente
    /// al idioma por defecto (español, recursos neutrales).
    /// </summary>
    internal static class LocalizationLogic
    {
        private const string RecursoBase = "Services.BLL.Localization.Textos";

        private static readonly ResourceManager Manager =
            new ResourceManager(RecursoBase, typeof(LocalizationLogic).Assembly);

        private static readonly object Candado = new object();

        private static CultureInfo _culturaActiva = new CultureInfo("es");

        /// <summary>Idiomas soportados por la aplicación (códigos de cultura).</summary>
        public static readonly IReadOnlyList<string> IdiomasSoportados =
            new List<string> { "es", "en", "zh-CN" }.AsReadOnly();

        /// <summary>Código del idioma activo (por defecto "es").</summary>
        public static string IdiomaActual => _culturaActiva.Name;

        /// <summary>
        /// Obtiene el texto asociado a una clave en el idioma activo. Si la clave no existe,
        /// devuelve la clave misma y registra una advertencia en la bitácora.
        /// </summary>
        public static string ObtenerTexto(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
            {
                return string.Empty;
            }

            CultureInfo cultura = _culturaActiva;
            try
            {
                string? valor = Manager.GetString(clave, cultura);
                if (valor != null)
                {
                    return valor;
                }
            }
            catch (MissingManifestResourceException)
            {
                // Recursos no disponibles: se devuelve la clave para no romper la interfaz.
            }

            BitacoraLogic.Registrar(LogLevel.Warning,
                $"Clave de localización inexistente: '{clave}' (idioma {cultura.Name}).",
                capa: "Localización");
            return clave;
        }

        /// <summary>Cambia el idioma activo en caliente. Lanza ArgumentException si el código no está soportado.</summary>
        public static void EstablecerIdioma(string codigoIdioma)
        {
            if (string.IsNullOrWhiteSpace(codigoIdioma) || !IdiomasSoportados.Contains(codigoIdioma))
            {
                throw new ArgumentException(
                    $"Idioma no soportado: '{codigoIdioma}'. Idiomas disponibles: {string.Join(", ", IdiomasSoportados)}.");
            }

            lock (Candado)
            {
                _culturaActiva = new CultureInfo(codigoIdioma);
            }

            BitacoraLogic.Registrar(LogLevel.Info,
                $"Idioma de la aplicación cambiado a '{codigoIdioma}'.",
                capa: "Localización");
        }
    }
}
