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
    /// Agenda y turnos (REQ-FUNC-009): vista de la agenda médica por período y panel de
    /// sugerencias de reasignación inteligente (estables con turno → críticos sin turno),
    /// con aceptación (libera + asigna + notifica) o rechazo (escalable al médico).
    /// </summary>
    public partial class AgendaControl : UserControl
    {
        private readonly string _nombreUsuario = string.Empty;
        private readonly bool _puedeGestionar;

        // Los controles de la interfaz se declaran en AgendaControl.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.
        private List<SugerenciaReasignacion> _sugerencias = new();

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public AgendaControl()
        {
            InitializeComponent();
        }

        public AgendaControl(int idUsuario, string nombreUsuario) : this()
        {
            _nombreUsuario = nombreUsuario;

            // En tiempo de diseño no se consultan permisos ni se toca la base de datos.
            if (Disenio.Activo)
            {
                return;
            }

            _puedeGestionar = SeguridadService.TienePermiso(idUsuario, "GESTION_AGENDA");
            AplicarTextos();
            CargarTodo();
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Recarga agenda y sugerencias (al entrar al módulo).</summary>
        public void Recargar() => CargarTodo();

        /// <summary>Reaplica textos por cambio de idioma y recarga.</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            CargarTodo();
        }

        /// <summary>Vuelve a cargar la agenda y las sugerencias.</summary>
        private void BtnActualizar_Click(object? sender, EventArgs e) => CargarTodo();

        /// <summary>Abre el formulario de alta de turno.</summary>
        private void BtnAgendar_Click(object? sender, EventArgs e) => AbrirAgendador();

        private void BtnAceptarSugerencia_Click(object? sender, EventArgs e) => AceptarSugerenciaSeleccionada();

        private void BtnRechazarSugerencia_Click(object? sender, EventArgs e) => RechazarSugerenciaSeleccionada();

        private void AplicarTextos()
        {
            _lblDesde.Text = Localizacion("agenda.desde");
            _lblHasta.Text = Localizacion("agenda.hasta");
            _btnActualizar.Text = Localizacion("agenda.actualizar");
            _btnAgendar.Text = Localizacion("agenda.agendar");
            _lblSugerenciasTitulo.Text = Localizacion("agenda.sugerencias");
            _btnAceptarSugerencia.Text = Localizacion("comun.aceptar");
            _btnRechazarSugerencia.Text = Localizacion("agenda.rechazar");

            _grillaTurnos.Columns["fechaHora"].HeaderText = Localizacion("agenda.columna.fechaHora");
            _grillaTurnos.Columns["paciente"].HeaderText = Localizacion("panel.columna.paciente");
            _grillaTurnos.Columns["medico"].HeaderText = Localizacion("agenda.columna.medico");
            _grillaTurnos.Columns["estado"].HeaderText = Localizacion("pacientes.estado");
            _grillaTurnos.Columns["observaciones"].HeaderText = Localizacion("agenda.columna.observaciones");

            _grillaSugerencias.Columns["turno"].HeaderText = Localizacion("agenda.columna.fechaHora");
            _grillaSugerencias.Columns["de"].HeaderText = Localizacion("agenda.sug.columna.de");
            _grillaSugerencias.Columns["a"].HeaderText = Localizacion("agenda.sug.columna.a");
        }

        private string EstadoTexto(EstadoTurno estado) => estado switch
        {
            EstadoTurno.Pendiente => Localizacion("agenda.estado.pendiente"),
            EstadoTurno.Confirmado => Localizacion("agenda.estado.confirmado"),
            EstadoTurno.Cancelado => Localizacion("agenda.estado.cancelado"),
            EstadoTurno.Atendido => Localizacion("agenda.estado.atendido"),
            _ => Localizacion("agenda.estado.reasignacion")
        };

        private void CargarTodo()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                var turnoLogic = new TurnoLogic(contexto);

                Dictionary<int, string> medicos = contexto.Usuarios.AsNoTracking()
                    .ToDictionary(u => u.Id, u => u.NombreCompleto);

                DateTime desde = _dtpDesde.Value.Date;
                DateTime hasta = _dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                var turnos = turnoLogic.ObtenerAgenda(desde, hasta);

                _grillaTurnos.Rows.Clear();
                foreach (Turno turno in turnos)
                {
                    string medico = medicos.TryGetValue(turno.IdUsuarioMedico, out string? nombreMedico) ? nombreMedico : "—";
                    int indice = _grillaTurnos.Rows.Add(
                        turno.FechaHora.ToString("dd/MM/yyyy HH:mm"),
                        turno.Paciente?.NombreCompleto ?? "—",
                        medico,
                        EstadoTexto(turno.Estado),
                        turno.Observaciones ?? string.Empty);

                    if (turno.Estado == EstadoTurno.Cancelado)
                    {
                        _grillaTurnos.Rows[indice].DefaultCellStyle.ForeColor = Color.FromArgb(138, 148, 158);
                    }
                }
                _lblSinTurnos.Text = turnos.Count == 0 ? Localizacion("agenda.sinTurnos") : string.Empty;

                _sugerencias = turnoLogic.GenerarSugerencias();
                _grillaSugerencias.Rows.Clear();
                foreach (SugerenciaReasignacion sugerencia in _sugerencias)
                {
                    _grillaSugerencias.Rows.Add(
                        sugerencia.FechaHoraTurno.ToString("dd/MM/yyyy HH:mm"),
                        sugerencia.NombrePacienteEstable,
                        sugerencia.NombrePacienteCritico);
                }
                if (_grillaSugerencias.Rows.Count > 0)
                {
                    _grillaSugerencias.Rows[0].Selected = true; // pre-selección de la primera sugerencia
                }
                _lblInfoSugerencias.Text = _sugerencias.Count == 0 ? Localizacion("agenda.sugerenciasVacias") : string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "AgendaControl", mostrarMensaje: false);
            }
        }

        private void AbrirAgendador()
        {
            if (!_puedeGestionar)
            {
                return;
            }
            using var formulario = new AgendarTurnoForm(_nombreUsuario);
            if (formulario.ShowDialog(FindForm()) == DialogResult.OK)
            {
                CargarTodo();
            }
        }

        private void AceptarSugerenciaSeleccionada()
        {
            if (!_puedeGestionar)
            {
                return;
            }
            if (_grillaSugerencias.SelectedRows.Count == 0)
            {
                MostrarAviso(Localizacion("agenda.selSugerencia"));
                return;
            }
            int indice = _grillaSugerencias.SelectedRows[0].Index;
            if (indice < 0 || indice >= _sugerencias.Count)
            {
                return;
            }

            try
            {
                using var contexto = new NegocioDbContext();
                ResultadoReasignacion resultado = new TurnoLogic(contexto).AceptarSugerencia(_sugerencias[indice], _nombreUsuario);
                MessageBox.Show(FindForm(),
                    Localizacion("agenda.reasignacionOk") + Environment.NewLine + Environment.NewLine +
                    string.Join(Environment.NewLine, resultado.Notificaciones),
                    Localizacion("agenda.sugerencias"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTodo();
            }
            catch (ValidacionNegocioException ex)
            {
                MostrarAviso(string.Join(Environment.NewLine, ex.Errores));
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "AgendaControl");
            }
        }

        private void RechazarSugerenciaSeleccionada()
        {
            if (!_puedeGestionar)
            {
                return;
            }
            if (_grillaSugerencias.SelectedRows.Count == 0)
            {
                MostrarAviso(Localizacion("agenda.selSugerencia"));
                return;
            }
            int indice = _grillaSugerencias.SelectedRows[0].Index;
            if (indice < 0 || indice >= _sugerencias.Count)
            {
                return;
            }

            using var dialogo = new TextoDialogoForm(Localizacion("agenda.sugerencias"), Localizacion("agenda.motivoRechazo"));
            if (dialogo.ShowDialog(FindForm()) != DialogResult.OK || dialogo.Valor.Length == 0)
            {
                return;
            }

            bool escalar = MessageBox.Show(FindForm(), Localizacion("agenda.escalar"), Localizacion("agenda.rechazar"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

            try
            {
                using var contexto = new NegocioDbContext();
                new TurnoLogic(contexto).RechazarSugerencia(_sugerencias[indice], dialogo.Valor, escalar, _nombreUsuario);
                CargarTodo();
            }
            catch (ValidacionNegocioException ex)
            {
                MostrarAviso(string.Join(Environment.NewLine, ex.Errores));
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "AgendaControl");
            }
        }

        private void MostrarAviso(string mensaje)
        {
            MessageBox.Show(FindForm(), mensaje, Localizacion("error.titulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
