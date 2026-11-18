using System.Text;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;
using Negocio.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Recepción de RIN (REQ-FUNC-004/005): búsqueda del paciente por documento, carga manual
    /// del valor (canal digital o telefónico) y resultado inmediato del triaje: clasificación
    /// de criticidad, reclasificación por tendencia peligrosa y alerta urgente generada.
    /// </summary>
    public partial class RecepcionRINControl : UserControl
    {
        private readonly string _nombreUsuario = string.Empty;

        // Los controles que se ven en pantalla se declaran en RecepcionRINControl.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.
        private Paciente? _pacienteActual;
        private HistoriaClinica? _historiaActual;

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public RecepcionRINControl()
        {
            InitializeComponent();
        }

        public RecepcionRINControl(string nombreUsuario) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se tocan servicios ni la base de datos:
            // alcanza con que los controles se hayan creado para que el control se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            _nombreUsuario = nombreUsuario;

            AplicarTextos();
            _lblResultado.Text = Localizacion("rin.resultadoSinDatos");
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Reaplica textos por cambio de idioma y revalida la búsqueda activa.</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            if (_pacienteActual != null)
            {
                BuscarPaciente();
            }
        }

        // Manejadores de eventos de la interfaz (se conectan desde RecepcionRINControl.Designer.cs).

        private void TxtDni_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarPaciente();
            }
        }

        private void BtnBuscar_Click(object? sender, EventArgs e) => BuscarPaciente();

        private void BtnReportar_Click(object? sender, EventArgs e) => ReportarValor();

        private void AplicarTextos()
        {
            _lblIdentificacion.Text = Localizacion("rin.identificacion");
            _btnBuscar.Text = Localizacion("comun.buscar");
            _lblValor.Text = Localizacion("rin.valor");
            _lblFecha.Text = Localizacion("rin.fecha");
            _lblCanal.Text = Localizacion("rin.canal");
            _btnReportar.Text = Localizacion("rin.reportar");
            _lblHistorial.Text = Localizacion("rin.historial");

            int seleccionado = _cmbCanal.SelectedIndex < 0 ? 0 : _cmbCanal.SelectedIndex;
            _cmbCanal.Items.Clear();
            _cmbCanal.Items.Add(Localizacion("rin.canal.digital"));
            _cmbCanal.Items.Add(Localizacion("rin.canal.telefonico"));
            _cmbCanal.SelectedIndex = seleccionado;

            _grillaHistorial.Columns["fecha"].HeaderText = Localizacion("rin.columna.fecha");
            _grillaHistorial.Columns["valor"].HeaderText = Localizacion("rin.columna.valor");
            _grillaHistorial.Columns["canal"].HeaderText = Localizacion("rin.columna.canal");
            _grillaHistorial.Columns["criticidad"].HeaderText = Localizacion("panel.columna.criticidad");
        }

        private string CriticidadTexto(NivelCriticidad nivel) => nivel switch
        {
            NivelCriticidad.Alta => Localizacion("panel.criticidadAlta"),
            NivelCriticidad.Media => Localizacion("panel.criticidadMedia"),
            _ => Localizacion("panel.criticidadBaja")
        };

        private string CanalTexto(CanalReporteRIN canal)
            => canal == CanalReporteRIN.Telefonico ? Localizacion("rin.canal.telefonico") : Localizacion("rin.canal.digital");

        private void BuscarPaciente()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                _pacienteActual = new PacienteLogic(contexto).BuscarPorDNI(_txtDni.Text.Trim());
                if (_pacienteActual == null)
                {
                    _historiaActual = null;
                    _lblFicha.Text = string.Empty;
                    _lblAviso.Text = Localizacion("rin.pacienteNoEncontrado");
                    _grillaHistorial.Rows.Clear();
                    ActualizarHabilitacion();
                    return;
                }

                _historiaActual = new HistoriaClinicaLogic(contexto).ObtenerPorPaciente(_pacienteActual.Id);
                MedicionRIN? ultima = new MedicionRINLogic(contexto).ObtenerUltima(_pacienteActual.Id);
                MostrarFicha(_pacienteActual, _historiaActual, ultima);
                ActualizarHabilitacion();
                CargarHistorial();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "RecepcionRIN", mostrarMensaje: false);
                _lblAviso.Text = Localizacion("error.generico");
            }
        }

        private void MostrarFicha(Paciente paciente, HistoriaClinica? hc, MedicionRIN? ultima)
        {
            _lblAviso.Text = string.Empty;
            var texto = new StringBuilder();
            texto.AppendLine($"👤 {paciente.NombreCompleto}");
            texto.AppendLine($"{Localizacion("pacientes.documento")}: {paciente.DNI}");
            texto.AppendLine($"{Localizacion("pacientes.estado")}: " +
                (paciente.Estado == EstadoPaciente.Activo ? Localizacion("pacientes.estadoActivo") : Localizacion("pacientes.estadoInactivo")));
            texto.AppendLine();
            texto.AppendLine($"📋 {Localizacion("hc.titulo")}");
            if (hc == null)
            {
                texto.AppendLine($"— {Localizacion("hc.sinConfigurar")}");
            }
            else
            {
                texto.AppendLine($"{Localizacion("rin.rango")}: {hc.LimiteInferiorRIN:0.00} – {hc.LimiteSuperiorRIN:0.00}");
                texto.AppendLine($"{Localizacion("hc.medicamento")}: {hc.Medicamento} — {hc.Dosis}");
                texto.AppendLine($"{Localizacion("hc.periodicidad")}: {hc.PeriodicidadDias}");
            }
            texto.AppendLine();
            texto.AppendLine($"📈 {Localizacion("rin.ultimaMedicion")}");
            if (ultima == null)
            {
                texto.AppendLine($"— {Localizacion("rin.sinMediciones")}");
            }
            else
            {
                string criticidad = ultima.NivelCriticidad == null
                    ? Localizacion("panel.sinDatos")
                    : CriticidadTexto(ultima.NivelCriticidad.Value);
                texto.AppendLine($"RIN {ultima.ValorRIN:0.00} · {ultima.FechaMedicion:dd/MM/yyyy} · {criticidad}" +
                                 (ultima.PorTendenciaPeligrosa ? " ⚠" : string.Empty));
            }
            _lblFicha.Text = texto.ToString();
        }

        private void ActualizarHabilitacion()
        {
            bool activo = _pacienteActual?.Estado == EstadoPaciente.Activo;
            bool conHistoria = _historiaActual != null;
            bool habilitado = _pacienteActual != null && activo && conHistoria;

            _numValor.Enabled = habilitado;
            _dtpFecha.Enabled = habilitado;
            _cmbCanal.Enabled = habilitado;
            _btnReportar.Enabled = habilitado;

            if (_pacienteActual != null && !activo)
            {
                _lblAviso.Text = Localizacion("rin.pacienteInactivo");
            }
            else if (_pacienteActual != null && !conHistoria)
            {
                _lblAviso.Text = Localizacion("rin.sinHistoria");
            }
        }

        private void ReportarValor()
        {
            if (_pacienteActual == null || _historiaActual == null)
            {
                return;
            }

            try
            {
                using var contexto = new NegocioDbContext();
                var medicion = new MedicionRIN
                {
                    IdPaciente = _pacienteActual.Id,
                    ValorRIN = _numValor.Value,
                    FechaMedicion = _dtpFecha.Value.Date,
                    Canal = _cmbCanal.SelectedIndex == 1 ? CanalReporteRIN.Telefonico : CanalReporteRIN.Digital
                };

                ResultadoReporteRIN resultado = new MedicionRINLogic(contexto).Reportar(medicion, _nombreUsuario);
                MostrarResultado(resultado);

                MedicionRIN? ultima = new MedicionRINLogic(contexto).ObtenerUltima(_pacienteActual.Id);
                MostrarFicha(_pacienteActual, _historiaActual, ultima);
                CargarHistorial();
            }
            catch (ValidacionNegocioException ex)
            {
                _lblResultado.ForeColor = Color.FromArgb(180, 40, 40);
                _lblResultado.Text = string.Join(Environment.NewLine, ex.Errores);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "RecepcionRIN");
            }
        }

        private void MostrarResultado(ResultadoReporteRIN resultado)
        {
            var texto = new StringBuilder();
            texto.AppendLine($"{Localizacion("rin.resultado")}: RIN {resultado.Medicion.ValorRIN:0.00} — " +
                             $"{CriticidadTexto(resultado.Medicion.NivelCriticidad ?? NivelCriticidad.Baja)}");
            if (resultado.Medicion.PorTendenciaPeligrosa)
            {
                texto.AppendLine(Localizacion("rin.tendencia"));
            }
            if (resultado.AlertaGenerada != null)
            {
                texto.AppendLine(Localizacion("rin.alertaGenerada"));
            }

            _lblResultado.Text = texto.ToString().TrimEnd();
            _lblResultado.ForeColor = resultado.Medicion.NivelCriticidad switch
            {
                NivelCriticidad.Alta => Color.FromArgb(180, 30, 30),
                NivelCriticidad.Media => Color.FromArgb(190, 120, 20),
                _ => Color.FromArgb(30, 110, 60)
            };
        }

        private void CargarHistorial()
        {
            _grillaHistorial.Rows.Clear();
            if (_pacienteActual == null)
            {
                return;
            }

            using var contexto = new NegocioDbContext();
            var historial = new MedicionRINLogic(contexto).ObtenerHistorial(_pacienteActual.Id).Take(10).ToList();
            foreach (MedicionRIN medicion in historial)
            {
                string criticidad = medicion.NivelCriticidad == null
                    ? Localizacion("panel.sinDatos")
                    : CriticidadTexto(medicion.NivelCriticidad.Value) + (medicion.PorTendenciaPeligrosa ? " ⚠" : string.Empty);

                int indice = _grillaHistorial.Rows.Add(
                    medicion.FechaMedicion.ToString("dd/MM/yyyy"),
                    medicion.ValorRIN.ToString("0.00"),
                    CanalTexto(medicion.Canal),
                    criticidad);

                DataGridViewCell celda = _grillaHistorial.Rows[indice].Cells[3];
                (Color fondo, Color texto) = medicion.NivelCriticidad switch
                {
                    NivelCriticidad.Alta => (Color.FromArgb(200, 45, 45), Color.White),
                    NivelCriticidad.Media => (Color.FromArgb(232, 163, 61), Color.White),
                    NivelCriticidad.Baja => (Color.FromArgb(46, 125, 70), Color.White),
                    _ => (Color.FromArgb(130, 140, 150), Color.White)
                };
                celda.Style.BackColor = fondo;
                celda.Style.ForeColor = texto;
                celda.Style.SelectionBackColor = fondo;
                celda.Style.SelectionForeColor = texto;
                celda.Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
        }
    }
}
