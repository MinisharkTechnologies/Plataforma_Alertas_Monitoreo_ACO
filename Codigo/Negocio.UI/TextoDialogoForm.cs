using Services.Facade;

namespace Negocio.UI
{
    /// <summary>Diálogo genérico para solicitar un texto corto (por ejemplo, el motivo de una baja).</summary>
    public partial class TextoDialogoForm : Form
    {
        // Los controles de la interfaz se declaran en TextoDialogoForm.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        /// <summary>Texto ingresado, sin espacios sobrantes.</summary>
        public string Valor => _txtValor.Text.Trim();

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public TextoDialogoForm()
        {
            InitializeComponent();
        }

        public TextoDialogoForm(string titulo, string etiqueta) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se tocan los servicios:
            // alcanza con que los controles se hayan creado para que el formulario se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            Text = titulo;
            _lblEtiqueta.Text = etiqueta;
            _btnAceptar.Text = LocalizationService.ObtenerTexto("comun.aceptar");
            _btnCancelar.Text = LocalizationService.ObtenerTexto("comun.cancelar");
        }

        private void BtnAceptar_Click(object? sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void BtnCancelar_Click(object? sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
