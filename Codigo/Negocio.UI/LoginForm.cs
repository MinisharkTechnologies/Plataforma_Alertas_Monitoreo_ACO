using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Services.DomainModel;
using Services.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Pantalla de inicio de sesión: autentica contra el módulo de seguridad de Services
    /// (REQ-ARQ-006), muestra el logo institucional y permite cambiar el idioma en vivo
    /// (REQ-ARQ-001) y recuperar la contraseña con pregunta de seguridad.
    /// </summary>
    public partial class LoginForm : Form
    {
        private List<Idioma> _idiomasDisponibles = new();

        // Los controles que se ven en pantalla se declaran en LoginForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.
        private readonly Icon? _logoLogin = Recursos.CargarIcono(96);
        private bool _actualizandoIdioma;

        /// <summary>Sesión autenticada; disponible cuando el diálogo devuelve OK.</summary>
        public UsuarioAutenticado? Sesion { get; private set; }

        public LoginForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            // En tiempo de diseño (diseñador de Visual Studio) no se toca la base de datos:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            System.Drawing.Icon? icono = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (icono != null)
            {
                Icon = icono;
            }
            AplicarTextos();
        }

        private static string Texto(string clave) => LocalizationService.ObtenerTexto(clave);

        protected override void OnPaint(PaintEventArgs e)
        {
            using var pincel = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(196, 226, 250),
                Color.FromArgb(235, 246, 255),
                LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(pincel, ClientRectangle);

            // Logo institucional (carta de presentación), arriba a la derecha del título.
            if (_logoLogin != null)
            {
                e.Graphics.DrawIcon(_logoLogin, new Rectangle(336, 8, 92, 92));
            }

            // Títulos dibujados a mano: se funden con el degradé (sin cajas grises de fondo).
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (var fuenteTitulo = new Font("Segoe UI", 22F, FontStyle.Bold))
            using (var pincelTitulo = new SolidBrush(Color.FromArgb(27, 79, 138)))
            {
                e.Graphics.DrawString(_lblTitulo.Text, fuenteTitulo, pincelTitulo, 36, 24);
            }
            using (var fuenteSubtitulo = new Font("Segoe UI", 9.5F))
            using (var pincelSubtitulo = new SolidBrush(Color.FromArgb(74, 107, 138)))
            {
                e.Graphics.DrawString(_lblSubtitulo.Text, fuenteSubtitulo, pincelSubtitulo, 38, 68);
            }
            using (var fuenteVersion = new Font("Segoe UI", 8F))
            using (var pincelVersion = new SolidBrush(Color.FromArgb(110, 130, 150)))
            {
                e.Graphics.DrawString(_lblVersion.Text, fuenteVersion, pincelVersion, 38, 468);
            }
        }

        private void AplicarTextos()
        {
            Text = $"{Texto("app.nombre")} — {Texto("login.titulo")}";
            _lblTitulo.Text = Texto("app.nombre");
            _lblSubtitulo.Text = Texto("app.titulo");
            _lblUsuario.Text = Texto("login.usuario");
            _lblContrasena.Text = Texto("login.contrasena");
            _btnIngresar.Text = Texto("login.ingresar");
            _lnkRecuperar.Text = Texto("login.olvidoContrasena");
            _lblIdioma.Text = Texto("login.idioma");
            _lblVersion.Text = "OpenRIN · .NET 8 · v1.0";

            _actualizandoIdioma = true;
            try
            {
                _cmbIdioma.Items.Clear();
                _idiomasDisponibles = LocalizationService.Idiomas.ToList();
                foreach (Idioma idioma in _idiomasDisponibles)
                {
                    _cmbIdioma.Items.Add(idioma.Nombre);
                }
                int indice = _idiomasDisponibles.FindIndex(i => i.Codigo == LocalizationService.IdiomaActual);
                _cmbIdioma.SelectedIndex = indice >= 0 ? indice : 0;
            }
            finally
            {
                _actualizandoIdioma = false;
            }

            Invalidate();
        }

        private void CmbIdioma_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_actualizandoIdioma || _cmbIdioma.SelectedIndex < 0)
            {
                return;
            }
            LocalizationService.EstablecerIdioma(_idiomasDisponibles[_cmbIdioma.SelectedIndex].Codigo);
            AplicarTextos();
        }

        private void BtnIngresar_Click(object? sender, EventArgs e)
        {
            string usuario = _txtUsuario.Text.Trim();
            string contrasena = _txtContrasena.Text;
            if (usuario.Length == 0 || contrasena.Length == 0)
            {
                MostrarAdvertencia(Texto("login.campoObligatorio"));
                return;
            }

            _btnIngresar.Enabled = false;
            UseWaitCursor = true;
            try
            {
                Sesion = SeguridadService.Autenticar(usuario, contrasena);
                SesionActual.Instancia.Iniciar(Sesion);
                DialogResult = DialogResult.OK;
            }
            catch (UsuarioBloqueadoException ex)
            {
                MostrarAdvertencia(ex.Message);
                _txtContrasena.Clear();
            }
            catch (CredencialesInvalidasException ex)
            {
                MostrarAdvertencia(ex.Message);
                _txtContrasena.Clear();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "LoginForm", mostrarMensaje: false);
                MostrarAdvertencia(Texto("error.generico"));
                _txtContrasena.Clear();
            }
            finally
            {
                _btnIngresar.Enabled = true;
                UseWaitCursor = false;
            }
        }

        private void LnkRecuperar_Click(object? sender, EventArgs e)
        {
            using var recuperacion = new RecuperacionForm(_txtUsuario.Text.Trim());
            recuperacion.ShowDialog(this);
        }

        private void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(this, mensaje, Texto("login.titulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
