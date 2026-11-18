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
    /// Registro de eventos adversos (REQ-FUNC-003): búsqueda del paciente por documento,
    /// consulta de sus eventos registrados (o de los últimos eventos de todos los pacientes)
    /// y alta de nuevos incidentes con tipo, gravedad, descripción y acción tomada.
    /// </summary>
    public partial class EventosAdversosControl : UserControl
    {
        private readonly string _nombreUsuario = string.Empty;

        // Los controles de la interfaz se declaran en EventosAdversosControl.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.
        private Paciente? _pacienteActual;

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public EventosAdversosControl()
        {
            InitializeComponent();
        }

        public EventosAdversosControl(string nombreUsuario) : this()
        {
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

        /// <summary>Recarga la vista actual (recientes o del paciente seleccionado).</summary>
        public void Recargar()
        {
            if (_pacienteActual == null)
            {
                CargarRecientes();
            }
            else
            {
                CargarDePaciente(_pacienteActual.Id);
            }
        }

        /// <summary>Reaplica textos por cambio de idioma y recarga.</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            Recargar();
        }

        /// <summary>Busca al paciente al presionar Enter en el campo de DNI.</summary>
        private void TxtDni_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarPaciente();
            }
        }

        /// <summary>Busca el paciente por documento.</summary>
        private void BtnBuscar_Click(object? sender, EventArgs e) => BuscarPaciente();

        /// <summary>Abre el formulario de registro de un evento adverso.</summary>
        private void BtnRegistrar_Click(object? sender, EventArgs e) => RegistrarEvento();

        private void AplicarTextos()
        {
            _lblDni.Text = Localizacion("rin.identificacion");
            _btnBuscar.Text = Localizacion("comun.buscar");
            _btnRegistrar.Text = Localizacion("eventos.registrar");
            _grilla.Columns["fecha"].HeaderText = Localizacion("rin.columna.fecha");
            _grilla.Columns["paciente"].HeaderText = Localizacion("panel.columna.paciente");
            _grilla.Columns["tipo"].HeaderText = Localizacion("eventos.columna.tipo");
            _grilla.Columns["gravedad"].HeaderText = Localizacion("eventos.columna.gravedad");
            _grilla.Columns["descripcion"].HeaderText = Localizacion("reportes.columna.descripcion");
            _grilla.Columns["accion"].HeaderText = Localizacion("eventos.columna.accion");
            if (_pacienteActual == null)
            {
                _lblPaciente.Text = Localizacion("eventos.recientes");
            }
        }

        private string TipoTexto(TipoEventoAdverso tipo) => tipo switch
        {
            TipoEventoAdverso.Hemorragia => Localizacion("eventos.tipo.hemorragia"),
            TipoEventoAdverso.Trombosis => Localizacion("eventos.tipo.trombosis"),
            TipoEventoAdverso.Reaccion => Localizacion("eventos.tipo.reaccion"),
            _ => Localizacion("eventos.tipo.otro")
        };

        private string GravedadTexto(GravedadEvento gravedad) => gravedad switch
        {
            GravedadEvento.Leve => Localizacion("eventos.gravedad.leve"),
            GravedadEvento.Moderada => Localizacion("eventos.gravedad.moderada"),
            _ => Localizacion("eventos.gravedad.grave")
        };

        private static Color ColorGravedad(GravedadEvento gravedad) => gravedad switch
        {
            GravedadEvento.Leve => Color.FromArgb(30, 130, 75),
            GravedadEvento.Moderada => Color.FromArgb(190, 125, 20),
            _ => Color.FromArgb(185, 45, 40)
        };

        private void AgregarFila(EventoAdverso evento, string nombrePaciente)
        {
            int indice = _grilla.Rows.Add(
                evento.Fecha.ToString("dd/MM/yyyy"),
                nombrePaciente,
                TipoTexto(evento.Tipo),
                GravedadTexto(evento.Gravedad),
                evento.Descripcion,
                evento.AccionTomada);

            DataGridViewCell celda = _grilla.Rows[indice].Cells[3];
            Color color = ColorGravedad(evento.Gravedad);
            celda.Style.BackColor = color;
            celda.Style.ForeColor = Color.White;
            celda.Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            celda.Style.SelectionBackColor = color;
            celda.Style.SelectionForeColor = Color.White;
        }

        private void CargarRecientes()
        {
            try
            {
                _pacienteActual = null;
                if (_lblPaciente.Text.Length == 0 || _lblPaciente.Text == Localizacion("rin.pacienteNoEncontrado"))
                {
                    _lblPaciente.Text = Localizacion("eventos.recientes");
                }

                using var contexto = new NegocioDbContext();
                Dictionary<int, string> nombres = contexto.Pacientes.AsNoTracking()
                    .ToDictionary(p => p.Id, p => p.NombreCompleto);

                var eventos = contexto.EventosAdversos.AsNoTracking()
                    .OrderByDescending(e => e.Fecha).ThenByDescending(e => e.Id)
                    .Take(50)
                    .ToList();

                _grilla.Rows.Clear();
                foreach (EventoAdverso evento in eventos)
                {
                    AgregarFila(evento, nombres.GetValueOrDefault(evento.IdPaciente, "—"));
                }
                _grilla.ClearSelection();
                _lblSinEventos.Text = eventos.Count == 0 ? Localizacion("eventos.sinEventos") : string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "EventosAdversosControl", mostrarMensaje: false);
            }
        }

        private void CargarDePaciente(int idPaciente)
        {
            try
            {
                using var contexto = new NegocioDbContext();
                List<EventoAdverso> eventos = new EventoAdversoLogic(contexto).ObtenerPorPaciente(idPaciente);

                string nombre = _pacienteActual?.NombreCompleto ?? string.Empty;
                _grilla.Rows.Clear();
                foreach (EventoAdverso evento in eventos)
                {
                    AgregarFila(evento, nombre);
                }
                _grilla.ClearSelection();
                _lblSinEventos.Text = eventos.Count == 0 ? Localizacion("eventos.sinEventos") : string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "EventosAdversosControl", mostrarMensaje: false);
            }
        }

        private void BuscarPaciente()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                Paciente? paciente = new PacienteLogic(contexto).BuscarPorDNI(_txtDni.Text.Trim());
                if (paciente == null)
                {
                    _lblPaciente.Text = Localizacion("rin.pacienteNoEncontrado");
                    CargarRecientes();
                    return;
                }

                _pacienteActual = paciente;
                _lblPaciente.Text = $"{paciente.NombreCompleto} ({paciente.DNI})";
                CargarDePaciente(paciente.Id);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "EventosAdversosControl");
            }
        }

        private void RegistrarEvento()
        {
            if (_pacienteActual == null)
            {
                MessageBox.Show(FindForm(), Localizacion("eventos.selPaciente"), Localizacion("eventos.registrar"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using var formulario = new EventoAdversoForm(_pacienteActual, _nombreUsuario);
            if (formulario.ShowDialog(FindForm()) == DialogResult.OK)
            {
                CargarDePaciente(_pacienteActual.Id);
            }
        }
    }
}
