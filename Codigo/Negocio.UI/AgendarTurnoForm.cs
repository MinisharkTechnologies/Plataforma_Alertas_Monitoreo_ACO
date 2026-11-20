using Microsoft.EntityFrameworkCore;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Usuario = Services.DomainModel.Usuario;
using Negocio.DomainModel.Enums;
using Negocio.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Diálogo para agendar un turno presencial (REQ-FUNC-009): selección de paciente activo,
    /// médico habilitado, fecha y hora, con las validaciones de agenda de la BLL.
    /// </summary>
    public partial class AgendarTurnoForm : Form
    {
        private sealed class OpcionPaciente
        {
            public int Id { get; set; }
            public string Texto { get; set; } = string.Empty;
            public override string ToString() => Texto;
        }

        private sealed class OpcionMedico
        {
            public int Id { get; set; }
            public string Texto { get; set; } = string.Empty;
            public override string ToString() => Texto;
        }

        private readonly string _usuarioResponsable = string.Empty;

        // Los controles de la interfaz se declaran en AgendarTurnoForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public AgendarTurnoForm()
        {
            InitializeComponent();
        }

        public AgendarTurnoForm(string usuarioResponsable) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se toca la base de datos:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            _usuarioResponsable = usuarioResponsable;
            AplicarTextos();
            _dtpFecha.Value = DateTime.Today.AddDays(1);
            CargarCombos();
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Aplica los textos localizados a las etiquetas y botones del diálogo.</summary>
        private void AplicarTextos()
        {
            Text = $"OpenRIN — {Localizacion("agenda.agendar")}";
            _lblPaciente.Text = Localizacion("panel.columna.paciente");
            _lblMedico.Text = Localizacion("agenda.columna.medico");
            _lblFecha.Text = Localizacion("rin.columna.fecha");
            _lblHora.Text = Localizacion("agenda.hora");
            _lblObservaciones.Text = Localizacion("agenda.columna.observaciones");
            _btnGuardar.Text = Localizacion("comun.guardar");
            _btnCancelar.Text = Localizacion("comun.cancelar");
        }

        private void CargarCombos()
        {
            using var contexto = new NegocioDbContext();

            var pacientes = contexto.Pacientes.AsNoTracking()
                .Where(p => p.Estado == EstadoPaciente.Activo)
                .OrderBy(p => p.NombreCompleto)
                .ToList();
            foreach (Paciente paciente in pacientes)
            {
                _cmbPaciente.Items.Add(new OpcionPaciente { Id = paciente.Id, Texto = $"{paciente.NombreCompleto} ({paciente.DNI})" });
            }
            if (_cmbPaciente.Items.Count > 0)
            {
                _cmbPaciente.SelectedIndex = 0;
            }

            var medicos = contexto.Usuarios.AsNoTracking()
                .Where(u => u.Perfil == "medico" && u.Activo)
                .OrderBy(u => u.NombreCompleto)
                .ToList();
            foreach (Usuario medico in medicos)
            {
                _cmbMedico.Items.Add(new OpcionMedico { Id = medico.Id, Texto = medico.NombreCompleto });
            }
            if (_cmbMedico.Items.Count > 0)
            {
                _cmbMedico.SelectedIndex = 0;
            }
            else
            {
                _lblAviso.Text = Localizacion("agenda.sinMedicos");
            }
        }

        /// <summary>Cierra el diálogo sin guardar (botón Cancelar).</summary>
        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            var paciente = _cmbPaciente.SelectedItem as OpcionPaciente;
            var medico = _cmbMedico.SelectedItem as OpcionMedico;
            if (paciente == null || medico == null)
            {
                _lblAviso.Text = Localizacion("agenda.sinMedicos");
                return;
            }

            try
            {
                using var contexto = new NegocioDbContext();
                var turno = new Turno
                {
                    IdPaciente = paciente.Id,
                    IdUsuarioMedico = medico.Id,
                    FechaHora = _dtpFecha.Value.Date.Add(_dtpHora.Value.TimeOfDay),
                    Observaciones = string.IsNullOrWhiteSpace(_txtObservaciones.Text) ? null : _txtObservaciones.Text.Trim()
                };

                new TurnoLogic(contexto).AgendarTurno(turno, _usuarioResponsable);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidacionNegocioException ex)
            {
                _lblAviso.Text = string.Join(Environment.NewLine, ex.Errores);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "AgendarTurnoForm");
            }
        }
    }
}
