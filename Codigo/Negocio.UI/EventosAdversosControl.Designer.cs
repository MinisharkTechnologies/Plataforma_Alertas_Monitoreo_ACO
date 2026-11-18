// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class EventosAdversosControl
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
            this._lblDni = new System.Windows.Forms.Label();
            this._txtDni = new System.Windows.Forms.TextBox();
            this._btnBuscar = new System.Windows.Forms.Button();
            this._lblPaciente = new System.Windows.Forms.Label();
            this._btnRegistrar = new System.Windows.Forms.Button();
            this._grilla = new System.Windows.Forms.DataGridView();
            this._colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colGravedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lblSinEventos = new System.Windows.Forms.Label();
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezado = new System.Windows.Forms.DataGridViewCellStyle();
            estiloEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezado.ForeColor = System.Drawing.Color.White;
            estiloEncabezado.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            System.Windows.Forms.DataGridViewCellStyle estiloCeldas = new System.Windows.Forms.DataGridViewCellStyle();
            estiloCeldas.Font = new System.Drawing.Font("Segoe UI", 10F);
            estiloCeldas.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCeldas.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCeldas.SelectionForeColor = System.Drawing.Color.Black;
            estiloCeldas.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle estiloFilasAlt = new System.Windows.Forms.DataGridViewCellStyle();
            estiloFilasAlt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            System.Windows.Forms.DataGridViewCellStyle estiloFecha = new System.Windows.Forms.DataGridViewCellStyle();
            estiloFecha.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloTipo = new System.Windows.Forms.DataGridViewCellStyle();
            estiloTipo.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloGravedad = new System.Windows.Forms.DataGridViewCellStyle();
            estiloGravedad.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            ((System.ComponentModel.ISupportInitialize)(this._grilla)).BeginInit();
            this._panelBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelBarra
            // 
            this._panelBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelBarra.Controls.Add(this._lblDni);
            this._panelBarra.Controls.Add(this._txtDni);
            this._panelBarra.Controls.Add(this._btnBuscar);
            this._panelBarra.Controls.Add(this._lblPaciente);
            this._panelBarra.Controls.Add(this._btnRegistrar);
            this._panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBarra.Height = 64;
            this._panelBarra.Name = "_panelBarra";
            this._panelBarra.TabIndex = 2;
            // 
            // _lblDni
            // 
            this._lblDni.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblDni.Location = new System.Drawing.Point(0, 4);
            this._lblDni.Name = "_lblDni";
            this._lblDni.Size = new System.Drawing.Size(320, 18);
            this._lblDni.TabIndex = 0;
            this._lblDni.Text = "Identificación del paciente (DNI):";
            // 
            // _txtDni
            // 
            this._txtDni.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._txtDni.Location = new System.Drawing.Point(0, 24);
            this._txtDni.Name = "txtDniEvento";
            this._txtDni.Size = new System.Drawing.Size(180, 28);
            this._txtDni.TabIndex = 1;
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
            this._btnBuscar.Location = new System.Drawing.Point(190, 23);
            this._btnBuscar.Name = "_btnBuscar";
            this._btnBuscar.Size = new System.Drawing.Size(110, 30);
            this._btnBuscar.TabIndex = 2;
            this._btnBuscar.Text = "Buscar";
            this._btnBuscar.UseVisualStyleBackColor = false;
            this._btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // _lblPaciente
            // 
            this._lblPaciente.AutoEllipsis = true;
            this._lblPaciente.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this._lblPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(120)))));
            this._lblPaciente.Location = new System.Drawing.Point(314, 28);
            this._lblPaciente.Name = "_lblPaciente";
            this._lblPaciente.Size = new System.Drawing.Size(205, 24);
            this._lblPaciente.TabIndex = 3;
            this._lblPaciente.Text = "Últimos eventos registrados";
            // 
            // _btnRegistrar
            // 
            this._btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRegistrar.FlatAppearance.BorderSize = 0;
            this._btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnRegistrar.ForeColor = System.Drawing.Color.White;
            this._btnRegistrar.Location = new System.Drawing.Point(530, 15);
            this._btnRegistrar.Name = "_btnRegistrar";
            this._btnRegistrar.Size = new System.Drawing.Size(230, 34);
            this._btnRegistrar.TabIndex = 4;
            this._btnRegistrar.Text = "Registrar evento adverso";
            this._btnRegistrar.UseVisualStyleBackColor = false;
            this._btnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // _grilla
            // 
            this._grilla.AllowUserToAddRows = false;
            this._grilla.AllowUserToDeleteRows = false;
            this._grilla.AllowUserToResizeRows = false;
            this._grilla.AlternatingRowsDefaultCellStyle = estiloFilasAlt;
            this._grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._grilla.BackgroundColor = System.Drawing.Color.White;
            this._grilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grilla.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            this._grilla.ColumnHeadersHeight = 34;
            this._grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colFecha,
            this._colPaciente,
            this._colTipo,
            this._colGravedad,
            this._colDescripcion,
            this._colAccion});
            this._grilla.DefaultCellStyle = estiloCeldas;
            this._grilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grilla.EnableHeadersVisualStyles = false;
            this._grilla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grilla.MultiSelect = false;
            this._grilla.Name = "_grilla";
            this._grilla.ReadOnly = true;
            this._grilla.RowHeadersVisible = false;
            this._grilla.RowTemplate.Height = 32;
            this._grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grilla.TabIndex = 0;
            // 
            // _colFecha
            // 
            this._colFecha.DefaultCellStyle = estiloFecha;
            this._colFecha.FillWeight = 12F;
            this._colFecha.HeaderText = "Fecha";
            this._colFecha.Name = "fecha";
            // 
            // _colPaciente
            // 
            this._colPaciente.FillWeight = 20F;
            this._colPaciente.HeaderText = "Paciente";
            this._colPaciente.Name = "paciente";
            // 
            // _colTipo
            // 
            this._colTipo.DefaultCellStyle = estiloTipo;
            this._colTipo.FillWeight = 13F;
            this._colTipo.HeaderText = "Tipo de evento";
            this._colTipo.Name = "tipo";
            // 
            // _colGravedad
            // 
            this._colGravedad.DefaultCellStyle = estiloGravedad;
            this._colGravedad.FillWeight = 11F;
            this._colGravedad.HeaderText = "Gravedad";
            this._colGravedad.Name = "gravedad";
            // 
            // _colDescripcion
            // 
            this._colDescripcion.FillWeight = 22F;
            this._colDescripcion.HeaderText = "Descripción";
            this._colDescripcion.Name = "descripcion";
            // 
            // _colAccion
            // 
            this._colAccion.FillWeight = 22F;
            this._colAccion.HeaderText = "Acción tomada";
            this._colAccion.Name = "accion";
            // 
            // _lblSinEventos
            // 
            this._lblSinEventos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblSinEventos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblSinEventos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this._lblSinEventos.Height = 24;
            this._lblSinEventos.Name = "_lblSinEventos";
            this._lblSinEventos.TabIndex = 1;
            // 
            // EventosAdversosControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.Controls.Add(this._grilla);
            this.Controls.Add(this._lblSinEventos);
            this.Controls.Add(this._panelBarra);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "EventosAdversosControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 6);
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this._grilla)).EndInit();
            this._panelBarra.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelBarra;
        private System.Windows.Forms.Label _lblDni;
        private System.Windows.Forms.TextBox _txtDni;
        private System.Windows.Forms.Button _btnBuscar;
        private System.Windows.Forms.Label _lblPaciente;
        private System.Windows.Forms.Button _btnRegistrar;
        private System.Windows.Forms.DataGridView _grilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colGravedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAccion;
        private System.Windows.Forms.Label _lblSinEventos;
    }
}
