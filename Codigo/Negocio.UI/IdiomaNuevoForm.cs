using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Alta de idioma (T05): diálogo con código y nombre para incorporar un idioma nuevo
    /// desde la administración del sistema. La creación efectiva la realiza la fachada de
    /// localización, que valida y audita la operación.
    /// </summary>
    public sealed partial class IdiomaNuevoForm : Form
    {
        // Los controles de la interfaz se declaran en IdiomaNuevoForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Crea el diálogo de alta de idioma.</summary>
        public IdiomaNuevoForm()
        {
            InitializeComponent();

            // En tiempo de diseño (diseñador de Visual Studio) no se tocan los servicios:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            System.Drawing.Icon? icono = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (icono != null)
            {
                Icon = icono;
            }

            AplicarTextos();
        }

        /// <summary>Aplica al diálogo los textos localizados (se conserva el comportamiento original).</summary>
        private void AplicarTextos()
        {
            Text = LocalizationService.ObtenerTexto("idiomas.nuevo");
            _lblCodigo.Text = LocalizationService.ObtenerTexto("idiomas.codigo");
            _lblNombre.Text = LocalizationService.ObtenerTexto("idiomas.nombre");
            _btnGuardar.Text = LocalizationService.ObtenerTexto("comun.aceptar");
            _btnCancelar.Text = LocalizationService.ObtenerTexto("comun.cancelar");
        }

        private void BtnGuardar_Click(object? sender, EventArgs e) => Guardar();

        private void BtnCancelar_Click(object? sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void Guardar()
        {
            try
            {
                LocalizationService.RegistrarIdioma(_txtCodigo.Text, _txtNombre.Text);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Services.Facade.ExceptionManager.ManejarExcepcion(ex, "Alta de idioma", mostrarMensaje: false);
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
