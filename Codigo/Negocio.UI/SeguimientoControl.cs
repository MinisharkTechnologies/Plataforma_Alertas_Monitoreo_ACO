using Microsoft.EntityFrameworkCore;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;
using Negocio.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Seguimiento clínico (REQ-FUNC-010): casos con reporte vencido (alertas de ausencia
    /// activas), protocolo progresivo de contacto (umbral de intentos fallidos → escalado al
    /// médico) y registro de decisiones clínicas (que pueden actualizar la periodicidad de la HC).
    /// </summary>
    public partial class SeguimientoControl : UserControl
    {
        /// <summary>Fila del listado de casos en seguimiento.</summary>
        private sealed class FilaCaso
        {
            public int IdPaciente { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public DateTime? UltimoReporte { get; set; }
            public int DiasVencido { get; set; }
            public int Intentos { get; set; }
            public bool Escalada { get; set; }
        }

        private readonly int _idUsuario;
        private readonly string _nombreUsuario = string.Empty;
        private readonly List<FilaCaso> _casos = new();

        // Los controles de la interfaz se declaran en SeguimientoControl.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        private int _idPacienteSeleccionado;
        private bool _recargando;

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public SeguimientoControl()
        {
            InitializeComponent();
        }

        public SeguimientoControl(int idUsuario, string nombreUsuario) : this()
        {
            _idUsuario = idUsuario;
            _nombreUsuario = nombreUsuario;

            // En tiempo de diseño no se toca la base de datos.
            if (Disenio.Activo)
            {
                return;
            }

            AplicarTextos();
            Recargar();
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Recarga el listado de casos y el detalle (al entrar al módulo).</summary>
        public void Recargar()
        {
            try
            {
                _recargando = true;
                CargarCasos();
            }
            finally
            {
                _recargando = false;
            }
        }

        /// <summary>Reaplica textos por cambio de idioma y recarga.</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            Recargar();
        }

        /// <summary>Detecta los plazos vencidos y recarga.</summary>
        private void BtnDetectar_Click(object? sender, EventArgs e) => DetectarPlazos();

        /// <summary>Al cambiar la fila seleccionada, muestra el detalle del caso.</summary>
        private void GrillaCasos_SelectionChanged(object? sender, EventArgs e)
        {
            if (_recargando || _grillaCasos.SelectedRows.Count == 0)
            {
                return;
            }
            int indice = _grillaCasos.SelectedRows[0].Index;
            if (indice >= 0 && indice < _casos.Count)
            {
                CargarDetalle(_casos[indice].IdPaciente);
            }
        }

        /// <summary>Habilita la periodicidad solo cuando la decisión es cambiarla.</summary>
        private void CmbDecision_SelectedIndexChanged(object? sender, EventArgs e) => ActualizarPeriodicidadHabilitada();

        /// <summary>Registra el intento de contacto del caso seleccionado.</summary>
        private void BtnRegistrarIntento_Click(object? sender, EventArgs e) => RegistrarIntento();

        /// <summary>Registra la decisión clínica del caso seleccionado.</summary>
        private void BtnRegistrarDecision_Click(object? sender, EventArgs e) => RegistrarDecision();

        private void AplicarTextos()
        {
            _btnDetectar.Text = Localizacion("seguimiento.detectar");
            _grillaCasos.Columns["paciente"].HeaderText = Localizacion("panel.columna.paciente");
            _grillaCasos.Columns["ultimo"].HeaderText = Localizacion("seguimiento.columna.ultimoReporte");
            _grillaCasos.Columns["dias"].HeaderText = Localizacion("seguimiento.columna.diasVencido");
            _grillaCasos.Columns["intentos"].HeaderText = Localizacion("seguimiento.columna.intentos");
            _grillaCasos.Columns["protocolo"].HeaderText = Localizacion("seguimiento.columna.protocolo");

            _lblContactoSeccion.Text = Localizacion("seguimiento.contacto");
            _lblTipoContacto.Text = Localizacion("seguimiento.tipoContacto");
            _lblResultado.Text = Localizacion("seguimiento.resultado");
            _lblObservaciones.Text = Localizacion("agenda.columna.observaciones");
            _btnRegistrarIntento.Text = Localizacion("seguimiento.registrarIntento");

            int tipoPrevio = _cmbTipoContacto.SelectedIndex;
            _cmbTipoContacto.Items.Clear();
            _cmbTipoContacto.Items.Add(Localizacion("seguimiento.contacto.llamado"));
            _cmbTipoContacto.Items.Add(Localizacion("seguimiento.contacto.mensaje"));
            _cmbTipoContacto.Items.Add(Localizacion("seguimiento.contacto.correo"));
            _cmbTipoContacto.Items.Add(Localizacion("seguimiento.contacto.otro"));
            _cmbTipoContacto.SelectedIndex = tipoPrevio < 0 ? 0 : tipoPrevio;

            int resultadoPrevio = _cmbResultado.SelectedIndex;
            _cmbResultado.Items.Clear();
            _cmbResultado.Items.Add(Localizacion("seguimiento.resultado.exitoso"));
            _cmbResultado.Items.Add(Localizacion("seguimiento.resultado.fallido"));
            // Por defecto 'Fallido': el caso típico del protocolo es la llamada sin respuesta.
            _cmbResultado.SelectedIndex = resultadoPrevio < 0 ? 1 : resultadoPrevio;

            _lblDecisionSeccion.Text = Localizacion("seguimiento.decision");
            _lblDecision.Text = Localizacion("seguimiento.decision");
            _lblPeriodicidad.Text = Localizacion("seguimiento.nuevaPeriodicidad");
            _lblDetalleDecision.Text = Localizacion("seguimiento.detalleDecision");
            _btnRegistrarDecision.Text = Localizacion("seguimiento.registrarDecision");

            int decisionPrevia = _cmbDecision.SelectedIndex;
            _cmbDecision.Items.Clear();
            _cmbDecision.Items.Add(Localizacion("seguimiento.dec.contactar"));
            _cmbDecision.Items.Add(Localizacion("seguimiento.dec.visita"));
            _cmbDecision.Items.Add(Localizacion("seguimiento.dec.periodicidad"));
            _cmbDecision.Items.Add(Localizacion("seguimiento.dec.nocontactable"));
            _cmbDecision.SelectedIndex = decisionPrevia < 0 ? 0 : decisionPrevia;

            _lblHistorial.Text = Localizacion("seguimiento.historial");
            _grillaHistorial.Columns["fecha"].HeaderText = Localizacion("rin.columna.fecha");
            _grillaHistorial.Columns["tipo"].HeaderText = Localizacion("seguimiento.tipoContacto");
            _grillaHistorial.Columns["resultado"].HeaderText = Localizacion("seguimiento.resultado");
            _grillaHistorial.Columns["decision"].HeaderText = Localizacion("seguimiento.columna.decision");
            _grillaHistorial.Columns["observaciones"].HeaderText = Localizacion("agenda.columna.observaciones");
        }

        private string TipoTexto(TipoContacto tipo) => tipo switch
        {
            TipoContacto.Llamado => Localizacion("seguimiento.contacto.llamado"),
            TipoContacto.Mensaje => Localizacion("seguimiento.contacto.mensaje"),
            TipoContacto.Correo => Localizacion("seguimiento.contacto.correo"),
            _ => Localizacion("seguimiento.contacto.otro")
        };

        private string ResultadoTexto(ResultadoContacto resultado)
            => Localizacion(resultado == ResultadoContacto.Exitoso ? "seguimiento.resultado.exitoso" : "seguimiento.resultado.fallido");

        private string DecisionTexto(DecisionClinica decision) => decision switch
        {
            DecisionClinica.ContactarPersonalmente => Localizacion("seguimiento.dec.contactar"),
            DecisionClinica.VisitaDomiciliaria => Localizacion("seguimiento.dec.visita"),
            DecisionClinica.CambiarPeriodicidad => Localizacion("seguimiento.dec.periodicidad"),
            _ => Localizacion("seguimiento.dec.nocontactable")
        };

        private void CargarCasos()
        {
            using var contexto = new NegocioDbContext();

            var alertas = contexto.Alertas.AsNoTracking()
                .Where(a => a.Tipo == TipoAlerta.ReporteAusente && a.Estado == EstadoAlerta.Activa)
                .OrderByDescending(a => a.FechaGeneracion)
                .ToList();
            Dictionary<int, string> dictPacientes = contexto.Pacientes.AsNoTracking()
                .ToDictionary(p => p.Id, p => p.NombreCompleto);

            _casos.Clear();
            foreach (Alerta alerta in alertas)
            {
                if (!dictPacientes.TryGetValue(alerta.IdPaciente, out string? nombre))
                {
                    continue;
                }
                HistoriaClinica? hc = contexto.HistoriasClinicas.AsNoTracking()
                    .FirstOrDefault(h => h.IdPaciente == alerta.IdPaciente);
                DateTime? ultimo = contexto.MedicionesRIN.AsNoTracking()
                    .Where(m => m.IdPaciente == alerta.IdPaciente)
                    .OrderByDescending(m => m.FechaMedicion).ThenByDescending(m => m.Id)
                    .Select(m => (DateTime?)m.FechaMedicion)
                    .FirstOrDefault();
                DateTime fechaBase = ultimo?.Date ?? hc?.FechaConfiguracion.Date ?? alerta.FechaGeneracion.Date;
                int periodicidad = hc?.PeriodicidadDias ?? 30;
                int dias = Math.Max(0, (int)(DateTime.Today - fechaBase.AddDays(periodicidad)).TotalDays);
                int intentos = contexto.Seguimientos.AsNoTracking()
                    .Count(s => s.IdPaciente == alerta.IdPaciente &&
                                s.Resultado == ResultadoContacto.Fallido &&
                                s.FechaRegistro >= alerta.FechaGeneracion);

                _casos.Add(new FilaCaso
                {
                    IdPaciente = alerta.IdPaciente,
                    Nombre = nombre,
                    UltimoReporte = ultimo,
                    DiasVencido = dias,
                    Intentos = intentos,
                    Escalada = alerta.EscaladaAMedico
                });
            }

            _grillaCasos.Rows.Clear();
            foreach (FilaCaso caso in _casos)
            {
                int indice = _grillaCasos.Rows.Add(
                    caso.Nombre,
                    caso.UltimoReporte?.ToString("dd/MM/yyyy") ?? "—",
                    caso.DiasVencido,
                    caso.Intentos,
                    caso.Escalada ? Localizacion("seguimiento.protocolo.escalada") : Localizacion("seguimiento.protocolo.enCurso"));
                if (caso.Escalada)
                {
                    _grillaCasos.Rows[indice].DefaultCellStyle.ForeColor = Color.FromArgb(180, 30, 30);
                    _grillaCasos.Rows[indice].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
            }

            _lblSinCasos.Text = _casos.Count == 0 ? Localizacion("seguimiento.sinPendientes") : string.Empty;

            if (_casos.Count == 0)
            {
                _idPacienteSeleccionado = 0;
                LimpiarDetalle();
                return;
            }

            int objetivo = _casos.FindIndex(c => c.IdPaciente == _idPacienteSeleccionado);
            if (objetivo < 0)
            {
                objetivo = 0;
            }
            _grillaCasos.Rows[objetivo].Selected = true;
            CargarDetalle(_casos[objetivo].IdPaciente);
        }

        private void CargarDetalle(int idPaciente)
        {
            _idPacienteSeleccionado = idPaciente;
            FilaCaso? caso = _casos.FirstOrDefault(c => c.IdPaciente == idPaciente);
            if (caso == null)
            {
                LimpiarDetalle();
                return;
            }

            _lblPacienteDetalle.Text = caso.Nombre;
            string estado = caso.Escalada ? Localizacion("seguimiento.protocolo.escalada") : Localizacion("seguimiento.protocolo.enCurso");
            _lblProtocolo.Text = $"{Localizacion("seguimiento.columna.intentos")}: {caso.Intentos} / {SeguimientoLogic.UmbralIntentosFallidos} · {estado}";
            _lblAviso.Text = string.Empty;

            using var contexto = new NegocioDbContext();
            List<Seguimiento> historial = new SeguimientoLogic(contexto).ObtenerSeguimientos(idPaciente);
            _grillaHistorial.Rows.Clear();
            foreach (Seguimiento s in historial)
            {
                _grillaHistorial.Rows.Add(
                    s.FechaRegistro.ToString("dd/MM/yyyy HH:mm"),
                    TipoTexto(s.TipoContacto),
                    ResultadoTexto(s.Resultado),
                    s.DecisionClinica == DecisionClinica.Ninguna ? string.Empty : DecisionTexto(s.DecisionClinica),
                    s.Observaciones ?? string.Empty);
            }

            bool puedeDecidir = historial.Count > 0;
            _cmbDecision.Enabled = puedeDecidir;
            _txtDetalleDecision.Enabled = puedeDecidir;
            _btnRegistrarDecision.Enabled = puedeDecidir;
            ActualizarPeriodicidadHabilitada();
            if (!puedeDecidir)
            {
                _lblProtocolo.Text += $" · {Localizacion("seguimiento.decSinIntentos")}";
            }
        }

        private void LimpiarDetalle()
        {
            _lblPacienteDetalle.Text = Localizacion("seguimiento.detalleVacio");
            _lblProtocolo.Text = string.Empty;
            _grillaHistorial.Rows.Clear();
            _lblAviso.Text = string.Empty;
            _cmbDecision.Enabled = false;
            _txtDetalleDecision.Enabled = false;
            _btnRegistrarDecision.Enabled = false;
            _numPeriodicidad.Enabled = false;
        }

        private void ActualizarPeriodicidadHabilitada()
        {
            bool esCambio = _cmbDecision.SelectedIndex == 2; // Cambiar periodicidad
            _numPeriodicidad.Enabled = esCambio && _cmbDecision.Enabled;
        }

        private void DetectarPlazos()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                List<Alerta> creadas = new SeguimientoLogic(contexto).DetectarPlazosVencidos();
                MessageBox.Show(FindForm(),
                    $"{Localizacion("seguimiento.deteccion")} {creadas.Count}",
                    Localizacion("mod.seguimiento"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Recargar();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SeguimientoControl");
            }
        }

        private void RegistrarIntento()
        {
            if (_idPacienteSeleccionado == 0)
            {
                _lblAviso.Text = Localizacion("seguimiento.detalleVacio");
                return;
            }

            try
            {
                using var contexto = new NegocioDbContext();
                var intento = new Seguimiento
                {
                    IdPaciente = _idPacienteSeleccionado,
                    TipoContacto = (TipoContacto)Math.Max(0, _cmbTipoContacto.SelectedIndex),
                    Resultado = _cmbResultado.SelectedIndex == 0 ? ResultadoContacto.Exitoso : ResultadoContacto.Fallido,
                    Observaciones = string.IsNullOrWhiteSpace(_txtObservaciones.Text) ? null : _txtObservaciones.Text.Trim()
                };

                ResultadoIntentoContacto resultado = new SeguimientoLogic(contexto).RegistrarIntentoContacto(intento, _nombreUsuario);

                if (resultado.CerroAlerta)
                {
                    MessageBox.Show(FindForm(), Localizacion("seguimiento.contactoOk"), Localizacion("seguimiento.contacto"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resultado.EscaladaAlMedico)
                {
                    MessageBox.Show(FindForm(), Localizacion("seguimiento.escaladaMsg"), Localizacion("seguimiento.escalada"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _lblAviso.Text = Localizacion("seguimiento.intentoRegistrado");
                }

                _txtObservaciones.Clear();
                Recargar();
            }
            catch (ValidacionNegocioException ex)
            {
                _lblAviso.Text = string.Join(Environment.NewLine, ex.Errores);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SeguimientoControl");
            }
        }

        private void RegistrarDecision()
        {
            if (_idPacienteSeleccionado == 0 || !_cmbDecision.Enabled)
            {
                _lblAviso.Text = Localizacion("seguimiento.decSinIntentos");
                return;
            }

            DecisionClinica[] decisiones =
            {
                DecisionClinica.ContactarPersonalmente,
                DecisionClinica.VisitaDomiciliaria,
                DecisionClinica.CambiarPeriodicidad,
                DecisionClinica.DeclararNoContactable
            };
            DecisionClinica decision = decisiones[Math.Max(0, _cmbDecision.SelectedIndex)];
            int? nuevaPeriodicidad = decision == DecisionClinica.CambiarPeriodicidad ? (int)_numPeriodicidad.Value : null;

            try
            {
                using var contexto = new NegocioDbContext();
                new SeguimientoLogic(contexto).RegistrarDecisionClinica(
                    _idPacienteSeleccionado, decision, _txtDetalleDecision.Text.Trim(), nuevaPeriodicidad, _nombreUsuario);

                MessageBox.Show(FindForm(), Localizacion("seguimiento.decisionOk"), Localizacion("seguimiento.decision"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _txtDetalleDecision.Clear();
                Recargar();
            }
            catch (ValidacionNegocioException ex)
            {
                _lblAviso.Text = string.Join(Environment.NewLine, ex.Errores);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SeguimientoControl");
            }
        }
    }
}
