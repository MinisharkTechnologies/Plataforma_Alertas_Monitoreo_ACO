using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Diálogo de alta de usuario del sistema (pantalla Sistema): registra la cuenta a través
    /// de la API real de seguridad (hash PBKDF2 + validaciones de contraseña), con pregunta y
    /// respuesta de seguridad opcionales para el flujo de recuperación de contraseña.
    /// </summary>
    public partial class UsuarioNuevoForm : Form
    {
        // Los controles de la interfaz se declaran en UsuarioNuevoForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        public UsuarioNuevoForm()
        {
            InitializeComponent();

            // En tiempo de diseño (diseñador de Visual Studio) no se tocan los servicios:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            AplicarTextos();
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Aplica al diálogo los textos localizados (se conserva el comportamiento original).</summary>
        private void AplicarTextos()
        {
            Text = $"OpenRIN — {Localizacion("sistema.nuevoUsuario")}";
            _lblUsuario.Text = Localizacion("sistema.columna.usuario");
            _lblPerfil.Text = Localizacion("sistema.columna.perfil");
            _lblNombre.Text = Localizacion("sistema.columna.nombre");
            _lblEmail.Text = Localizacion("pacientes.email");
            _lblContrasena.Text = Localizacion("login.contrasena");
            _lblPregunta.Text = Localizacion("rec.pregunta");
            _lblRespuesta.Text = Localizacion("rec.respuesta");
            _btnGuardar.Text = Localizacion("comun.guardar");
            _btnCancelar.Text = Localizacion("comun.cancelar");

            _cmbPregunta.Items.Clear();
            _cmbPregunta.Items.Add(Localizacion("rec.pregunta1"));
            _cmbPregunta.Items.Add(Localizacion("rec.pregunta2"));
            _cmbPregunta.Items.Add(Localizacion("rec.pregunta3"));
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                string perfil = _cmbPerfil.SelectedItem?.ToString() ?? "administrativo";
                string? pregunta = _cmbPregunta.SelectedIndex >= 0 ? _cmbPregunta.SelectedItem?.ToString() : null;
                string? respuesta = string.IsNullOrWhiteSpace(_txtRespuesta.Text) ? null : _txtRespuesta.Text.Trim();

                int id = SeguridadService.RegistrarUsuario(
                    _txtUsuario.Text.Trim(),
                    _txtNombre.Text.Trim(),
                    _txtContrasena.Text,
                    perfil,
                    string.IsNullOrWhiteSpace(_txtEmail.Text) ? null : _txtEmail.Text.Trim(),
                    pregunta,
                    respuesta);

                MessageBox.Show(FindForm(), $"{Localizacion("sistema.usuarioRegistrado")} (Id {id}).",
                    Localizacion("sistema.nuevoUsuario"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException ex)
            {
                _lblAviso.Text = ex.Message;
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "UsuarioNuevoForm");
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
