// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class PanelTriajeControl
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
            System.Windows.Forms.DataGridViewCellStyle estiloUltimoRin = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloDias = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloCriticidad = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloAlerta = new System.Windows.Forms.DataGridViewCellStyle();
            this._btnActualizar = new System.Windows.Forms.Button();
            this._lblRefresco = new System.Windows.Forms.Label();
            this._panelBarra = new System.Windows.Forms.Panel();
            this._panelLeyenda = new System.Windows.Forms.FlowLayoutPanel();
            this._grilla = new System.Windows.Forms.DataGridView();
            this._colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colUltimoRin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colCriticidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colAlerta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._temporizador = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._grilla)).BeginInit();
            this._panelBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // Estilos de la grilla
            // 
            estiloEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            estiloEncabezado.ForeColor = System.Drawing.Color.White;
            estiloEncabezado.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloCelda.Font = new System.Drawing.Font("Segoe UI", 11F);
            estiloCelda.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCelda.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCelda.SelectionForeColor = System.Drawing.Color.Black;
            estiloAlternado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            estiloUltimoRin.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloDias.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            estiloCriticidad.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            estiloAlerta.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            // 
            // _btnActualizar
            // 
            this._btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnActualizar.FlatAppearance.BorderSize = 0;
            this._btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnActualizar.ForeColor = System.Drawing.Color.White;
            this._btnActualizar.Location = new System.Drawing.Point(0, 4);
            this._btnActualizar.Name = "_btnActualizar";
            this._btnActualizar.Size = new System.Drawing.Size(130, 34);
            this._btnActualizar.Text = "Actualizar";
            this._btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // _lblRefresco
            // 
            this._lblRefresco.AutoSize = true;
            this._lblRefresco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblRefresco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(110)))), ((int)(((byte)(135)))));
            this._lblRefresco.Location = new System.Drawing.Point(146, 12);
            this._lblRefresco.Name = "_lblRefresco";
            this._lblRefresco.Text = "Actualizado:";
            // 
            // _panelBarra
            // 
            this._panelBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelBarra.Controls.Add(this._btnActualizar);
            this._panelBarra.Controls.Add(this._lblRefresco);
            this._panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBarra.Height = 46;
            this._panelBarra.Name = "_panelBarra";
            // 
            // _panelLeyenda
            // 
            this._panelLeyenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelLeyenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panelLeyenda.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this._panelLeyenda.Height = 44;
            this._panelLeyenda.Name = "_panelLeyenda";
            this._panelLeyenda.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this._panelLeyenda.WrapContents = false;
            // 
            // _grilla
            // 
            this._grilla.AllowUserToAddRows = false;
            this._grilla.AllowUserToDeleteRows = false;
            this._grilla.AllowUserToResizeRows = false;
            this._grilla.AlternatingRowsDefaultCellStyle = estiloAlternado;
            this._grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this._grilla.BackgroundColor = System.Drawing.Color.White;
            this._grilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grilla.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            this._grilla.ColumnHeadersHeight = 38;
            this._grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colPaciente,
            this._colDocumento,
            this._colUltimoRin,
            this._colFecha,
            this._colDias,
            this._colCriticidad,
            this._colAlerta});
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
            // 
            // _colPaciente
            // 
            this._colPaciente.FillWeight = 34F;
            this._colPaciente.HeaderText = "Paciente";
            this._colPaciente.Name = "paciente";
            // 
            // _colDocumento
            // 
            this._colDocumento.FillWeight = 16F;
            this._colDocumento.HeaderText = "Documento";
            this._colDocumento.Name = "documento";
            // 
            // _colUltimoRin
            // 
            this._colUltimoRin.DefaultCellStyle = estiloUltimoRin;
            this._colUltimoRin.FillWeight = 12F;
            this._colUltimoRin.HeaderText = "Último RIN";
            this._colUltimoRin.Name = "ultimoRin";
            // 
            // _colFecha
            // 
            this._colFecha.FillWeight = 14F;
            this._colFecha.HeaderText = "Último reporte";
            this._colFecha.Name = "fecha";
            // 
            // _colDias
            // 
            this._colDias.DefaultCellStyle = estiloDias;
            this._colDias.FillWeight = 14F;
            this._colDias.HeaderText = "Días sin reportar";
            this._colDias.Name = "dias";
            // 
            // _colCriticidad
            // 
            this._colCriticidad.DefaultCellStyle = estiloCriticidad;
            this._colCriticidad.FillWeight = 18F;
            this._colCriticidad.HeaderText = "Criticidad";
            this._colCriticidad.Name = "criticidad";
            // 
            // _colAlerta
            // 
            this._colAlerta.DefaultCellStyle = estiloAlerta;
            this._colAlerta.FillWeight = 8F;
            this._colAlerta.HeaderText = "Alerta";
            this._colAlerta.Name = "alerta";
            // 
            // _temporizador
            // 
            this._temporizador.Interval = 30000;
            this._temporizador.Tick += new System.EventHandler(this.Temporizador_Tick);
            // 
            // PanelTriajeControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.Controls.Add(this._grilla);
            this.Controls.Add(this._panelBarra);
            this.Controls.Add(this._panelLeyenda);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "PanelTriajeControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 6);
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this._grilla)).EndInit();
            this._panelBarra.ResumeLayout(false);
            this._panelBarra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnActualizar;
        private System.Windows.Forms.Label _lblRefresco;
        private System.Windows.Forms.Panel _panelBarra;
        private System.Windows.Forms.FlowLayoutPanel _panelLeyenda;
        private System.Windows.Forms.DataGridView _grilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colUltimoRin;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colCriticidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAlerta;
        private System.Windows.Forms.Timer _temporizador;
    }
}
