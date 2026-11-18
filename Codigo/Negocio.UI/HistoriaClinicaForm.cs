using Microsoft.EntityFrameworkCore;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Historia clínica hematológica de un paciente (REQ-FUNC-002): creación/actualización por
    /// perfiles con permiso HISTORIA_CLINICA, o vista de solo lectura para el resto.
    /// </summary>
    public partial class HistoriaClinicaForm : Form
    {
        private sealed class OpcionDiagnostico
        {
            public int? Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public override string ToString() => Nombre;
        }

        private readonly Paciente _paciente = null!;
        private readonly string _usuarioResponsable = string.Empty;
        private readonly bool _puedeEditar;

        // Los controles de la interfaz se declaran en HistoriaClinicaForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public HistoriaClinicaForm()
        {
            InitializeComponent();
        }

        public HistoriaClinicaForm(Paciente paciente, string usuarioResponsable, bool puedeEditar) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se toca la base de datos:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            _paciente = paciente;
            _usuarioResponsable = usuarioResponsable;
            _puedeEditar = puedeEditar;
            _dtpProximoControl.Value = DateTime.Today;
            AplicarTextos();
            AplicarPermisosEdicion();
            Cargar();
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Aplica los textos localizados a las etiquetas y botones del diálogo.</summary>
        private void AplicarTextos()
        {
            Text = $"OpenRIN — {Localizacion("hc.titulo")} — {_paciente.NombreCompleto}";
            _lblDiagnostico.Text = Localizacion("hc.diagnostico");
            _lblLimiteInferior.Text = Localizacion("hc.limiteInferior");
            _lblLimiteSuperior.Text = Localizacion("hc.limiteSuperior");
            _lblMedicamento.Text = Localizacion("hc.medicamento");
            _lblDosis.Text = Localizacion("hc.dosis");
            _lblPeriodicidad.Text = Localizacion("hc.periodicidad");
            _btnGuardar.Text = Localizacion("comun.guardar");
            _btnCerrar.Text = Localizacion("comun.cerrar");
        }

        /// <summary>Deja la pantalla en solo lectura cuando el perfil no puede modificar la historia clínica.</summary>
        private void AplicarPermisosEdicion()
        {
            if (_puedeEditar)
            {
                return;
            }

            _cmbDiagnostico.Enabled = false;
            _numInferior.Enabled = false;
            _numSuperior.Enabled = false;
            _txtMedicamento.ReadOnly = true;
            _txtDosis.ReadOnly = true;
            _numPeriodicidad.Enabled = false;
            _chkProximoControl.Enabled = false;
            _dtpProximoControl.Enabled = false;
            _btnGuardar.Visible = false;
            _lblAviso.Text = Localizacion("hc.soloLectura");
        }

        private void Cargar()
        {
            using var contexto = new NegocioDbContext();

            var diagnosticos = contexto.Diagnosticos.AsNoTracking()
                .Where(d => d.Activo)
                .OrderBy(d => d.Nombre)
                .ToList();
            _cmbDiagnostico.Items.Add(new OpcionDiagnostico { Id = null, Nombre = Localizacion("hc.sinDiagnostico") });
            foreach (Diagnostico diagnostico in diagnosticos)
            {
                _cmbDiagnostico.Items.Add(new OpcionDiagnostico { Id = diagnostico.Id, Nombre = diagnostico.Nombre });
            }
            _cmbDiagnostico.SelectedIndex = 0;

            HistoriaClinica? hc = new HistoriaClinicaLogic(contexto).ObtenerPorPaciente(_paciente.Id);
            if (hc == null)
            {
                if (_puedeEditar)
                {
                    _lblAviso.Text = Localizacion("hc.sinConfigurar");
                }
                return;
            }

            foreach (OpcionDiagnostico? opcion in _cmbDiagnostico.Items)
            {
                if (opcion != null && opcion.Id == hc.IdDiagnostico)
                {
                    _cmbDiagnostico.SelectedItem = opcion;
                    break;
                }
            }
            _numInferior.Value = Math.Clamp(hc.LimiteInferiorRIN, _numInferior.Minimum, _numInferior.Maximum);
            _numSuperior.Value = Math.Clamp(hc.LimiteSuperiorRIN, _numSuperior.Minimum, _numSuperior.Maximum);
            _txtMedicamento.Text = hc.Medicamento;
            _txtDosis.Text = hc.Dosis;
            _numPeriodicidad.Value = Math.Clamp(hc.PeriodicidadDias, 1, 365);
            if (hc.ProximaFechaControl.HasValue)
            {
                _chkProximoControl.Checked = true;
                _dtpProximoControl.Value = hc.ProximaFechaControl.Value;
            }
        }

        /// <summary>Habilita el selector de fecha solo si se marcó el control y el perfil puede editar.</summary>
        private void ChkProximoControl_CheckedChanged(object? sender, EventArgs e)
        {
            _dtpProximoControl.Enabled = _chkProximoControl.Checked && _puedeEditar;
        }

        /// <summary>Cierra el diálogo sin guardar (botón Cerrar).</summary>
        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                using var contexto = new NegocioDbContext();
                var hc = new HistoriaClinica
                {
                    IdPaciente = _paciente.Id,
                    IdDiagnostico = (_cmbDiagnostico.SelectedItem as OpcionDiagnostico)?.Id,
                    LimiteInferiorRIN = _numInferior.Value,
                    LimiteSuperiorRIN = _numSuperior.Value,
                    Medicamento = _txtMedicamento.Text.Trim(),
                    Dosis = _txtDosis.Text.Trim(),
                    PeriodicidadDias = (int)_numPeriodicidad.Value,
                    ProximaFechaControl = _chkProximoControl.Checked ? _dtpProximoControl.Value.Date : null
                };

                new HistoriaClinicaLogic(contexto).Configurar(hc, _usuarioResponsable);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidacionNegocioException ex)
            {
                MessageBox.Show(this, string.Join(Environment.NewLine, ex.Errores),
                    Localizacion("error.titulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "HistoriaClinicaForm");
            }
        }
    }
}
