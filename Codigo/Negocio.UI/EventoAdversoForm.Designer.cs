// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class EventoAdversoForm
    {
        /// <summary>Contenedor de componentes del diseñador.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Libera los recursos usados por el formulario.</summary>
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
        /// controles y sus propiedades para que Visual Studio pueda dibujar el formulario
        /// en tiempo de diseño. No modificar a mano salvo que se sepa lo que se hace.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._lblPaciente = new System.Windows.Forms.Label();
            this._lblFecha = new System.Windows.Forms.Label();
            this._dtpFecha = new System.Windows.Forms.DateTimePicker();
            this._lblTipo = new System.Windows.Forms.Label();
            this._cmbTipo = new System.Windows.Forms.ComboBox();
            this._lblGravedad = new System.Windows.Forms.Label();
            this._cmbGravedad = new System.Windows.Forms.ComboBox();
            this._lblDescripcion = new System.Windows.Forms.Label();
            this._txtDescripcion = new System.Windows.Forms.TextBox();
            this._lblAccion = new System.Windows.Forms.Label();
            this._txtAccion = new System.Windows.Forms.TextBox();
            this._lblAviso = new System.Windows.Forms.Label();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblPaciente
            // 
            this._lblPaciente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(120)))));
            this._lblPaciente.Location = new System.Drawing.Point(18, 14);
            this._lblPaciente.Name = "_lblPaciente";
            this._lblPaciente.Size = new System.Drawing.Size(480, 24);
            this._lblPaciente.TabIndex = 0;
            this._lblPaciente.Text = "Nombre completo (DNI)";
            // 
            // _lblFecha
            // 
            this._lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblFecha.Location = new System.Drawing.Point(18, 48);
            this._lblFecha.Name = "_lblFecha";
            this._lblFecha.Size = new System.Drawing.Size(160, 18);
            this._lblFecha.TabIndex = 1;
            this._lblFecha.Text = "Fecha del evento";
            // 
            // _dtpFecha
            // 
            this._dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpFecha.Location = new System.Drawing.Point(18, 66);
            this._dtpFecha.Name = "_dtpFecha";
            this._dtpFecha.Size = new System.Drawing.Size(160, 28);
            this._dtpFecha.TabIndex = 2;
            this._dtpFecha.Value = new System.DateTime(2026, 11, 18, 0, 0, 0, 0);
            // 
            // _lblTipo
            // 
            this._lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblTipo.Location = new System.Drawing.Point(196, 48);
            this._lblTipo.Name = "_lblTipo";
            this._lblTipo.Size = new System.Drawing.Size(150, 18);
            this._lblTipo.TabIndex = 3;
            this._lblTipo.Text = "Tipo de evento";
            // 
            // _cmbTipo
            // 
            this._cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbTipo.Items.AddRange(new object[] {
            "Hemorragia",
            "Trombosis",
            "Reacción adversa",
            "Otro"});
            this._cmbTipo.Location = new System.Drawing.Point(196, 66);
            this._cmbTipo.Name = "_cmbTipo";
            this._cmbTipo.SelectedIndex = 0;
            this._cmbTipo.Size = new System.Drawing.Size(150, 28);
            this._cmbTipo.TabIndex = 4;
            // 
            // _lblGravedad
            // 
            this._lblGravedad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblGravedad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblGravedad.Location = new System.Drawing.Point(364, 48);
            this._lblGravedad.Name = "_lblGravedad";
            this._lblGravedad.Size = new System.Drawing.Size(138, 18);
            this._lblGravedad.TabIndex = 5;
            this._lblGravedad.Text = "Gravedad";
            // 
            // _cmbGravedad
            // 
            this._cmbGravedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbGravedad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbGravedad.Items.AddRange(new object[] {
            "Leve",
            "Moderada",
            "Grave"});
            this._cmbGravedad.Location = new System.Drawing.Point(364, 66);
            this._cmbGravedad.Name = "_cmbGravedad";
            this._cmbGravedad.SelectedIndex = 0;
            this._cmbGravedad.Size = new System.Drawing.Size(138, 28);
            this._cmbGravedad.TabIndex = 6;
            // 
            // _lblDescripcion
            // 
            this._lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblDescripcion.Location = new System.Drawing.Point(18, 106);
            this._lblDescripcion.Name = "_lblDescripcion";
            this._lblDescripcion.Size = new System.Drawing.Size(480, 18);
            this._lblDescripcion.TabIndex = 7;
            this._lblDescripcion.Text = "Descripción";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtDescripcion.Location = new System.Drawing.Point(18, 124);
            this._txtDescripcion.Multiline = true;
            this._txtDescripcion.Name = "txtDescripcionEvento";
            this._txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDescripcion.Size = new System.Drawing.Size(484, 62);
            this._txtDescripcion.TabIndex = 8;
            // 
            // _lblAccion
            // 
            this._lblAccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblAccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblAccion.Location = new System.Drawing.Point(18, 194);
            this._lblAccion.Name = "_lblAccion";
            this._lblAccion.Size = new System.Drawing.Size(480, 18);
            this._lblAccion.TabIndex = 9;
            this._lblAccion.Text = "Acción tomada";
            // 
            // _txtAccion
            // 
            this._txtAccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtAccion.Location = new System.Drawing.Point(18, 212);
            this._txtAccion.Multiline = true;
            this._txtAccion.Name = "txtAccionEvento";
            this._txtAccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtAccion.Size = new System.Drawing.Size(484, 62);
            this._txtAccion.TabIndex = 10;
            // 
            // _lblAviso
            // 
            this._lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._lblAviso.Location = new System.Drawing.Point(18, 280);
            this._lblAviso.Name = "_lblAviso";
            this._lblAviso.Size = new System.Drawing.Size(484, 42);
            this._lblAviso.TabIndex = 11;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnGuardar.FlatAppearance.BorderSize = 0;
            this._btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGuardar.ForeColor = System.Drawing.Color.White;
            this._btnGuardar.Location = new System.Drawing.Point(312, 334);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(90, 36);
            this._btnGuardar.TabIndex = 12;
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.Location = new System.Drawing.Point(410, 334);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(92, 36);
            this._btnCancelar.TabIndex = 13;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // EventoAdversoForm
            // 
            this.AcceptButton = this._btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(520, 400);
            this.Controls.Add(this._lblPaciente);
            this.Controls.Add(this._lblFecha);
            this.Controls.Add(this._lblTipo);
            this.Controls.Add(this._lblGravedad);
            this.Controls.Add(this._lblDescripcion);
            this.Controls.Add(this._lblAccion);
            this.Controls.Add(this._dtpFecha);
            this.Controls.Add(this._cmbTipo);
            this.Controls.Add(this._cmbGravedad);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this._txtAccion);
            this.Controls.Add(this._lblAviso);
            this.Controls.Add(this._btnGuardar);
            this.Controls.Add(this._btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventoAdversoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OpenRIN — Registrar evento adverso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblPaciente;
        private System.Windows.Forms.Label _lblFecha;
        private System.Windows.Forms.DateTimePicker _dtpFecha;
        private System.Windows.Forms.Label _lblTipo;
        private System.Windows.Forms.ComboBox _cmbTipo;
        private System.Windows.Forms.Label _lblGravedad;
        private System.Windows.Forms.ComboBox _cmbGravedad;
        private System.Windows.Forms.Label _lblDescripcion;
        private System.Windows.Forms.TextBox _txtDescripcion;
        private System.Windows.Forms.Label _lblAccion;
        private System.Windows.Forms.TextBox _txtAccion;
        private System.Windows.Forms.Label _lblAviso;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}
