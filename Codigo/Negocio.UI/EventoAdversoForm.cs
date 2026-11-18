using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;
using Negocio.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Diálogo de alta de un evento adverso (REQ-FUNC-003): fecha (no futura), tipo, gravedad,
    /// descripción y acción tomada, con las validaciones de la BLL.
    /// </summary>
    public partial class EventoAdversoForm : Form
    {
        private readonly Paciente _paciente = null!;
        private readonly string _usuarioResponsable = string.Empty;

        // Los controles de la interfaz se declaran en EventoAdversoForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public EventoAdversoForm()
        {
            InitializeComponent();
        }

        public EventoAdversoForm(Paciente paciente, string usuarioResponsable) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se toca la base de datos:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            _paciente = paciente;
            _usuarioResponsable = usuarioResponsable;
            AplicarTextos();
            _dtpFecha.Value = DateTime.Today;
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Aplica los textos localizados a las etiquetas, los combos y los botones del diálogo.</summary>
        private void AplicarTextos()
        {
            Text = $"OpenRIN — {Localizacion("eventos.registrar")}";
            _lblPaciente.Text = $"{_paciente.NombreCompleto} ({_paciente.DNI})";
            _lblFecha.Text = Localizacion("eventos.fechaEvento");
            _lblTipo.Text = Localizacion("eventos.columna.tipo");
            _lblGravedad.Text = Localizacion("eventos.columna.gravedad");
            _lblDescripcion.Text = Localizacion("reportes.columna.descripcion");
            _lblAccion.Text = Localizacion("eventos.columna.accion");
            _btnGuardar.Text = Localizacion("comun.guardar");
            _btnCancelar.Text = Localizacion("comun.cancelar");

            _cmbTipo.Items.Clear();
            _cmbTipo.Items.Add(Localizacion("eventos.tipo.hemorragia"));
            _cmbTipo.Items.Add(Localizacion("eventos.tipo.trombosis"));
            _cmbTipo.Items.Add(Localizacion("eventos.tipo.reaccion"));
            _cmbTipo.Items.Add(Localizacion("eventos.tipo.otro"));
            _cmbTipo.SelectedIndex = 0;

            _cmbGravedad.Items.Clear();
            _cmbGravedad.Items.Add(Localizacion("eventos.gravedad.leve"));
            _cmbGravedad.Items.Add(Localizacion("eventos.gravedad.moderada"));
            _cmbGravedad.Items.Add(Localizacion("eventos.gravedad.grave"));
            _cmbGravedad.SelectedIndex = 0;
        }

        /// <summary>Cierra el diálogo sin guardar (botón Cancelar).</summary>
        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                using var contexto = new NegocioDbContext();
                var evento = new EventoAdverso
                {
                    IdPaciente = _paciente.Id,
                    Fecha = _dtpFecha.Value.Date,
                    Tipo = (TipoEventoAdverso)_cmbTipo.SelectedIndex,
                    Gravedad = (GravedadEvento)_cmbGravedad.SelectedIndex,
                    Descripcion = _txtDescripcion.Text.Trim(),
                    AccionTomada = _txtAccion.Text.Trim()
                };

                new EventoAdversoLogic(contexto).Registrar(evento, _usuarioResponsable);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidacionNegocioException ex)
            {
                _lblAviso.Text = string.Join(Environment.NewLine, ex.Errores);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "EventoAdversoForm");
            }
        }
    }
}
