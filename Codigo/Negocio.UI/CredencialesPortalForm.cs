using Negocio.BLL;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Muestra una única vez las credenciales del portal generadas al dar de alta un paciente
    /// (REQ-FUNC-001): usuario (DNI) y contraseña temporal, con copiado al portapapeles.
    /// </summary>
    public partial class CredencialesPortalForm : Form
    {
        // Los controles de la interfaz se declaran en CredencialesPortalForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public CredencialesPortalForm()
        {
            InitializeComponent();
        }

        public CredencialesPortalForm(CredencialesPortal credenciales) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se tocan los servicios:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            AplicarTextos();
            _txtUsuario.Text = credenciales.Usuario;
            _txtClave.Text = credenciales.PasswordTemporal;
        }

        /// <summary>Aplica al diálogo los textos localizados (se conserva el comportamiento original).</summary>
        private void AplicarTextos()
        {
            Text = LocalizationService.ObtenerTexto("pacientes.cred.titulo");
            _lblTitulo.Text = LocalizationService.ObtenerTexto("pacientes.cred.titulo");
            _lblAviso.Text = LocalizationService.ObtenerTexto("pacientes.cred.aviso");
            _lblUsuario.Text = LocalizationService.ObtenerTexto("login.usuario");
            _lblClave.Text = LocalizationService.ObtenerTexto("login.contrasena");
            _btnCopiar.Text = LocalizationService.ObtenerTexto("pacientes.cred.copiar");
            _btnCerrar.Text = LocalizationService.ObtenerTexto("comun.cerrar");
        }

        private void BtnCopiar_Click(object? sender, EventArgs e)
        {
            Clipboard.SetText(_txtClave.Text);
            MessageBox.Show(this, LocalizationService.ObtenerTexto("pacientes.cred.copiado"), Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCerrar_Click(object? sender, EventArgs e) => DialogResult = DialogResult.OK;
    }
}
