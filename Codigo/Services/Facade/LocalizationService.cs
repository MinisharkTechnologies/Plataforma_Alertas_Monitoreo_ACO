using System;
using System.Collections.Generic;
using Services.BLL.Localization;

namespace Services.Facade
{
    /// <summary>
    /// Fachada pública de internacionalización (REQ-ARQ-001). Punto de entrada único para
    /// obtener textos traducidos y cambiar el idioma de la aplicación en caliente.
    /// </summary>
    public static class LocalizationService
    {
        /// <summary>Obtiene el texto asociado a una clave en el idioma activo (fallback al idioma por defecto).</summary>
        public static string ObtenerTexto(string clave) => LocalizationLogic.ObtenerTexto(clave);

        /// <summary>Obtiene un texto con formato aplicado (string.Format) en el idioma activo.</summary>
        public static string ObtenerTexto(string clave, params object[] argumentos)
            => string.Format(LocalizationLogic.ObtenerTexto(clave), argumentos);

        /// <summary>Cambia el idioma de la aplicación en caliente ("es", "en", "zh-CN").</summary>
        public static void EstablecerIdioma(string codigoIdioma) => LocalizationLogic.EstablecerIdioma(codigoIdioma);

        /// <summary>Código del idioma activo.</summary>
        public static string IdiomaActual => LocalizationLogic.IdiomaActual;

        /// <summary>Idiomas soportados por la aplicación (códigos de cultura).</summary>
        public static IReadOnlyList<string> IdiomasSoportados => LocalizationLogic.IdiomasSoportados;
    }
}
