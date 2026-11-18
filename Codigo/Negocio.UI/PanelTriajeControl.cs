using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Panel de Monitoreo / Triaje (REQ-FUNC-006): ranking en tiempo real de pacientes
    /// activos ordenado por criticidad y antigüedad del último reporte, con indicadores
    /// visuales (colores por criticidad, alerta activa y tendencia peligrosa).
    /// Se refresca automáticamente cada 30 segundos y de forma manual con "Actualizar".
    /// </summary>
    public partial class PanelTriajeControl : UserControl
    {
        // Los controles que se ven en pantalla se declaran en PanelTriajeControl.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public PanelTriajeControl()
        {
            InitializeComponent();

            // En tiempo de diseño (diseñador de Visual Studio) no se toca la base de datos:
            // alcanza con que los controles se hayan creado para que el control se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            AplicarTextos();
            CargarDatos();
            _temporizador.Start();
        }

        private static string Texto(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Detiene el refresco automático (al ocultar el panel).</summary>
        public void Pausar() => _temporizador.Stop();

        /// <summary>Reanuda el refresco automático y recarga los datos (al mostrar el panel).</summary>
        public void Reanudar()
        {
            CargarDatos();
            _temporizador.Start();
        }

        /// <summary>Reaplica los textos según el idioma activo (hot-swap).</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            CargarDatos();
        }

        // Manejadores de eventos de la interfaz (se conectan desde PanelTriajeControl.Designer.cs).

        private void BtnActualizar_Click(object? sender, EventArgs e) => CargarDatos();

        private void Temporizador_Tick(object? sender, EventArgs e) => CargarDatos();

        private void AplicarTextos()
        {
            _btnActualizar.Text = Texto("panel.actualizar");
            _grilla.Columns["paciente"].HeaderText = Texto("panel.columna.paciente");
            _grilla.Columns["documento"].HeaderText = Texto("panel.columna.documento");
            _grilla.Columns["ultimoRin"].HeaderText = Texto("panel.columna.ultimoRin");
            _grilla.Columns["fecha"].HeaderText = Texto("panel.columna.fecha");
            _grilla.Columns["dias"].HeaderText = Texto("panel.columna.dias");
            _grilla.Columns["criticidad"].HeaderText = Texto("panel.columna.criticidad");
            _grilla.Columns["alerta"].HeaderText = Texto("panel.columna.alerta");

            _panelLeyenda.Controls.Clear();
            var lblLeyenda = new Label
            {
                Text = Texto("panel.leyenda"),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 85, 115),
                Margin = new Padding(0, 6, 8, 0)
            };
            _panelLeyenda.Controls.Add(lblLeyenda);
            AgregarLeyenda(Color.FromArgb(200, 45, 45), Texto("panel.criticidadAlta"));
            AgregarLeyenda(Color.FromArgb(232, 163, 61), Texto("panel.criticidadMedia"));
            AgregarLeyenda(Color.FromArgb(46, 125, 70), Texto("panel.criticidadBaja"));
            AgregarLeyenda(Color.FromArgb(130, 140, 150), Texto("panel.sinDatos"));
        }

        private void AgregarLeyenda(Color color, string texto)
        {
            var chip = new Label
            {
                Size = new Size(16, 16),
                BackColor = color,
                Margin = new Padding(0, 6, 4, 0)
            };
            var etiqueta = new Label
            {
                Text = texto,
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(60, 85, 115),
                Margin = new Padding(0, 6, 16, 0)
            };
            _panelLeyenda.Controls.Add(chip);
            _panelLeyenda.Controls.Add(etiqueta);
        }

        private void CargarDatos()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                List<FilaPanelMonitoreo> filas = new PanelMonitoreoLogic(contexto).ObtenerPanel();

                _grilla.Rows.Clear();
                foreach (FilaPanelMonitoreo fila in filas)
                {
                    string criticidad = fila.NivelCriticidad == null
                        ? Texto("panel.sinDatos")
                        : Texto(fila.NivelCriticidad == NivelCriticidad.Alta ? "panel.criticidadAlta"
                            : fila.NivelCriticidad == NivelCriticidad.Media ? "panel.criticidadMedia"
                            : "panel.criticidadBaja") +
                          (fila.PorTendenciaPeligrosa ? " ⚠" : "");

                    int indice = _grilla.Rows.Add(
                        fila.NombreCompleto,
                        fila.DNI,
                        fila.UltimoValorRIN?.ToString("0.00") ?? "—",
                        fila.FechaUltimoReporte?.ToString("dd/MM/yyyy") ?? "—",
                        fila.DiasDesdeUltimoReporte?.ToString() ?? "—",
                        criticidad,
                        fila.TieneAlertaActiva ? "🔔" : "");

                    AplicarEstilo(fila, _grilla.Rows[indice]);
                }

                _lblRefresco.Text = Texto("panel.refresco") + " " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "PanelTriaje", mostrarMensaje: false);
                _lblRefresco.Text = Texto("error.generico");
            }
        }

        private static void AplicarEstilo(FilaPanelMonitoreo fila, DataGridViewRow filaGrilla)
        {
            DataGridViewCell celdaCriticidad = filaGrilla.Cells[5];
            celdaCriticidad.Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            Color colorTexto = Color.White;
            Color colorFondo = Color.FromArgb(130, 140, 150);
            switch (fila.NivelCriticidad)
            {
                case NivelCriticidad.Alta:
                    colorFondo = Color.FromArgb(200, 45, 45);
                    filaGrilla.DefaultCellStyle.BackColor = Color.FromArgb(253, 231, 231);
                    break;
                case NivelCriticidad.Media:
                    colorFondo = Color.FromArgb(232, 163, 61);
                    break;
                case NivelCriticidad.Baja:
                    colorFondo = Color.FromArgb(46, 125, 70);
                    break;
            }

            celdaCriticidad.Style.BackColor = colorFondo;
            celdaCriticidad.Style.ForeColor = colorTexto;
            celdaCriticidad.Style.SelectionBackColor = colorFondo;
            celdaCriticidad.Style.SelectionForeColor = colorTexto;
        }
    }
}
