using Services.Facade;

namespace Negocio.UI;

/// <summary>
/// Punto de entrada de la aplicación de escritorio OpenRIN: registra los manejadores
/// globales de excepciones (REQ-ARQ-004), inicializa el idioma por defecto (REQ-ARQ-001)
/// y ejecuta el flujo Login → Panel Principal.
/// </summary>
static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        ExceptionManager.RegistrarManejadoresGlobales();
        LocalizationService.EstablecerIdioma("es");

        using var login = new LoginForm();
        if (login.ShowDialog() != DialogResult.OK || login.Sesion == null)
        {
            return;
        }

        Application.Run(new PrincipalForm(login.Sesion));
    }
}
