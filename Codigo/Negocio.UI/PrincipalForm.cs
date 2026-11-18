using System.Text;
using Negocio.BLL;
using Negocio.DAL.Context;
using Services.DomainModel;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Ventana principal (shell): cabecera de sesión con indicador de integridad (DVH/DVV),
    /// menú de módulos habilitados según los permisos del perfil (REQ-ARQ-006) y área de
    /// contenido donde se incrustan las pantallas de cada módulo (UserControls). Permite
    /// cambiar el idioma en vivo (REQ-ARQ-001).
    /// </summary>
    public partial class PrincipalForm : Form
    {
        private List<Idioma> _idiomasDisponibles = new();

        private readonly UsuarioAutenticado _sesion;
        // Los controles de la interfaz se declaran en PrincipalForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.
        // El menú de módulos se crea en tiempo de ejecución según los permisos.
        private readonly List<(Button Boton, string Clave)> _botonesModulo = new();
        private PanelTriajeControl? _controlTriaje;
        private PacientesControl? _controlPacientes;
        private RecepcionRINControl? _controlRecepcion;
        private AgendaControl? _controlAgenda;
        private SeguimientoControl? _controlSeguimiento;
        private EventosAdversosControl? _controlEventos;
        private ReportesControl? _controlReportes;
        private PortalControl? _controlPortal;
        private SistemaControl? _controlSistema;
        private string? _claveModuloActual;
        private bool _actualizandoIdioma;
        private int _problemasIntegridad = -1;

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public PrincipalForm()
        {
            InitializeComponent();
            _sesion = null!;
        }

        public PrincipalForm(UsuarioAutenticado sesion)
        {
            InitializeComponent();
            _sesion = sesion ?? throw new ArgumentNullException(nameof(sesion));

            // En tiempo de diseño no se tocan servicios ni la base de datos.
            if (Disenio.Activo)
            {
                return;
            }

            System.Drawing.Icon? icono = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (icono != null)
            {
                Icon = icono;
            }
            ConstruirMenu();
            AplicarTextos();
            VerificarIntegridad();
            HelpRequested += (s, e) => { MostrarAyuda(); e.Handled = true; };

            // Observer de localización (T05): al cambiar el idioma o editar sus leyendas,
            // las vistas se actualizan en caliente sin intervención manual.
            LocalizationService.Suscribir(AlCambiarIdioma);
            FormClosed += (s, e) => LocalizationService.Desuscribir(AlCambiarIdioma);
        }

        /// <summary>Abre la ayuda en línea (botón de ayuda de la cabecera).</summary>
        private void BtnAyuda_Click(object? sender, EventArgs e) => MostrarAyuda();

        /// <summary>Observador de localización (T05): reaplica los textos al cambiar el idioma.</summary>
        private void AlCambiarIdioma()
        {
            AplicarTextos();
        }

        private static string Texto(string clave) => LocalizationService.ObtenerTexto(clave);

        private void ConstruirMenu()
        {
            bool sysadmin = string.Equals(_sesion.Perfil, "sysadmin", StringComparison.OrdinalIgnoreCase);
            bool tiene(string permiso) => SeguridadService.TienePermiso(_sesion.Id, permiso);

            AgregarModulo("mod.pacientes", sysadmin || tiene("PA002") || tiene("PA006"));
            AgregarModulo("panel.titulo", sysadmin || tiene("PA001"));
            // Recepción de RIN es una pantalla operativa del personal (no del portal del paciente).
            AgregarModulo("mod.rin", sysadmin || tiene("PA004"));
            AgregarModulo("mod.agenda", sysadmin || tiene("PA003"));
            AgregarModulo("mod.seguimiento", sysadmin || tiene("PA007"));
            AgregarModulo("mod.eventos", sysadmin || tiene("PA005"));
            AgregarModulo("mod.reportes", sysadmin || tiene("PA008"));
            AgregarModulo("mod.portal", sysadmin || tiene("PO001") || tiene("PO002"));
            AgregarModulo("mod.sistema", sysadmin || tiene("SI001"));
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
            _controlTriaje?.Pausar();
            _claveModuloActual = clave;
            _lblModuloTitulo.Text = Texto(clave);

            if (clave == "panel.titulo")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlTriaje ??= new PanelTriajeControl();
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlTriaje);
                _controlTriaje.Reanudar();
            }
            else if (clave == "mod.pacientes")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlPacientes ??= new PacientesControl(_sesion.Id, _sesion.NombreUsuario);
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlPacientes);
                _controlPacientes.Recargar();
            }
            else if (clave == "mod.rin")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlRecepcion ??= new RecepcionRINControl(_sesion.NombreUsuario);
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlRecepcion);
                _controlRecepcion.RefrescarTextos();
            }
            else if (clave == "mod.agenda")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlAgenda ??= new AgendaControl(_sesion.Id, _sesion.NombreUsuario);
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlAgenda);
                _controlAgenda.Recargar();
            }
            else if (clave == "mod.seguimiento")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlSeguimiento ??= new SeguimientoControl(_sesion.Id, _sesion.NombreUsuario);
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlSeguimiento);
                _controlSeguimiento.Recargar();
            }
            else if (clave == "mod.eventos")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlEventos ??= new EventosAdversosControl(_sesion.NombreUsuario);
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlEventos);
                _controlEventos.Recargar();
            }
            else if (clave == "mod.reportes")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlReportes ??= new ReportesControl(_sesion.NombreUsuario);
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlReportes);
                _controlReportes.Recargar();
            }
            else if (clave == "mod.portal")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlPortal ??= new PortalControl(_sesion.Id, _sesion.NombreUsuario);
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlPortal);
                _controlPortal.Recargar();
            }
            else if (clave == "mod.sistema")
            {
                _lblModuloDetalle.Text = string.Empty;
                _controlSistema ??= new SistemaControl(true);
                _panelVista.Controls.Clear();
                _panelVista.Controls.Add(_controlSistema);
                _controlSistema.Recargar();
            }
            else
            {
                _lblModuloDetalle.Text = Texto("shell.enConstruccion");
                _panelVista.Controls.Clear();
            }
        }

        /// <summary>
        /// Verifica la integridad (DVH/DVV) al iniciar sesión: actualiza el indicador de la
        /// cabecera y, si hay problemas, los informa con su detalle.
        /// </summary>
        private void VerificarIntegridad()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                ResultadoAuditoria resultado = new IntegridadLogic(contexto).Auditar();
                _problemasIntegridad = resultado.Problemas.Count;
                ActualizarIndicadorIntegridad();

                if (_problemasIntegridad > 0)
                {
                    var detalle = new StringBuilder();
                    detalle.AppendLine(Texto("integridad.mensaje"));
                    detalle.AppendLine();
                    foreach (string problema in resultado.Problemas.Take(10))
                    {
                        detalle.AppendLine("• " + problema);
                    }
                    if (resultado.Problemas.Count > 10)
                    {
                        detalle.AppendLine($"… (+{resultado.Problemas.Count - 10})");
                    }
                    MessageBox.Show(this, detalle.ToString(), Texto("integridad.titulo"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "PrincipalForm", mostrarMensaje: false);
                _problemasIntegridad = -1;
                ActualizarIndicadorIntegridad();
            }
        }

        private void ActualizarIndicadorIntegridad()
        {
            if (_problemasIntegridad < 0)
            {
                _lblIntegridad.Text = "—";
                _lblIntegridad.ForeColor = Color.FromArgb(200, 214, 230);
            }
            else if (_problemasIntegridad == 0)
            {
                _lblIntegridad.Text = Texto("integridad.ok");
                _lblIntegridad.ForeColor = Color.FromArgb(190, 245, 205);
            }
            else
            {
                _lblIntegridad.Text = $"{Texto("integridad.alerta")} {_problemasIntegridad}";
                _lblIntegridad.ForeColor = Color.FromArgb(255, 190, 190);
            }
        }

        /// <summary>D02 - Ayuda en línea: abre el archivo OpenRIN-Ayuda.chm en el tema del módulo activo (también con F1).</summary>
        private void MostrarAyuda()
        {
            string archivo = Path.Combine(AppContext.BaseDirectory, "OpenRIN-Ayuda.chm");
            if (!File.Exists(archivo))
            {
                MessageBox.Show(Texto("ayuda.noEncontrada"), Texto("app.nombre"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string tema = _claveModuloActual switch
            {
                "mod.pacientes" => "pacientes.htm",
                "panel.titulo" => "panel.htm",
                "mod.rin" => "rin.htm",
                "mod.agenda" => "agenda.htm",
                "mod.seguimiento" => "seguimiento.htm",
                "mod.eventos" => "eventos.htm",
                "mod.reportes" => "reportes.htm",
                "mod.portal" => "portal.htm",
                "mod.sistema" => "sistema.htm",
                _ => "inicio.htm"
            };
            Help.ShowHelp(this, archivo, HelpNavigator.Topic, tema);
        }

        private void AplicarTextos()
        {
            Text = $"{Texto("app.nombre")} — {Texto("shell.titulo")}";
            _lblSesion.Text = $"{Texto("shell.sesion")} {_sesion.NombreCompleto} ({_sesion.Perfil})";
            _lblMenuTitulo.Text = Texto("shell.modulos");
            _btnCerrarSesion.Text = Texto("shell.cerrarSesion");
            _btnAyuda.Text = Texto("shell.ayuda");

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

            _controlTriaje?.RefrescarTextos();
            _controlPacientes?.RefrescarTextos();
            _controlAgenda?.RefrescarTextos();
            _controlSeguimiento?.RefrescarTextos();
            _controlEventos?.RefrescarTextos();
            _controlReportes?.RefrescarTextos();
            _controlPortal?.RefrescarTextos();
            _controlSistema?.RefrescarTextos();
            ActualizarIndicadorIntegridad();

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
        }

        private void CmbIdioma_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_actualizandoIdioma || _cmbIdioma.SelectedIndex < 0)
            {
                return;
            }
            LocalizationService.EstablecerIdioma(_idiomasDisponibles[_cmbIdioma.SelectedIndex].Codigo);
        }

        private void BtnCerrarSesion_Click(object? sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(this, Texto("shell.confirmarCerrar"), Texto("shell.cerrarSesion"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                SesionActual.Instancia.Cerrar();
                Application.Restart();
            }
        }
    }
}
