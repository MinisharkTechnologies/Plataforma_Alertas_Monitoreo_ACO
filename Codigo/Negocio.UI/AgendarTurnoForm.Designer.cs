// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class AgendarTurnoForm
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
            this._cmbPaciente = new System.Windows.Forms.ComboBox();
            this._lblMedico = new System.Windows.Forms.Label();
            this._cmbMedico = new System.Windows.Forms.ComboBox();
            this._lblFecha = new System.Windows.Forms.Label();
            this._dtpFecha = new System.Windows.Forms.DateTimePicker();
            this._lblHora = new System.Windows.Forms.Label();
            this._dtpHora = new System.Windows.Forms.DateTimePicker();
            this._lblObservaciones = new System.Windows.Forms.Label();
            this._txtObservaciones = new System.Windows.Forms.TextBox();
            this._lblAviso = new System.Windows.Forms.Label();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblPaciente
            // 
            this._lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblPaciente.Location = new System.Drawing.Point(18, 14);
            this._lblPaciente.Name = "_lblPaciente";
            this._lblPaciente.Size = new System.Drawing.Size(210, 18);
            this._lblPaciente.TabIndex = 0;
            this._lblPaciente.Text = "Paciente";
            // 
            // _cmbPaciente
            // 
            this._cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbPaciente.Location = new System.Drawing.Point(18, 34);
            this._cmbPaciente.Name = "_cmbPaciente";
            this._cmbPaciente.Size = new System.Drawing.Size(444, 28);
            this._cmbPaciente.TabIndex = 1;
            // 
            // _lblMedico
            // 
            this._lblMedico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblMedico.Location = new System.Drawing.Point(18, 70);
            this._lblMedico.Name = "_lblMedico";
            this._lblMedico.Size = new System.Drawing.Size(210, 18);
            this._lblMedico.TabIndex = 2;
            this._lblMedico.Text = "Médico";
            // 
            // _cmbMedico
            // 
            this._cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbMedico.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbMedico.Location = new System.Drawing.Point(18, 90);
            this._cmbMedico.Name = "_cmbMedico";
            this._cmbMedico.Size = new System.Drawing.Size(280, 28);
            this._cmbMedico.TabIndex = 3;
            // 
            // _lblFecha
            // 
            this._lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblFecha.Location = new System.Drawing.Point(310, 70);
            this._lblFecha.Name = "_lblFecha";
            this._lblFecha.Size = new System.Drawing.Size(210, 18);
            this._lblFecha.TabIndex = 4;
            this._lblFecha.Text = "Fecha";
            // 
            // _dtpFecha
            // 
            this._dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpFecha.Location = new System.Drawing.Point(310, 90);
            this._dtpFecha.Name = "_dtpFecha";
            this._dtpFecha.Size = new System.Drawing.Size(120, 28);
            this._dtpFecha.TabIndex = 5;
            this._dtpFecha.Value = new System.DateTime(2026, 11, 19, 0, 0, 0, 0);
            // 
            // _lblHora
            // 
            this._lblHora.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblHora.Location = new System.Drawing.Point(18, 128);
            this._lblHora.Name = "_lblHora";
            this._lblHora.Size = new System.Drawing.Size(120, 18);
            this._lblHora.TabIndex = 6;
            this._lblHora.Text = "Hora";
            // 
            // _dtpHora
            // 
            this._dtpHora.CustomFormat = "HH:mm";
            this._dtpHora.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpHora.Location = new System.Drawing.Point(18, 148);
            this._dtpHora.Name = "_dtpHora";
            this._dtpHora.ShowUpDown = true;
            this._dtpHora.Size = new System.Drawing.Size(110, 28);
            this._dtpHora.TabIndex = 7;
            // 
            // _lblObservaciones
            // 
            this._lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblObservaciones.Location = new System.Drawing.Point(144, 128);
            this._lblObservaciones.Name = "_lblObservaciones";
            this._lblObservaciones.Size = new System.Drawing.Size(318, 18);
            this._lblObservaciones.TabIndex = 8;
            this._lblObservaciones.Text = "Observaciones";
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtObservaciones.Location = new System.Drawing.Point(144, 148);
            this._txtObservaciones.Name = "_txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(318, 28);
            this._txtObservaciones.TabIndex = 9;
            // 
            // _lblAviso
            // 
            this._lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._lblAviso.Location = new System.Drawing.Point(18, 186);
            this._lblAviso.Name = "_lblAviso";
            this._lblAviso.Size = new System.Drawing.Size(444, 40);
            this._lblAviso.TabIndex = 10;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnGuardar.FlatAppearance.BorderSize = 0;
            this._btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGuardar.ForeColor = System.Drawing.Color.White;
            this._btnGuardar.Location = new System.Drawing.Point(276, 236);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(90, 36);
            this._btnGuardar.TabIndex = 11;
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.Location = new System.Drawing.Point(374, 236);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(90, 36);
            this._btnCancelar.TabIndex = 12;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // AgendarTurnoForm
            // 
            this.AcceptButton = this._btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(480, 340);
            this.Controls.Add(this._lblPaciente);
            this.Controls.Add(this._lblMedico);
            this.Controls.Add(this._lblFecha);
            this.Controls.Add(this._lblHora);
            this.Controls.Add(this._lblObservaciones);
            this.Controls.Add(this._cmbPaciente);
            this.Controls.Add(this._cmbMedico);
            this.Controls.Add(this._dtpFecha);
            this.Controls.Add(this._dtpHora);
            this.Controls.Add(this._txtObservaciones);
            this.Controls.Add(this._lblAviso);
            this.Controls.Add(this._btnGuardar);
            this.Controls.Add(this._btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgendarTurnoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OpenRIN — Agendar turno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblPaciente;
        private System.Windows.Forms.ComboBox _cmbPaciente;
        private System.Windows.Forms.Label _lblMedico;
        private System.Windows.Forms.ComboBox _cmbMedico;
        private System.Windows.Forms.Label _lblFecha;
        private System.Windows.Forms.DateTimePicker _dtpFecha;
        private System.Windows.Forms.Label _lblHora;
        private System.Windows.Forms.DateTimePicker _dtpHora;
        private System.Windows.Forms.Label _lblObservaciones;
        private System.Windows.Forms.TextBox _txtObservaciones;
        private System.Windows.Forms.Label _lblAviso;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}
