using Microsoft.EntityFrameworkCore;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Pantalla de gestión de pacientes e historias clínicas (REQ-FUNC-001/002): búsqueda por
    /// nombre/documento, alta con credenciales del portal, modificación, baja lógica con motivo
    /// y acceso a la historia clínica. Los botones de gestión se habilitan según los permisos
    /// del perfil (REQ-ARQ-006).
    /// </summary>
    public partial class PacientesControl : UserControl
    {
        private readonly string _nombreUsuario = string.Empty;
        private readonly bool _puedeGestionar;
        private readonly bool _puedeEditarHistoria;

        // Los controles que se ven en pantalla se declaran en PacientesControl.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.
        private List<Paciente> _pacientes = new();

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public PacientesControl()
        {
            InitializeComponent();
        }

        public PacientesControl(int idUsuario, string nombreUsuario) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se tocan servicios ni la base de datos:
            // alcanza con que los controles se hayan creado para que el control se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            _nombreUsuario = nombreUsuario;
            _puedeGestionar = SeguridadService.TienePermiso(idUsuario, "GESTION_PACIENTES");
            _puedeEditarHistoria = SeguridadService.TienePermiso(idUsuario, "HISTORIA_CLINICA");

            AplicarTextos();
            CargarDatos();
        }

        private static string Texto(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Recarga la lista desde la base (al entrar al módulo).</summary>
        public void Recargar() => CargarDatos();

        /// <summary>Reaplica textos por cambio de idioma y recarga.</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            CargarDatos();
        }

        // Manejadores de eventos de la interfaz (se conectan desde PacientesControl.Designer.cs).

        private void TxtBusqueda_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarDatos();
            }
        }

        private void BtnBuscar_Click(object? sender, EventArgs e) => CargarDatos();

        private void ChkInactivos_CheckedChanged(object? sender, EventArgs e) => CargarDatos();

        private void BtnNuevo_Click(object? sender, EventArgs e) => AbrirEditor(null, esModificacion: false);

        private void BtnModificar_Click(object? sender, EventArgs e) => AbrirEditor(PacienteSeleccionado(), esModificacion: true);

        private void BtnBaja_Click(object? sender, EventArgs e) => DarDeBajaSeleccionado();

        private void BtnHistoria_Click(object? sender, EventArgs e) => AbrirHistoriaClinica(PacienteSeleccionado());

        private void Grilla_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirEditor(PacienteSeleccionado(), esModificacion: true);
            }
        }

        private void Grilla_SelectionChanged(object? sender, EventArgs e) => ActualizarBotones();

        private void AplicarTextos()
        {
            _lblBuscar.Text = Texto("pacientes.buscar");
            _txtBusqueda.PlaceholderText = Texto("pacientes.buscarPlaceholder");
            _btnBuscar.Text = Texto("comun.buscar");
            _chkInactivos.Text = Texto("pacientes.verInactivos");
            _btnNuevo.Text = Texto("pacientes.alta");
            _btnModificar.Text = Texto("comun.modificar");
            _btnBaja.Text = Texto("pacientes.baja");
            _btnHistoria.Text = Texto("pacientes.historia");

            _grilla.Columns["nombre"].HeaderText = Texto("pacientes.nombre");
            _grilla.Columns["documento"].HeaderText = Texto("pacientes.documento");
            _grilla.Columns["telefono"].HeaderText = Texto("pacientes.telefono");
            _grilla.Columns["email"].HeaderText = Texto("pacientes.email");
            _grilla.Columns["obra"].HeaderText = Texto("pacientes.obraSocial");
            _grilla.Columns["estado"].HeaderText = Texto("pacientes.estado");
            _grilla.Columns["fechaAlta"].HeaderText = Texto("pacientes.fechaAlta");
        }

        private void CargarDatos()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                _pacientes = new PacienteLogic(contexto).Buscar(_txtBusqueda.Text, _chkInactivos.Checked);
                Dictionary<int, string> obras = contexto.ObrasSociales.AsNoTracking()
                    .ToDictionary(o => o.Id, o => o.Nombre);

                _grilla.Rows.Clear();
                foreach (Paciente paciente in _pacientes)
                {
                    string obra = paciente.IdObraSocial.HasValue && obras.TryGetValue(paciente.IdObraSocial.Value, out string? nombreObra)
                        ? nombreObra
                        : Texto("pacientes.sinObraSocial");
                    string estado = paciente.Estado == EstadoPaciente.Activo
                        ? Texto("pacientes.estadoActivo")
                        : Texto("pacientes.estadoInactivo");

                    int indice = _grilla.Rows.Add(
                        paciente.NombreCompleto,
                        paciente.DNI,
                        paciente.Telefono,
                        paciente.Email,
                        obra,
                        estado,
                        paciente.FechaAlta.ToString("dd/MM/yyyy"));

                    if (paciente.Estado != EstadoPaciente.Activo)
                    {
                        _grilla.Rows[indice].DefaultCellStyle.ForeColor = Color.FromArgb(138, 148, 158);
                    }
                }

                _lblResultados.Text = string.Format(Texto("pacientes.resultados"), _pacientes.Count);
                ActualizarBotones();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "PacientesControl", mostrarMensaje: false);
                _lblResultados.Text = Texto("error.generico");
            }
        }

        private void ActualizarBotones()
        {
            Paciente? seleccionado = PacienteSeleccionado();
            _btnNuevo.Enabled = _puedeGestionar;
            _btnModificar.Enabled = _puedeGestionar && seleccionado != null && seleccionado.Estado == EstadoPaciente.Activo;
            _btnBaja.Enabled = _puedeGestionar && seleccionado != null && seleccionado.Estado == EstadoPaciente.Activo;
            _btnHistoria.Enabled = seleccionado != null;
        }

        private Paciente? PacienteSeleccionado()
        {
            if (_grilla.SelectedRows.Count == 0)
            {
                return null;
            }
            int indice = _grilla.SelectedRows[0].Index;
            return indice >= 0 && indice < _pacientes.Count ? _pacientes[indice] : null;
        }

        private void AbrirEditor(Paciente? paciente, bool esModificacion)
        {
            if (!_puedeGestionar)
            {
                return;
            }
            if (esModificacion && paciente == null)
            {
                MostrarAviso(Texto("pacientes.sinSeleccion"));
                return;
            }

            using var editor = new PacienteEditorForm(paciente, _nombreUsuario);
            if (editor.ShowDialog(FindForm()) == DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void DarDeBajaSeleccionado()
        {
            Paciente? paciente = PacienteSeleccionado();
            if (!_puedeGestionar)
            {
                return;
            }
            if (paciente == null)
            {
                MostrarAviso(Texto("pacientes.sinSeleccion"));
                return;
            }

            DialogResult confirmacion = MessageBox.Show(FindForm(),
                string.Format(Texto("pacientes.baja.confirmar"), paciente.NombreCompleto),
                Texto("pacientes.baja"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            using var dialogo = new TextoDialogoForm(Texto("pacientes.baja"), Texto("pacientes.baja.motivo"));
            if (dialogo.ShowDialog(FindForm()) != DialogResult.OK || dialogo.Valor.Length == 0)
            {
                return;
            }

            try
            {
                using var contexto = new NegocioDbContext();
                new PacienteLogic(contexto).DarDeBajaPaciente(paciente.Id, dialogo.Valor, _nombreUsuario);
                CargarDatos();
            }
            catch (Negocio.DomainModel.Exceptions.ValidacionNegocioException ex)
            {
                MostrarAviso(string.Join(Environment.NewLine, ex.Errores));
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "PacientesControl");
            }
        }

        private void AbrirHistoriaClinica(Paciente? paciente)
        {
            if (paciente == null)
            {
                MostrarAviso(Texto("pacientes.sinSeleccion"));
                return;
            }

            using var historia = new HistoriaClinicaForm(paciente, _nombreUsuario, _puedeEditarHistoria);
            historia.ShowDialog(FindForm());
        }

        private void MostrarAviso(string mensaje)
        {
            MessageBox.Show(FindForm(), mensaje, Texto("error.titulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
