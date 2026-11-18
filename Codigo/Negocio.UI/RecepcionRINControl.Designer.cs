// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class RecepcionRINControl
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
            System.Windows.Forms.DataGridViewCellStyle estiloValor = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloCriticidad = new System.Windows.Forms.DataGridViewCellStyle();
            this._panelBusqueda = new System.Windows.Forms.Panel();
            this._lblIdentificacion = new System.Windows.Forms.Label();
            this._txtDni = new System.Windows.Forms.TextBox();
            this._btnBuscar = new System.Windows.Forms.Button();
            this._lblAviso = new System.Windows.Forms.Label();
            this._panelFicha = new System.Windows.Forms.Panel();
            this._lblFicha = new System.Windows.Forms.Label();
            this._panelDerecho = new System.Windows.Forms.Panel();
            this._lblValor = new System.Windows.Forms.Label();
            this._numValor = new System.Windows.Forms.NumericUpDown();
            this._lblFecha = new System.Windows.Forms.Label();
            this._dtpFecha = new System.Windows.Forms.DateTimePicker();
            this._lblCanal = new System.Windows.Forms.Label();
            this._cmbCanal = new System.Windows.Forms.ComboBox();
            this._btnReportar = new System.Windows.Forms.Button();
            this._lblResultado = new System.Windows.Forms.Label();
            this._lblHistorial = new System.Windows.Forms.Label();
            this._grillaHistorial = new System.Windows.Forms.DataGridView();
            this._colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colCanal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colCriticidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._numValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaHistorial)).BeginInit();
            this._panelBusqueda.SuspendLayout();
            this._panelFicha.SuspendLayout();
            this._panelDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // Estilos de la grilla
            // 
            estiloEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezado.ForeColor = System.Drawing.Color.White;
            estiloEncabezado.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloCelda.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            estiloCelda.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCelda.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCelda.SelectionForeColor = System.Drawing.Color.Black;
            estiloAlternado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            estiloValor.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloCriticidad.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            // 
            // _panelBusqueda
            // 
            this._panelBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelBusqueda.Controls.Add(this._lblIdentificacion);
            this._panelBusqueda.Controls.Add(this._txtDni);
            this._panelBusqueda.Controls.Add(this._btnBuscar);
            this._panelBusqueda.Controls.Add(this._lblAviso);
            this._panelBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBusqueda.Height = 64;
            this._panelBusqueda.Name = "_panelBusqueda";
            // 
            // _lblIdentificacion
            // 
            this._lblIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblIdentificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblIdentificacion.Location = new System.Drawing.Point(0, 4);
            this._lblIdentificacion.Name = "_lblIdentificacion";
            this._lblIdentificacion.Size = new System.Drawing.Size(320, 18);
            this._lblIdentificacion.Text = "Identificación del paciente (DNI):";
            // 
            // _txtDni
            // 
            this._txtDni.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._txtDni.Location = new System.Drawing.Point(0, 26);
            this._txtDni.Name = "txtDni";
            this._txtDni.Size = new System.Drawing.Size(200, 28);
            this._txtDni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDni_KeyDown);
            // 
            // _btnBuscar
            // 
            this._btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnBuscar.FlatAppearance.BorderSize = 0;
            this._btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnBuscar.ForeColor = System.Drawing.Color.White;
            this._btnBuscar.Location = new System.Drawing.Point(212, 25);
            this._btnBuscar.Name = "btnBuscar";
            this._btnBuscar.Size = new System.Drawing.Size(110, 30);
            this._btnBuscar.Text = "Buscar";
            this._btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // _lblAviso
            // 
            this._lblAviso.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._lblAviso.Location = new System.Drawing.Point(336, 32);
            this._lblAviso.Name = "_lblAviso";
            this._lblAviso.Size = new System.Drawing.Size(700, 22);
            // 
            // _panelFicha
            // 
            this._panelFicha.BackColor = System.Drawing.Color.White;
            this._panelFicha.Controls.Add(this._lblFicha);
            this._panelFicha.Dock = System.Windows.Forms.DockStyle.Left;
            this._panelFicha.Name = "_panelFicha";
            this._panelFicha.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this._panelFicha.Width = 380;
            // 
            // _lblFicha
            // 
            this._lblFicha.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblFicha.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._lblFicha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this._lblFicha.Name = "_lblFicha";
            // 
            // _panelDerecho
            // 
            this._panelDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelDerecho.Controls.Add(this._lblValor);
            this._panelDerecho.Controls.Add(this._numValor);
            this._panelDerecho.Controls.Add(this._lblFecha);
            this._panelDerecho.Controls.Add(this._dtpFecha);
            this._panelDerecho.Controls.Add(this._lblCanal);
            this._panelDerecho.Controls.Add(this._cmbCanal);
            this._panelDerecho.Controls.Add(this._btnReportar);
            this._panelDerecho.Controls.Add(this._lblResultado);
            this._panelDerecho.Controls.Add(this._lblHistorial);
            this._panelDerecho.Controls.Add(this._grillaHistorial);
            this._panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelDerecho.Name = "_panelDerecho";
            // 
            // _lblValor
            // 
            this._lblValor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblValor.Location = new System.Drawing.Point(10, 0);
            this._lblValor.Name = "_lblValor";
            this._lblValor.Size = new System.Drawing.Size(160, 18);
            this._lblValor.Text = "Valor de RIN";
            // 
            // _numValor
            // 
            this._numValor.DecimalPlaces = 2;
            this._numValor.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._numValor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._numValor.Location = new System.Drawing.Point(10, 20);
            this._numValor.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._numValor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._numValor.Name = "numValor";
            this._numValor.Size = new System.Drawing.Size(140, 28);
            this._numValor.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            // 
            // _lblFecha
            // 
            this._lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblFecha.Location = new System.Drawing.Point(170, 0);
            this._lblFecha.Name = "_lblFecha";
            this._lblFecha.Size = new System.Drawing.Size(160, 18);
            this._lblFecha.Text = "Fecha de medición";
            // 
            // _dtpFecha
            // 
            this._dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpFecha.Location = new System.Drawing.Point(170, 20);
            this._dtpFecha.Name = "dtpFecha";
            this._dtpFecha.Size = new System.Drawing.Size(150, 28);
            // 
            // _lblCanal
            // 
            this._lblCanal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblCanal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblCanal.Location = new System.Drawing.Point(340, 0);
            this._lblCanal.Name = "_lblCanal";
            this._lblCanal.Size = new System.Drawing.Size(200, 18);
            this._lblCanal.Text = "Canal de reporte";
            // 
            // _cmbCanal
            // 
            this._cmbCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCanal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbCanal.Location = new System.Drawing.Point(340, 20);
            this._cmbCanal.Name = "cmbCanal";
            this._cmbCanal.Size = new System.Drawing.Size(220, 28);
            // 
            // _btnReportar
            // 
            this._btnReportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnReportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnReportar.FlatAppearance.BorderSize = 0;
            this._btnReportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnReportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnReportar.ForeColor = System.Drawing.Color.White;
            this._btnReportar.Location = new System.Drawing.Point(580, 18);
            this._btnReportar.Name = "btnReportar";
            this._btnReportar.Size = new System.Drawing.Size(160, 34);
            this._btnReportar.Text = "Reportar RIN";
            this._btnReportar.Click += new System.EventHandler(this.BtnReportar_Click);
            // 
            // _lblResultado
            // 
            this._lblResultado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this._lblResultado.Location = new System.Drawing.Point(10, 66);
            this._lblResultado.Name = "_lblResultado";
            this._lblResultado.Size = new System.Drawing.Size(730, 96);
            this._lblResultado.Text = "Busque un paciente y cargue un valor de RIN.";
            // 
            // _lblHistorial
            // 
            this._lblHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblHistorial.Location = new System.Drawing.Point(10, 170);
            this._lblHistorial.Name = "_lblHistorial";
            this._lblHistorial.Size = new System.Drawing.Size(300, 18);
            this._lblHistorial.Text = "Últimas mediciones";
            // 
            // _grillaHistorial
            // 
            this._grillaHistorial.AllowUserToAddRows = false;
            this._grillaHistorial.AllowUserToDeleteRows = false;
            this._grillaHistorial.AllowUserToResizeRows = false;
            this._grillaHistorial.AlternatingRowsDefaultCellStyle = estiloAlternado;
            this._grillaHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grillaHistorial.BackgroundColor = System.Drawing.Color.White;
            this._grillaHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grillaHistorial.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            this._grillaHistorial.ColumnHeadersHeight = 34;
            this._grillaHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colFecha,
            this._colValor,
            this._colCanal,
            this._colCriticidad});
            this._grillaHistorial.DefaultCellStyle = estiloCelda;
            this._grillaHistorial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._grillaHistorial.EnableHeadersVisualStyles = false;
            this._grillaHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grillaHistorial.Height = 210;
            this._grillaHistorial.MultiSelect = false;
            this._grillaHistorial.Name = "_grillaHistorial";
            this._grillaHistorial.ReadOnly = true;
            this._grillaHistorial.RowHeadersVisible = false;
            this._grillaHistorial.RowTemplate.Height = 32;
            this._grillaHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // _colFecha
            // 
            this._colFecha.FillWeight = 22F;
            this._colFecha.HeaderText = "Fecha";
            this._colFecha.Name = "fecha";
            // 
            // _colValor
            // 
            this._colValor.DefaultCellStyle = estiloValor;
            this._colValor.FillWeight = 16F;
            this._colValor.HeaderText = "Valor";
            this._colValor.Name = "valor";
            // 
            // _colCanal
            // 
            this._colCanal.FillWeight = 32F;
            this._colCanal.HeaderText = "Canal";
            this._colCanal.Name = "canal";
            // 
            // _colCriticidad
            // 
            this._colCriticidad.DefaultCellStyle = estiloCriticidad;
            this._colCriticidad.FillWeight = 30F;
            this._colCriticidad.HeaderText = "Criticidad";
            this._colCriticidad.Name = "criticidad";
            // 
            // RecepcionRINControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.Controls.Add(this._panelDerecho);
            this.Controls.Add(this._panelFicha);
            this.Controls.Add(this._panelBusqueda);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "RecepcionRINControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 6);
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this._numValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaHistorial)).EndInit();
            this._panelBusqueda.ResumeLayout(false);
            this._panelBusqueda.PerformLayout();
            this._panelFicha.ResumeLayout(false);
            this._panelDerecho.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelBusqueda;
        private System.Windows.Forms.Label _lblIdentificacion;
        private System.Windows.Forms.TextBox _txtDni;
        private System.Windows.Forms.Button _btnBuscar;
        private System.Windows.Forms.Label _lblAviso;
        private System.Windows.Forms.Panel _panelFicha;
        private System.Windows.Forms.Label _lblFicha;
        private System.Windows.Forms.Panel _panelDerecho;
        private System.Windows.Forms.Label _lblValor;
        private System.Windows.Forms.NumericUpDown _numValor;
        private System.Windows.Forms.Label _lblFecha;
        private System.Windows.Forms.DateTimePicker _dtpFecha;
        private System.Windows.Forms.Label _lblCanal;
        private System.Windows.Forms.ComboBox _cmbCanal;
        private System.Windows.Forms.Button _btnReportar;
        private System.Windows.Forms.Label _lblResultado;
        private System.Windows.Forms.Label _lblHistorial;
        private System.Windows.Forms.DataGridView _grillaHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colCanal;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colCriticidad;
    }
}
