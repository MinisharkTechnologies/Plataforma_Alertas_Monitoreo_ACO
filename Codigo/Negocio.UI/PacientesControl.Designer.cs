// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class PacientesControl
    {
        /// <summary>Contenedor de componentes del diseñador.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Libera los recursos usados por el control.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Método de inicio generado por el diseñador. Contiene la creación de todos los
        /// controles y sus propiedades para que Visual Studio pueda dibujar el control
        /// en tiempo de diseño. No modificar a mano salvo que se sepa lo que se hace.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezado = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloCelda = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloAlternado = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloEstado = new System.Windows.Forms.DataGridViewCellStyle();
            this._lblBuscar = new System.Windows.Forms.Label();
            this._txtBusqueda = new System.Windows.Forms.TextBox();
            this._btnBuscar = new System.Windows.Forms.Button();
            this._chkInactivos = new System.Windows.Forms.CheckBox();
            this._panelBarra = new System.Windows.Forms.Panel();
            this._flowAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this._btnHistoria = new System.Windows.Forms.Button();
            this._btnBaja = new System.Windows.Forms.Button();
            this._btnModificar = new System.Windows.Forms.Button();
            this._btnNuevo = new System.Windows.Forms.Button();
            this._grilla = new System.Windows.Forms.DataGridView();
            this._colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colFechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lblResultados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._grilla)).BeginInit();
            this._panelBarra.SuspendLayout();
            this._flowAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // Estilos de la grilla
            // 
            estiloEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            estiloEncabezado.ForeColor = System.Drawing.Color.White;
            estiloEncabezado.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloCelda.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            estiloCelda.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCelda.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCelda.SelectionForeColor = System.Drawing.Color.Black;
            estiloAlternado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            estiloEstado.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            // 
            // _lblBuscar
            // 
            this._lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblBuscar.Location = new System.Drawing.Point(0, 18);
            this._lblBuscar.Name = "_lblBuscar";
            this._lblBuscar.Size = new System.Drawing.Size(60, 20);
            this._lblBuscar.Text = "Buscar:";
            // 
            // _txtBusqueda
            // 
            this._txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtBusqueda.Location = new System.Drawing.Point(62, 14);
            this._txtBusqueda.Name = "_txtBusqueda";
            this._txtBusqueda.PlaceholderText = "Nombre o documento...";
            this._txtBusqueda.Size = new System.Drawing.Size(170, 28);
            this._txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBusqueda_KeyDown);
            // 
            // _btnBuscar
            // 
            this._btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnBuscar.FlatAppearance.BorderSize = 0;
            this._btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnBuscar.ForeColor = System.Drawing.Color.White;
            this._btnBuscar.Location = new System.Drawing.Point(240, 13);
            this._btnBuscar.Name = "_btnBuscar";
            this._btnBuscar.Size = new System.Drawing.Size(80, 30);
            this._btnBuscar.Text = "Buscar";
            this._btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // _chkInactivos
            // 
            this._chkInactivos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._chkInactivos.Location = new System.Drawing.Point(330, 17);
            this._chkInactivos.Name = "_chkInactivos";
            this._chkInactivos.Size = new System.Drawing.Size(115, 22);
            this._chkInactivos.Text = "Ver inactivos";
            this._chkInactivos.CheckedChanged += new System.EventHandler(this.ChkInactivos_CheckedChanged);
            // 
            // _btnHistoria
            // 
            this._btnHistoria.BackColor = System.Drawing.Color.White;
            this._btnHistoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnHistoria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnHistoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnHistoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnHistoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this._btnHistoria.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this._btnHistoria.Name = "_btnHistoria";
            this._btnHistoria.Size = new System.Drawing.Size(136, 34);
            this._btnHistoria.Text = "Historia clínica";
            this._btnHistoria.Click += new System.EventHandler(this.BtnHistoria_Click);
            // 
            // _btnBaja
            // 
            this._btnBaja.BackColor = System.Drawing.Color.White;
            this._btnBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnBaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnBaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this._btnBaja.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this._btnBaja.Name = "_btnBaja";
            this._btnBaja.Size = new System.Drawing.Size(136, 34);
            this._btnBaja.Text = "Dar de baja";
            this._btnBaja.Click += new System.EventHandler(this.BtnBaja_Click);
            // 
            // _btnModificar
            // 
            this._btnModificar.BackColor = System.Drawing.Color.White;
            this._btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this._btnModificar.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this._btnModificar.Name = "_btnModificar";
            this._btnModificar.Size = new System.Drawing.Size(136, 34);
            this._btnModificar.Text = "Modificar";
            this._btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // _btnNuevo
            // 
            this._btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnNuevo.FlatAppearance.BorderSize = 0;
            this._btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnNuevo.ForeColor = System.Drawing.Color.White;
            this._btnNuevo.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this._btnNuevo.Name = "_btnNuevo";
            this._btnNuevo.Size = new System.Drawing.Size(136, 34);
            this._btnNuevo.Text = "Alta de Paciente";
            this._btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // _flowAcciones
            // 
            this._flowAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._flowAcciones.Controls.Add(this._btnHistoria);
            this._flowAcciones.Controls.Add(this._btnBaja);
            this._flowAcciones.Controls.Add(this._btnModificar);
            this._flowAcciones.Controls.Add(this._btnNuevo);
            this._flowAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this._flowAcciones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._flowAcciones.Name = "_flowAcciones";
            this._flowAcciones.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this._flowAcciones.WrapContents = false;
            this._flowAcciones.Width = 560;
            // 
            // _panelBarra
            // 
            this._panelBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelBarra.Controls.Add(this._lblBuscar);
            this._panelBarra.Controls.Add(this._txtBusqueda);
            this._panelBarra.Controls.Add(this._btnBuscar);
            this._panelBarra.Controls.Add(this._chkInactivos);
            this._panelBarra.Controls.Add(this._flowAcciones);
            this._panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBarra.Height = 54;
            this._panelBarra.Name = "_panelBarra";
            // 
            // _grilla
            // 
            this._grilla.AllowUserToAddRows = false;
            this._grilla.AllowUserToDeleteRows = false;
            this._grilla.AllowUserToResizeRows = false;
            this._grilla.AlternatingRowsDefaultCellStyle = estiloAlternado;
            this._grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grilla.BackgroundColor = System.Drawing.Color.White;
            this._grilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grilla.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            this._grilla.ColumnHeadersHeight = 38;
            this._grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colNombre,
            this._colDocumento,
            this._colTelefono,
            this._colEmail,
            this._colObra,
            this._colEstado,
            this._colFechaAlta});
            this._grilla.DefaultCellStyle = estiloCelda;
            this._grilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grilla.EnableHeadersVisualStyles = false;
            this._grilla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grilla.MultiSelect = false;
            this._grilla.Name = "_grilla";
            this._grilla.ReadOnly = true;
            this._grilla.RowHeadersVisible = false;
            this._grilla.RowTemplate.Height = 34;
            this._grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grilla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellDoubleClick);
            this._grilla.SelectionChanged += new System.EventHandler(this.Grilla_SelectionChanged);
            // 
            // _colNombre
            // 
            this._colNombre.FillWeight = 26F;
            this._colNombre.HeaderText = "Nombre completo";
            this._colNombre.Name = "nombre";
            // 
            // _colDocumento
            // 
            this._colDocumento.FillWeight = 13F;
            this._colDocumento.HeaderText = "Documento (DNI)";
            this._colDocumento.Name = "documento";
            // 
            // _colTelefono
            // 
            this._colTelefono.FillWeight = 14F;
            this._colTelefono.HeaderText = "Teléfono";
            this._colTelefono.Name = "telefono";
            // 
            // _colEmail
            // 
            this._colEmail.FillWeight = 20F;
            this._colEmail.HeaderText = "Correo electrónico";
            this._colEmail.Name = "email";
            // 
            // _colObra
            // 
            this._colObra.FillWeight = 15F;
            this._colObra.HeaderText = "Obra social";
            this._colObra.Name = "obra";
            // 
            // _colEstado
            // 
            this._colEstado.DefaultCellStyle = estiloEstado;
            this._colEstado.FillWeight = 9F;
            this._colEstado.HeaderText = "Estado";
            this._colEstado.Name = "estado";
            // 
            // _colFechaAlta
            // 
            this._colFechaAlta.FillWeight = 12F;
            this._colFechaAlta.HeaderText = "Fecha de alta";
            this._colFechaAlta.Name = "fechaAlta";
            // 
            // _lblResultados
            // 
            this._lblResultados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblResultados.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(110)))), ((int)(((byte)(135)))));
            this._lblResultados.Height = 26;
            this._lblResultados.Name = "_lblResultados";
            this._lblResultados.Text = "0 paciente(s) encontrado(s)";
            this._lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PacientesControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.Controls.Add(this._grilla);
            this.Controls.Add(this._panelBarra);
            this.Controls.Add(this._lblResultados);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "PacientesControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 6);
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this._grilla)).EndInit();
            this._panelBarra.ResumeLayout(false);
            this._flowAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblBuscar;
        private System.Windows.Forms.TextBox _txtBusqueda;
        private System.Windows.Forms.Button _btnBuscar;
        private System.Windows.Forms.CheckBox _chkInactivos;
        private System.Windows.Forms.Panel _panelBarra;
        private System.Windows.Forms.FlowLayoutPanel _flowAcciones;
        private System.Windows.Forms.Button _btnHistoria;
        private System.Windows.Forms.Button _btnBaja;
        private System.Windows.Forms.Button _btnModificar;
        private System.Windows.Forms.Button _btnNuevo;
        private System.Windows.Forms.DataGridView _grilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colFechaAlta;
        private System.Windows.Forms.Label _lblResultados;
    }
}
