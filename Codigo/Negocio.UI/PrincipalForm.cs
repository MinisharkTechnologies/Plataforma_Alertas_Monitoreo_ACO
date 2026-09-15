using Services.DomainModel;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Ventana principal (shell) posterior al login: muestra la cabecera de sesión, el menú
    /// de módulos habilitados según los permisos del perfil (REQ-ARQ-006) y el área de
    /// contenido donde vivirán las pantallas de cada módulo. Permite cambiar el idioma en
    /// vivo (REQ-ARQ-001).
    /// </summary>
    public class PrincipalForm : Form
    {
        private static readonly string[] CodigosIdioma = { "es", "en", "zh-CN" };

        private readonly UsuarioAutenticado _sesion;
        private readonly Panel _panelCabecera = new();
        private readonly FlowLayoutPanel _flowCabecera = new();
        private readonly Label _lblApp = new();
        private readonly Label _lblSesion = new();
        private readonly Button _btnCerrarSesion = new();
        private readonly ComboBox _cmbIdioma = new();
        private readonly Panel _panelMenu = new();
        private readonly Label _lblMenuTitulo = new();
        private readonly FlowLayoutPanel _flowModulos = new();
        private readonly Panel _panelContenido = new();
        private readonly Label _lblModuloTitulo = new();
        private readonly Label _lblModuloDetalle = new();
        private readonly List<(Button Boton, string Clave)> _botonesModulo = new();
        private string? _claveModuloActual;
        private bool _actualizandoIdioma;

        public PrincipalForm(UsuarioAutenticado sesion)
        {
            _sesion = sesion ?? throw new ArgumentNullException(nameof(sesion));
            ConstruirInterfaz();
            ConstruirMenu();
            AplicarTextos();
        }

        private static string Texto(string clave) => LocalizationService.ObtenerTexto(clave);

        private void ConstruirInterfaz()
        {
            Text = "OpenRIN";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1024, 640);
            BackColor = Color.FromArgb(238, 246, 253);

            // ---- Cabecera ----
            _panelCabecera.Dock = DockStyle.Top;
            _panelCabecera.Height = 74;
            _panelCabecera.BackColor = Color.FromArgb(41, 98, 176);

            _lblApp.Location = new Point(22, 10);
            _lblApp.Size = new Size(300, 34);
            _lblApp.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            _lblApp.ForeColor = Color.White;
            _lblApp.Text = "OpenRIN";

            _lblSesion.Location = new Point(24, 46);
            _lblSesion.Size = new Size(640, 20);
            _lblSesion.Font = new Font("Segoe UI", 9.5F);
            _lblSesion.ForeColor = Color.FromArgb(214, 232, 250);

            _flowCabecera.Dock = DockStyle.Right;
            _flowCabecera.Width = 380;
            _flowCabecera.FlowDirection = FlowDirection.RightToLeft;
            _flowCabecera.Padding = new Padding(0, 18, 16, 0);
            _flowCabecera.BackColor = Color.FromArgb(41, 98, 176);
            _flowCabecera.WrapContents = false;

            _btnCerrarSesion.Size = new Size(130, 36);
            _btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            _btnCerrarSesion.FlatAppearance.BorderColor = Color.FromArgb(160, 195, 232);
            _btnCerrarSesion.BackColor = Color.FromArgb(57, 120, 198);
            _btnCerrarSesion.ForeColor = Color.White;
            _btnCerrarSesion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _btnCerrarSesion.Cursor = Cursors.Hand;
            _btnCerrarSesion.Click += BtnCerrarSesion_Click;

            _cmbIdioma.Size = new Size(170, 28);
            _cmbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbIdioma.Font = new Font("Segoe UI", 9.5F);
            _cmbIdioma.Margin = new Padding(10, 4, 6, 0);
            _cmbIdioma.SelectedIndexChanged += CmbIdioma_SelectedIndexChanged;

            _flowCabecera.Controls.Add(_btnCerrarSesion);
            _flowCabecera.Controls.Add(_cmbIdioma);

            _panelCabecera.Controls.Add(_lblApp);
            _panelCabecera.Controls.Add(_lblSesion);
            _panelCabecera.Controls.Add(_flowCabecera);

            // ---- Menú lateral ----
            _panelMenu.Dock = DockStyle.Left;
            _panelMenu.Width = 248;
            _panelMenu.BackColor = Color.White;

            _lblMenuTitulo.Location = new Point(16, 16);
            _lblMenuTitulo.Size = new Size(216, 24);
            _lblMenuTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _lblMenuTitulo.ForeColor = Color.FromArgb(41, 98, 176);

            _flowModulos.Location = new Point(0, 52);
            _flowModulos.Size = new Size(248, 700);
            _flowModulos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _flowModulos.FlowDirection = FlowDirection.TopDown;
            _flowModulos.WrapContents = false;
            _flowModulos.AutoScroll = true;
            _flowModulos.BackColor = Color.White;

            _panelMenu.Controls.Add(_lblMenuTitulo);
            _panelMenu.Controls.Add(_flowModulos);

            // ---- Contenido ----
            _panelContenido.Dock = DockStyle.Fill;
            _panelContenido.BackColor = Color.FromArgb(244, 249, 254);

            _lblModuloTitulo.Location = new Point(36, 30);
            _lblModuloTitulo.Size = new Size(900, 40);
            _lblModuloTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            _lblModuloTitulo.ForeColor = Color.FromArgb(30, 66, 120);

            _lblModuloDetalle.Location = new Point(38, 76);
            _lblModuloDetalle.Size = new Size(900, 24);
            _lblModuloDetalle.Font = new Font("Segoe UI", 10.5F);
            _lblModuloDetalle.ForeColor = Color.FromArgb(90, 110, 135);

            _panelContenido.Controls.Add(_lblModuloTitulo);
            _panelContenido.Controls.Add(_lblModuloDetalle);

            Controls.Add(_panelContenido);
            Controls.Add(_panelMenu);
            Controls.Add(_panelCabecera);
        }

        private void ConstruirMenu()
        {
            bool sysadmin = string.Equals(_sesion.Perfil, "sysadmin", StringComparison.OrdinalIgnoreCase);
            bool tiene(string permiso) => SeguridadService.TienePermiso(_sesion.Id, permiso);

            AgregarModulo("mod.pacientes", sysadmin || tiene("GESTION_PACIENTES") || tiene("HISTORIA_CLINICA"));
            AgregarModulo("panel.titulo", sysadmin || tiene("PANEL_VER"));
            AgregarModulo("mod.rin", sysadmin || tiene("RECEPCION_RIN") || tiene("PORTAL_REPORTAR_RIN"));
            AgregarModulo("mod.agenda", sysadmin || tiene("GESTION_AGENDA"));
            AgregarModulo("mod.seguimiento", sysadmin || tiene("SEGUIMIENTO_CLINICO"));
            AgregarModulo("mod.eventos", sysadmin || tiene("EVENTOS_ADVERSOS"));
            AgregarModulo("mod.reportes", sysadmin || tiene("REPORTES_VER"));
            AgregarModulo("mod.portal", sysadmin || tiene("PORTAL_REPORTAR_RIN") || tiene("PORTAL_VER_HISTORIAL"));
            AgregarModulo("mod.sistema", sysadmin);
        }

        private void AgregarModulo(string clave, bool permitido)
        {
            if (!permitido)
            {
                return;
            }

            var boton = new Button
            {
                Width = 210,
                Height = 44,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(14, 0, 0, 0),
                Margin = new Padding(14, 4, 12, 4),
                BackColor = Color.FromArgb(232, 242, 252),
                ForeColor = Color.FromArgb(28, 60, 105),
                Font = new Font("Segoe UI", 9.5F),
                Cursor = Cursors.Hand
            };
            boton.FlatAppearance.BorderColor = Color.FromArgb(202, 220, 240);
            boton.Click += (s, e) => MostrarModulo(clave);
            boton.MouseEnter += (s, e) => boton.BackColor = Color.FromArgb(214, 233, 250);
            boton.MouseLeave += (s, e) => boton.BackColor = Color.FromArgb(232, 242, 252);

            _botonesModulo.Add((boton, clave));
            _flowModulos.Controls.Add(boton);
        }

        private void MostrarModulo(string clave)
        {
            _claveModuloActual = clave;
            _lblModuloTitulo.Text = Texto(clave);
            _lblModuloDetalle.Text = Texto("shell.enConstruccion");
        }

        private void AplicarTextos()
        {
            Text = $"{Texto("app.nombre")} — {Texto("shell.titulo")}";
            _lblSesion.Text = $"{Texto("shell.sesion")} {_sesion.NombreCompleto} ({_sesion.Perfil})";
            _lblMenuTitulo.Text = Texto("shell.modulos");
            _btnCerrarSesion.Text = Texto("shell.cerrarSesion");

            foreach ((Button boton, string clave) in _botonesModulo)
            {
                boton.Text = Texto(clave);
            }

            if (_claveModuloActual == null)
            {
                _lblModuloTitulo.Text = Texto("shell.titulo");
                _lblModuloDetalle.Text = Texto("shell.seleccione");
            }
            else
            {
                MostrarModulo(_claveModuloActual);
            }

            _actualizandoIdioma = true;
            try
            {
                _cmbIdioma.Items.Clear();
                foreach (string codigo in CodigosIdioma)
                {
                    _cmbIdioma.Items.Add(Texto($"idioma.{codigo}"));
                }
                int indice = Array.IndexOf(CodigosIdioma, LocalizationService.IdiomaActual);
                _cmbIdioma.SelectedIndex = indice >= 0 ? indice : 0;
            }
            finally
            {
                _actualizandoIdioma = false;
            }
        }

        private void CmbIdioma_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_actualizandoIdioma || _cmbIdioma.SelectedIndex < 0)
            {
                return;
            }
            LocalizationService.EstablecerIdioma(CodigosIdioma[_cmbIdioma.SelectedIndex]);
            AplicarTextos();
        }

        private void BtnCerrarSesion_Click(object? sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(this, Texto("shell.confirmarCerrar"), Texto("shell.cerrarSesion"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
