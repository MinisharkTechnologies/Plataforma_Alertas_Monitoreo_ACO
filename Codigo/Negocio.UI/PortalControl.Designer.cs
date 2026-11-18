// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class PortalControl
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
            this._lblBienvenida = new System.Windows.Forms.Label();
            this._panelReporte = new System.Windows.Forms.Panel();
            this._lblReportar = new System.Windows.Forms.Label();
            this._lblValor = new System.Windows.Forms.Label();
            this._numValor = new System.Windows.Forms.NumericUpDown();
            this._lblFecha = new System.Windows.Forms.Label();
            this._dtpFecha = new System.Windows.Forms.DateTimePicker();
            this._lblCanal = new System.Windows.Forms.Label();
            this._lblCanalValor = new System.Windows.Forms.Label();
            this._btnEnviar = new System.Windows.Forms.Button();
            this._lblEstado = new System.Windows.Forms.Label();
            this._panelHistorial = new System.Windows.Forms.Panel();
            this._lblHistorial = new System.Windows.Forms.Label();
            this._grillaHistorial = new System.Windows.Forms.DataGridView();
            this._colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._numValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaHistorial)).BeginInit();
            this._panelReporte.SuspendLayout();
            this._panelHistorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // Estilos de la grilla
            // 
            estiloEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezado.ForeColor = System.Drawing.Color.White;
            estiloEncabezado.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloCelda.Font = new System.Drawing.Font("Segoe UI", 10F);
            estiloCelda.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCelda.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCelda.SelectionForeColor = System.Drawing.Color.Black;
            estiloCelda.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            estiloAlternado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            // 
            // _lblBienvenida
            // 
            this._lblBienvenida.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(120)))));
            this._lblBienvenida.Height = 44;
            this._lblBienvenida.Name = "_lblBienvenida";
            this._lblBienvenida.Padding = new System.Windows.Forms.Padding(6, 8, 0, 0);
            this._lblBienvenida.Text = "Hola,";
            // 
            // _panelReporte
            // 
            this._panelReporte.BackColor = System.Drawing.Color.White;
            this._panelReporte.Controls.Add(this._lblReportar);
            this._panelReporte.Controls.Add(this._lblValor);
            this._panelReporte.Controls.Add(this._numValor);
            this._panelReporte.Controls.Add(this._lblFecha);
            this._panelReporte.Controls.Add(this._dtpFecha);
            this._panelReporte.Controls.Add(this._lblCanal);
            this._panelReporte.Controls.Add(this._lblCanalValor);
            this._panelReporte.Controls.Add(this._btnEnviar);
            this._panelReporte.Controls.Add(this._lblEstado);
            this._panelReporte.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelReporte.Height = 156;
            this._panelReporte.Name = "_panelReporte";
            this._panelReporte.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            // 
            // _lblReportar
            // 
            this._lblReportar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblReportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._lblReportar.Location = new System.Drawing.Point(14, 10);
            this._lblReportar.Name = "_lblReportar";
            this._lblReportar.Size = new System.Drawing.Size(400, 22);
            this._lblReportar.Text = "Reportar mi RIN";
            // 
            // _lblValor
            // 
            this._lblValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblValor.Location = new System.Drawing.Point(14, 42);
            this._lblValor.Name = "_lblValor";
            this._lblValor.Size = new System.Drawing.Size(150, 16);
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
            this._numValor.Location = new System.Drawing.Point(14, 62);
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
            this._numValor.Name = "numValorPortal";
            this._numValor.Size = new System.Drawing.Size(140, 28);
            this._numValor.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            // 
            // _lblFecha
            // 
            this._lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblFecha.Location = new System.Drawing.Point(176, 42);
            this._lblFecha.Name = "_lblFecha";
            this._lblFecha.Size = new System.Drawing.Size(150, 16);
            this._lblFecha.Text = "Fecha de medición";
            // 
            // _dtpFecha
            // 
            this._dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpFecha.Location = new System.Drawing.Point(176, 62);
            this._dtpFecha.Name = "dtpFechaPortal";
            this._dtpFecha.Size = new System.Drawing.Size(150, 28);
            // 
            // _lblCanal
            // 
            this._lblCanal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblCanal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblCanal.Location = new System.Drawing.Point(348, 42);
            this._lblCanal.Name = "_lblCanal";
            this._lblCanal.Size = new System.Drawing.Size(150, 16);
            this._lblCanal.Text = "Canal de reporte";
            // 
            // _lblCanalValor
            // 
            this._lblCanalValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._lblCanalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this._lblCanalValor.Location = new System.Drawing.Point(348, 66);
            this._lblCanalValor.Name = "_lblCanalValor";
            this._lblCanalValor.Size = new System.Drawing.Size(160, 20);
            this._lblCanalValor.Text = "Digital (portal)";
            // 
            // _btnEnviar
            // 
            this._btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnEnviar.FlatAppearance.BorderSize = 0;
            this._btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEnviar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnEnviar.ForeColor = System.Drawing.Color.White;
            this._btnEnviar.Location = new System.Drawing.Point(520, 60);
            this._btnEnviar.Name = "_btnEnviar";
            this._btnEnviar.Size = new System.Drawing.Size(190, 34);
            this._btnEnviar.Text = "Enviar reporte";
            this._btnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // _lblEstado
            // 
            this._lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(75)))));
            this._lblEstado.Location = new System.Drawing.Point(14, 104);
            this._lblEstado.Name = "_lblEstado";
            this._lblEstado.Size = new System.Drawing.Size(900, 40);
            // 
            // _panelHistorial
            // 
            this._panelHistorial.BackColor = System.Drawing.Color.White;
            this._panelHistorial.Controls.Add(this._grillaHistorial);
            this._panelHistorial.Controls.Add(this._lblHistorial);
            this._panelHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelHistorial.Name = "_panelHistorial";
            this._panelHistorial.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            // 
            // _lblHistorial
            // 
            this._lblHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._lblHistorial.Height = 30;
            this._lblHistorial.Name = "_lblHistorial";
            this._lblHistorial.Text = "Mi historial clínico";
            // 
            // _grillaHistorial
            // 
            this._grillaHistorial.AllowUserToAddRows = false;
            this._grillaHistorial.AllowUserToDeleteRows = false;
            this._grillaHistorial.AllowUserToResizeRows = false;
            this._grillaHistorial.AlternatingRowsDefaultCellStyle = estiloAlternado;
            this._grillaHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grillaHistorial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._grillaHistorial.BackgroundColor = System.Drawing.Color.White;
            this._grillaHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grillaHistorial.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            this._grillaHistorial.ColumnHeadersHeight = 34;
            this._grillaHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colFecha,
            this._colTipo,
            this._colDescripcion});
            this._grillaHistorial.DefaultCellStyle = estiloCelda;
            this._grillaHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grillaHistorial.EnableHeadersVisualStyles = false;
            this._grillaHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grillaHistorial.MultiSelect = false;
            this._grillaHistorial.Name = "_grillaHistorial";
            this._grillaHistorial.ReadOnly = true;
            this._grillaHistorial.RowHeadersVisible = false;
            this._grillaHistorial.RowTemplate.Height = 32;
            this._grillaHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // _colFecha
            // 
            this._colFecha.FillWeight = 16F;
            this._colFecha.HeaderText = "Fecha";
            this._colFecha.Name = "fecha";
            // 
            // _colTipo
            // 
            this._colTipo.FillWeight = 16F;
            this._colTipo.HeaderText = "Tipo";
            this._colTipo.Name = "tipo";
            // 
            // _colDescripcion
            // 
            this._colDescripcion.FillWeight = 68F;
            this._colDescripcion.HeaderText = "Descripción";
            this._colDescripcion.Name = "descripcion";
            // 
            // PortalControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.Controls.Add(this._panelHistorial);
            this.Controls.Add(this._panelReporte);
            this.Controls.Add(this._lblBienvenida);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "PortalControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 6);
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this._numValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaHistorial)).EndInit();
            this._panelReporte.ResumeLayout(false);
            this._panelHistorial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblBienvenida;
        private System.Windows.Forms.Panel _panelReporte;
        private System.Windows.Forms.Label _lblReportar;
        private System.Windows.Forms.Label _lblValor;
        private System.Windows.Forms.NumericUpDown _numValor;
        private System.Windows.Forms.Label _lblFecha;
        private System.Windows.Forms.DateTimePicker _dtpFecha;
        private System.Windows.Forms.Label _lblCanal;
        private System.Windows.Forms.Label _lblCanalValor;
        private System.Windows.Forms.Button _btnEnviar;
        private System.Windows.Forms.Label _lblEstado;
        private System.Windows.Forms.Panel _panelHistorial;
        private System.Windows.Forms.Label _lblHistorial;
        private System.Windows.Forms.DataGridView _grillaHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDescripcion;
    }
}
