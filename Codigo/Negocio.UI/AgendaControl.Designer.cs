// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class AgendaControl
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
            this._panelBarra = new System.Windows.Forms.Panel();
            this._lblDesde = new System.Windows.Forms.Label();
            this._dtpDesde = new System.Windows.Forms.DateTimePicker();
            this._lblHasta = new System.Windows.Forms.Label();
            this._dtpHasta = new System.Windows.Forms.DateTimePicker();
            this._btnActualizar = new System.Windows.Forms.Button();
            this._btnAgendar = new System.Windows.Forms.Button();
            this._grillaTurnos = new System.Windows.Forms.DataGridView();
            this._colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lblSinTurnos = new System.Windows.Forms.Label();
            this._panelSugerencias = new System.Windows.Forms.Panel();
            this._lblSugerenciasTitulo = new System.Windows.Forms.Label();
            this._panelBotones = new System.Windows.Forms.Panel();
            this._btnAceptarSugerencia = new System.Windows.Forms.Button();
            this._btnRechazarSugerencia = new System.Windows.Forms.Button();
            this._lblInfoSugerencias = new System.Windows.Forms.Label();
            this._grillaSugerencias = new System.Windows.Forms.DataGridView();
            this._colSugTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colSugDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colSugA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezadoTurnos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloEncabezadoTurnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezadoTurnos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezadoTurnos.ForeColor = System.Drawing.Color.White;
            estiloEncabezadoTurnos.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            System.Windows.Forms.DataGridViewCellStyle estiloCeldasTurnos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloCeldasTurnos.Font = new System.Drawing.Font("Segoe UI", 10F);
            estiloCeldasTurnos.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCeldasTurnos.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCeldasTurnos.SelectionForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle estiloFilasAltTurnos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloFilasAltTurnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            System.Windows.Forms.DataGridViewCellStyle estiloEstadoColumna = new System.Windows.Forms.DataGridViewCellStyle();
            estiloEstadoColumna.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezadoSugerencias = new System.Windows.Forms.DataGridViewCellStyle();
            estiloEncabezadoSugerencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezadoSugerencias.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezadoSugerencias.ForeColor = System.Drawing.Color.White;
            estiloEncabezadoSugerencias.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            System.Windows.Forms.DataGridViewCellStyle estiloCeldasSugerencias = new System.Windows.Forms.DataGridViewCellStyle();
            estiloCeldasSugerencias.Font = new System.Drawing.Font("Segoe UI", 10F);
            estiloCeldasSugerencias.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCeldasSugerencias.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCeldasSugerencias.SelectionForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle estiloFilasAltSugerencias = new System.Windows.Forms.DataGridViewCellStyle();
            estiloFilasAltSugerencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            ((System.ComponentModel.ISupportInitialize)(this._grillaTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaSugerencias)).BeginInit();
            this._panelBarra.SuspendLayout();
            this._panelSugerencias.SuspendLayout();
            this._panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelBarra
            // 
            this._panelBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelBarra.Controls.Add(this._lblDesde);
            this._panelBarra.Controls.Add(this._dtpDesde);
            this._panelBarra.Controls.Add(this._lblHasta);
            this._panelBarra.Controls.Add(this._dtpHasta);
            this._panelBarra.Controls.Add(this._btnActualizar);
            this._panelBarra.Controls.Add(this._btnAgendar);
            this._panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBarra.Height = 58;
            this._panelBarra.Name = "_panelBarra";
            this._panelBarra.TabIndex = 3;
            // 
            // _lblDesde
            // 
            this._lblDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblDesde.Location = new System.Drawing.Point(0, 20);
            this._lblDesde.Name = "_lblDesde";
            this._lblDesde.Size = new System.Drawing.Size(50, 20);
            this._lblDesde.TabIndex = 0;
            this._lblDesde.Text = "Desde:";
            // 
            // _dtpDesde
            // 
            this._dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpDesde.Location = new System.Drawing.Point(54, 16);
            this._dtpDesde.Name = "_dtpDesde";
            this._dtpDesde.Size = new System.Drawing.Size(120, 28);
            this._dtpDesde.TabIndex = 1;
            this._dtpDesde.Value = System.DateTime.Today;
            // 
            // _lblHasta
            // 
            this._lblHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblHasta.Location = new System.Drawing.Point(188, 20);
            this._lblHasta.Name = "_lblHasta";
            this._lblHasta.Size = new System.Drawing.Size(50, 20);
            this._lblHasta.TabIndex = 2;
            this._lblHasta.Text = "Hasta:";
            // 
            // _dtpHasta
            // 
            this._dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpHasta.Location = new System.Drawing.Point(238, 16);
            this._dtpHasta.Name = "_dtpHasta";
            this._dtpHasta.Size = new System.Drawing.Size(120, 28);
            this._dtpHasta.TabIndex = 3;
            this._dtpHasta.Value = System.DateTime.Today.AddDays(30);
            // 
            // _btnActualizar
            // 
            this._btnActualizar.BackColor = System.Drawing.Color.White;
            this._btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnActualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this._btnActualizar.Location = new System.Drawing.Point(374, 15);
            this._btnActualizar.Name = "_btnActualizar";
            this._btnActualizar.Size = new System.Drawing.Size(160, 30);
            this._btnActualizar.TabIndex = 4;
            this._btnActualizar.Text = "Actualizar agenda";
            this._btnActualizar.UseVisualStyleBackColor = false;
            this._btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // _btnAgendar
            // 
            this._btnAgendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnAgendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAgendar.FlatAppearance.BorderSize = 0;
            this._btnAgendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAgendar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnAgendar.ForeColor = System.Drawing.Color.White;
            this._btnAgendar.Location = new System.Drawing.Point(546, 15);
            this._btnAgendar.Name = "_btnAgendar";
            this._btnAgendar.Size = new System.Drawing.Size(170, 32);
            this._btnAgendar.TabIndex = 5;
            this._btnAgendar.Text = "Agendar turno";
            this._btnAgendar.UseVisualStyleBackColor = false;
            this._btnAgendar.Click += new System.EventHandler(this.BtnAgendar_Click);
            // 
            // _grillaTurnos
            // 
            this._grillaTurnos.AllowUserToAddRows = false;
            this._grillaTurnos.AllowUserToDeleteRows = false;
            this._grillaTurnos.AllowUserToResizeRows = false;
            this._grillaTurnos.AlternatingRowsDefaultCellStyle = estiloFilasAltTurnos;
            this._grillaTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grillaTurnos.BackgroundColor = System.Drawing.Color.White;
            this._grillaTurnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grillaTurnos.ColumnHeadersDefaultCellStyle = estiloEncabezadoTurnos;
            this._grillaTurnos.ColumnHeadersHeight = 34;
            this._grillaTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colFechaHora,
            this._colPaciente,
            this._colMedico,
            this._colEstado,
            this._colObservaciones});
            this._grillaTurnos.DefaultCellStyle = estiloCeldasTurnos;
            this._grillaTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grillaTurnos.EnableHeadersVisualStyles = false;
            this._grillaTurnos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grillaTurnos.MultiSelect = false;
            this._grillaTurnos.Name = "_grillaTurnos";
            this._grillaTurnos.ReadOnly = true;
            this._grillaTurnos.RowHeadersVisible = false;
            this._grillaTurnos.RowTemplate.Height = 32;
            this._grillaTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grillaTurnos.TabIndex = 0;
            // 
            // _colFechaHora
            // 
            this._colFechaHora.FillWeight = 18F;
            this._colFechaHora.HeaderText = "Fecha y hora";
            this._colFechaHora.Name = "fechaHora";
            // 
            // _colPaciente
            // 
            this._colPaciente.FillWeight = 24F;
            this._colPaciente.HeaderText = "Paciente";
            this._colPaciente.Name = "paciente";
            // 
            // _colMedico
            // 
            this._colMedico.FillWeight = 22F;
            this._colMedico.HeaderText = "Médico";
            this._colMedico.Name = "medico";
            // 
            // _colEstado
            // 
            this._colEstado.DefaultCellStyle = estiloEstadoColumna;
            this._colEstado.FillWeight = 14F;
            this._colEstado.HeaderText = "Estado";
            this._colEstado.Name = "estado";
            // 
            // _colObservaciones
            // 
            this._colObservaciones.FillWeight = 22F;
            this._colObservaciones.HeaderText = "Observaciones";
            this._colObservaciones.Name = "observaciones";
            // 
            // _lblSinTurnos
            // 
            this._lblSinTurnos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblSinTurnos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblSinTurnos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this._lblSinTurnos.Height = 24;
            this._lblSinTurnos.Name = "_lblSinTurnos";
            this._lblSinTurnos.TabIndex = 1;
            // 
            // _panelSugerencias
            // 
            this._panelSugerencias.BackColor = System.Drawing.Color.White;
            this._panelSugerencias.Controls.Add(this._grillaSugerencias);
            this._panelSugerencias.Controls.Add(this._panelBotones);
            this._panelSugerencias.Controls.Add(this._lblSugerenciasTitulo);
            this._panelSugerencias.Dock = System.Windows.Forms.DockStyle.Right;
            this._panelSugerencias.Name = "_panelSugerencias";
            this._panelSugerencias.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this._panelSugerencias.TabIndex = 2;
            this._panelSugerencias.Width = 480;
            // 
            // _lblSugerenciasTitulo
            // 
            this._lblSugerenciasTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblSugerenciasTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblSugerenciasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._lblSugerenciasTitulo.Height = 32;
            this._lblSugerenciasTitulo.Name = "_lblSugerenciasTitulo";
            this._lblSugerenciasTitulo.TabIndex = 2;
            this._lblSugerenciasTitulo.Text = "Sugerencias de reasignación";
            // 
            // _panelBotones
            // 
            this._panelBotones.BackColor = System.Drawing.Color.White;
            this._panelBotones.Controls.Add(this._btnAceptarSugerencia);
            this._panelBotones.Controls.Add(this._btnRechazarSugerencia);
            this._panelBotones.Controls.Add(this._lblInfoSugerencias);
            this._panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panelBotones.Height = 96;
            this._panelBotones.Name = "_panelBotones";
            this._panelBotones.TabIndex = 1;
            // 
            // _btnAceptarSugerencia
            // 
            this._btnAceptarSugerencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnAceptarSugerencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAceptarSugerencia.FlatAppearance.BorderSize = 0;
            this._btnAceptarSugerencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAceptarSugerencia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnAceptarSugerencia.ForeColor = System.Drawing.Color.White;
            this._btnAceptarSugerencia.Location = new System.Drawing.Point(0, 6);
            this._btnAceptarSugerencia.Name = "_btnAceptarSugerencia";
            this._btnAceptarSugerencia.Size = new System.Drawing.Size(220, 36);
            this._btnAceptarSugerencia.TabIndex = 0;
            this._btnAceptarSugerencia.Text = "Aceptar";
            this._btnAceptarSugerencia.UseVisualStyleBackColor = false;
            this._btnAceptarSugerencia.Click += new System.EventHandler(this.BtnAceptarSugerencia_Click);
            // 
            // _btnRechazarSugerencia
            // 
            this._btnRechazarSugerencia.BackColor = System.Drawing.Color.White;
            this._btnRechazarSugerencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRechazarSugerencia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnRechazarSugerencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRechazarSugerencia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnRechazarSugerencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this._btnRechazarSugerencia.Location = new System.Drawing.Point(232, 6);
            this._btnRechazarSugerencia.Name = "_btnRechazarSugerencia";
            this._btnRechazarSugerencia.Size = new System.Drawing.Size(220, 36);
            this._btnRechazarSugerencia.TabIndex = 1;
            this._btnRechazarSugerencia.Text = "Rechazar";
            this._btnRechazarSugerencia.UseVisualStyleBackColor = false;
            this._btnRechazarSugerencia.Click += new System.EventHandler(this.BtnRechazarSugerencia_Click);
            // 
            // _lblInfoSugerencias
            // 
            this._lblInfoSugerencias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblInfoSugerencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this._lblInfoSugerencias.Location = new System.Drawing.Point(0, 52);
            this._lblInfoSugerencias.Name = "_lblInfoSugerencias";
            this._lblInfoSugerencias.Size = new System.Drawing.Size(452, 36);
            this._lblInfoSugerencias.TabIndex = 2;
            // 
            // _grillaSugerencias
            // 
            this._grillaSugerencias.AllowUserToAddRows = false;
            this._grillaSugerencias.AllowUserToDeleteRows = false;
            this._grillaSugerencias.AllowUserToResizeRows = false;
            this._grillaSugerencias.AlternatingRowsDefaultCellStyle = estiloFilasAltSugerencias;
            this._grillaSugerencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grillaSugerencias.BackgroundColor = System.Drawing.Color.White;
            this._grillaSugerencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grillaSugerencias.ColumnHeadersDefaultCellStyle = estiloEncabezadoSugerencias;
            this._grillaSugerencias.ColumnHeadersHeight = 34;
            this._grillaSugerencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colSugTurno,
            this._colSugDe,
            this._colSugA});
            this._grillaSugerencias.DefaultCellStyle = estiloCeldasSugerencias;
            this._grillaSugerencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grillaSugerencias.EnableHeadersVisualStyles = false;
            this._grillaSugerencias.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grillaSugerencias.MultiSelect = false;
            this._grillaSugerencias.Name = "_grillaSugerencias";
            this._grillaSugerencias.ReadOnly = true;
            this._grillaSugerencias.RowHeadersVisible = false;
            this._grillaSugerencias.RowTemplate.Height = 32;
            this._grillaSugerencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grillaSugerencias.TabIndex = 0;
            // 
            // _colSugTurno
            // 
            this._colSugTurno.FillWeight = 26F;
            this._colSugTurno.HeaderText = "Fecha y hora";
            this._colSugTurno.Name = "turno";
            // 
            // _colSugDe
            // 
            this._colSugDe.FillWeight = 37F;
            this._colSugDe.HeaderText = "De (estable)";
            this._colSugDe.Name = "de";
            // 
            // _colSugA
            // 
            this._colSugA.FillWeight = 37F;
            this._colSugA.HeaderText = "A (crítico)";
            this._colSugA.Name = "a";
            // 
            // AgendaControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.Controls.Add(this._grillaTurnos);
            this.Controls.Add(this._lblSinTurnos);
            this.Controls.Add(this._panelSugerencias);
            this.Controls.Add(this._panelBarra);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "AgendaControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 6);
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this._grillaTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaSugerencias)).EndInit();
            this._panelBotones.ResumeLayout(false);
            this._panelSugerencias.ResumeLayout(false);
            this._panelBarra.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelBarra;
        private System.Windows.Forms.Label _lblDesde;
        private System.Windows.Forms.DateTimePicker _dtpDesde;
        private System.Windows.Forms.Label _lblHasta;
        private System.Windows.Forms.DateTimePicker _dtpHasta;
        private System.Windows.Forms.Button _btnActualizar;
        private System.Windows.Forms.Button _btnAgendar;
        private System.Windows.Forms.DataGridView _grillaTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colObservaciones;
        private System.Windows.Forms.Label _lblSinTurnos;
        private System.Windows.Forms.Panel _panelSugerencias;
        private System.Windows.Forms.Label _lblSugerenciasTitulo;
        private System.Windows.Forms.Panel _panelBotones;
        private System.Windows.Forms.Button _btnAceptarSugerencia;
        private System.Windows.Forms.Button _btnRechazarSugerencia;
        private System.Windows.Forms.Label _lblInfoSugerencias;
        private System.Windows.Forms.DataGridView _grillaSugerencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colSugTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colSugDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colSugA;
    }
}
