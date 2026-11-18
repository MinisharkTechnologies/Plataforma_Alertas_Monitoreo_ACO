using Services.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Diálogo de recuperación de contraseña (REQ-NF-001): valida la identidad mediante la
    /// pregunta de seguridad configurada (hash) y permite establecer una contraseña nueva.
    /// </summary>
    public partial class RecuperacionForm : Form
    {
        // Los controles de la interfaz se declaran en RecuperacionForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public RecuperacionForm()
        {
            InitializeComponent();
        }

        public RecuperacionForm(string usuarioInicial) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se tocan los servicios:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            AplicarTextos();
            if (usuarioInicial.Length > 0)
            {
                _txtUsuario.Text = usuarioInicial;
            }
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Aplica al diálogo los textos localizados (se conserva el comportamiento original).</summary>
        private void AplicarTextos()
        {
            Text = $"OpenRIN — {Localizacion("rec.titulo")}";
            _lblUsuario.Text = Localizacion("login.usuario");
            _btnVerPregunta.Text = Localizacion("rec.verPregunta");
            _lblRespuesta.Text = Localizacion("rec.respuesta");
            _lblNueva.Text = Localizacion("rec.nuevaContrasena");
            _btnCambiar.Text = Localizacion("rec.cambiar");
            _btnCancelar.Text = Localizacion("comun.cancelar");
        }

        private void TxtUsuario_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                VerPregunta();
            }
        }

        private void BtnVerPregunta_Click(object? sender, EventArgs e) => VerPregunta();

        private void BtnCambiar_Click(object? sender, EventArgs e) => CambiarContrasena();

        private void BtnCancelar_Click(object? sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void VerPregunta()
        {
            _lblAviso.Text = string.Empty;
            string usuario = _txtUsuario.Text.Trim();
            if (usuario.Length == 0)
            {
                _lblPregunta.Text = string.Empty;
                _lblAviso.Text = Localizacion("login.campoObligatorio");
                return;
            }

            try
            {
                string? pregunta = SeguridadService.ObtenerPreguntaSeguridad(usuario);
                _lblPregunta.Text = pregunta == null
                    ? Localizacion("rec.sinPregunta")
                    : $"{Localizacion("rec.pregunta")} {pregunta}";
                _lblPregunta.ForeColor = pregunta == null ? Color.FromArgb(180, 40, 40) : Color.FromArgb(30, 66, 120);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "RecuperacionForm");
            }
        }

        private void CambiarContrasena()
        {
            try
            {
                SeguridadService.RecuperarContrasena(
                    _txtUsuario.Text.Trim(),
                    _txtRespuesta.Text.Trim(),
                    _txtNuevaContrasena.Text);

                MessageBox.Show(this, Localizacion("rec.ok"), Localizacion("rec.cambiar"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (CredencialesInvalidasException ex)
            {
                _lblAviso.Text = ex.Message;
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException ex)
            {
                _lblAviso.Text = ex.Message;
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "RecuperacionForm");
            }
        }
    }
}
