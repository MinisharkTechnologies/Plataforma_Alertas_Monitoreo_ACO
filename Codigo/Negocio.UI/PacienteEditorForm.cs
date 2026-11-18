using Microsoft.EntityFrameworkCore;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Alta (REQ-FUNC-001) y modificación de pacientes. En el alta se generan las credenciales
    /// únicas del portal y se muestran una única vez para entregarlas al paciente.
    /// </summary>
    public partial class PacienteEditorForm : Form
    {
        private sealed class OpcionObra
        {
            public int? Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public override string ToString() => Nombre;
        }

        private readonly Paciente? _pacienteExistente;
        private readonly string _usuarioResponsable = string.Empty;
        private readonly bool _esAlta;

        // Los controles de la interfaz se declaran en PacienteEditorForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public PacienteEditorForm()
        {
            InitializeComponent();
        }

        public PacienteEditorForm(Paciente? paciente, string usuarioResponsable) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se toca la base de datos:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            _pacienteExistente = paciente;
            _usuarioResponsable = usuarioResponsable;
            _esAlta = paciente == null;
            AplicarTextos();
            CargarObras();
            if (paciente != null)
            {
                Prefil(paciente);
            }
        }

        private static string Texto(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Aplica los textos localizados (título según alta o modificación, etiquetas y botones).</summary>
        private void AplicarTextos()
        {
            Text = $"OpenRIN — {Texto(_esAlta ? "pacientes.alta" : "comun.modificar")}";
            _lblNombre.Text = Texto("pacientes.nombre");
            _lblDocumento.Text = Texto("pacientes.documento");
            _lblTelefono.Text = Texto("pacientes.telefono");
            _lblEmail.Text = Texto("pacientes.email");
            _lblObraSocial.Text = Texto("pacientes.obraSocial");
            _lblAfiliado.Text = Texto("pacientes.numeroAfiliado");
            _btnGuardar.Text = Texto("comun.guardar");
            _btnCancelar.Text = Texto("comun.cancelar");
        }

        private void CargarObras()
        {
            using var contexto = new NegocioDbContext();
            var obras = contexto.ObrasSociales.AsNoTracking()
                .Where(o => o.Activo)
                .OrderBy(o => o.Nombre)
                .ToList();

            _cmbObraSocial.Items.Add(new OpcionObra { Id = null, Nombre = Texto("pacientes.sinObraSocial") });
            foreach (ObraSocial obra in obras)
            {
                _cmbObraSocial.Items.Add(new OpcionObra { Id = obra.Id, Nombre = obra.Nombre });
            }
            _cmbObraSocial.SelectedIndex = 0;
        }

        private void Prefil(Paciente paciente)
        {
            _txtNombre.Text = paciente.NombreCompleto;
            _txtDni.Text = paciente.DNI;
            _txtTelefono.Text = paciente.Telefono;
            _txtEmail.Text = paciente.Email;
            _txtAfiliado.Text = paciente.NumeroAfiliado ?? string.Empty;

            foreach (OpcionObra? opcion in _cmbObraSocial.Items)
            {
                if (opcion != null && opcion.Id == paciente.IdObraSocial)
                {
                    _cmbObraSocial.SelectedItem = opcion;
                    break;
                }
            }
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
                var logica = new PacienteLogic(contexto);
                OpcionObra? obra = _cmbObraSocial.SelectedItem as OpcionObra;

                if (_esAlta)
                {
                    var nuevo = new Paciente
                    {
                        NombreCompleto = _txtNombre.Text.Trim(),
                        DNI = _txtDni.Text.Trim(),
                        Telefono = _txtTelefono.Text.Trim(),
                        Email = _txtEmail.Text.Trim(),
                        IdObraSocial = obra?.Id,
                        NumeroAfiliado = string.IsNullOrWhiteSpace(_txtAfiliado.Text) ? null : _txtAfiliado.Text.Trim()
                    };

                    CredencialesPortal credenciales = logica.RegistrarPaciente(nuevo, _usuarioResponsable);
                    using (var credencialesForm = new CredencialesPortalForm(credenciales))
                    {
                        credencialesForm.ShowDialog(this);
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    var editado = new Paciente
                    {
                        Id = _pacienteExistente!.Id,
                        NombreCompleto = _txtNombre.Text.Trim(),
                        DNI = _txtDni.Text.Trim(),
                        Telefono = _txtTelefono.Text.Trim(),
                        Email = _txtEmail.Text.Trim(),
                        IdObraSocial = obra?.Id,
                        NumeroAfiliado = string.IsNullOrWhiteSpace(_txtAfiliado.Text) ? null : _txtAfiliado.Text.Trim()
                    };

                    logica.ModificarPaciente(editado, _usuarioResponsable);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (ValidacionNegocioException ex)
            {
                MessageBox.Show(this, string.Join(Environment.NewLine, ex.Errores),
                    Texto("error.titulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "PacienteEditorForm");
            }
        }
    }
}
