// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class HistoriaClinicaForm
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
            this._lblDiagnostico = new System.Windows.Forms.Label();
            this._lblLimiteInferior = new System.Windows.Forms.Label();
            this._lblLimiteSuperior = new System.Windows.Forms.Label();
            this._lblMedicamento = new System.Windows.Forms.Label();
            this._lblDosis = new System.Windows.Forms.Label();
            this._lblPeriodicidad = new System.Windows.Forms.Label();
            this._lblAviso = new System.Windows.Forms.Label();
            this._cmbDiagnostico = new System.Windows.Forms.ComboBox();
            this._numInferior = new System.Windows.Forms.NumericUpDown();
            this._numSuperior = new System.Windows.Forms.NumericUpDown();
            this._txtMedicamento = new System.Windows.Forms.TextBox();
            this._txtDosis = new System.Windows.Forms.TextBox();
            this._numPeriodicidad = new System.Windows.Forms.NumericUpDown();
            this._chkProximoControl = new System.Windows.Forms.CheckBox();
            this._dtpProximoControl = new System.Windows.Forms.DateTimePicker();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblDiagnostico
            // 
            this._lblDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblDiagnostico.Location = new System.Drawing.Point(18, 52);
            this._lblDiagnostico.Name = "_lblDiagnostico";
            this._lblDiagnostico.Size = new System.Drawing.Size(210, 18);
            this._lblDiagnostico.TabIndex = 1;
            this._lblDiagnostico.Text = "Diagnóstico / indicación";
            // 
            // _lblLimiteInferior
            // 
            this._lblLimiteInferior.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblLimiteInferior.Location = new System.Drawing.Point(18, 112);
            this._lblLimiteInferior.Name = "_lblLimiteInferior";
            this._lblLimiteInferior.Size = new System.Drawing.Size(210, 18);
            this._lblLimiteInferior.TabIndex = 3;
            this._lblLimiteInferior.Text = "Límite inferior del RIN";
            // 
            // _lblLimiteSuperior
            // 
            this._lblLimiteSuperior.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblLimiteSuperior.Location = new System.Drawing.Point(264, 112);
            this._lblLimiteSuperior.Name = "_lblLimiteSuperior";
            this._lblLimiteSuperior.Size = new System.Drawing.Size(210, 18);
            this._lblLimiteSuperior.TabIndex = 5;
            this._lblLimiteSuperior.Text = "Límite superior del RIN";
            // 
            // _lblMedicamento
            // 
            this._lblMedicamento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblMedicamento.Location = new System.Drawing.Point(18, 172);
            this._lblMedicamento.Name = "_lblMedicamento";
            this._lblMedicamento.Size = new System.Drawing.Size(210, 18);
            this._lblMedicamento.TabIndex = 7;
            this._lblMedicamento.Text = "Medicamento";
            // 
            // _lblDosis
            // 
            this._lblDosis.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblDosis.Location = new System.Drawing.Point(264, 172);
            this._lblDosis.Name = "_lblDosis";
            this._lblDosis.Size = new System.Drawing.Size(210, 18);
            this._lblDosis.TabIndex = 9;
            this._lblDosis.Text = "Dosis";
            // 
            // _lblPeriodicidad
            // 
            this._lblPeriodicidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblPeriodicidad.Location = new System.Drawing.Point(18, 232);
            this._lblPeriodicidad.Name = "_lblPeriodicidad";
            this._lblPeriodicidad.Size = new System.Drawing.Size(210, 18);
            this._lblPeriodicidad.TabIndex = 11;
            this._lblPeriodicidad.Text = "Periodicidad de reporte (días)";
            // 
            // _lblAviso
            // 
            this._lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))));
            this._lblAviso.Location = new System.Drawing.Point(18, 12);
            this._lblAviso.Name = "_lblAviso";
            this._lblAviso.Size = new System.Drawing.Size(484, 36);
            this._lblAviso.TabIndex = 0;
            // 
            // _cmbDiagnostico
            // 
            this._cmbDiagnostico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbDiagnostico.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbDiagnostico.Location = new System.Drawing.Point(18, 72);
            this._cmbDiagnostico.Name = "_cmbDiagnostico";
            this._cmbDiagnostico.Size = new System.Drawing.Size(484, 28);
            this._cmbDiagnostico.TabIndex = 2;
            // 
            // _numInferior
            // 
            this._numInferior.DecimalPlaces = 2;
            this._numInferior.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._numInferior.Increment = 0.1M;
            this._numInferior.Location = new System.Drawing.Point(18, 132);
            this._numInferior.Maximum = 20.0M;
            this._numInferior.Minimum = 0.1M;
            this._numInferior.Name = "_numInferior";
            this._numInferior.Size = new System.Drawing.Size(200, 28);
            this._numInferior.TabIndex = 4;
            this._numInferior.Value = 2.0M;
            // 
            // _numSuperior
            // 
            this._numSuperior.DecimalPlaces = 2;
            this._numSuperior.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._numSuperior.Increment = 0.1M;
            this._numSuperior.Location = new System.Drawing.Point(264, 132);
            this._numSuperior.Maximum = 20.0M;
            this._numSuperior.Minimum = 0.1M;
            this._numSuperior.Name = "_numSuperior";
            this._numSuperior.Size = new System.Drawing.Size(238, 28);
            this._numSuperior.TabIndex = 6;
            this._numSuperior.Value = 3.0M;
            // 
            // _txtMedicamento
            // 
            this._txtMedicamento.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._txtMedicamento.Location = new System.Drawing.Point(18, 192);
            this._txtMedicamento.Name = "_txtMedicamento";
            this._txtMedicamento.Size = new System.Drawing.Size(238, 28);
            this._txtMedicamento.TabIndex = 8;
            // 
            // _txtDosis
            // 
            this._txtDosis.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._txtDosis.Location = new System.Drawing.Point(264, 192);
            this._txtDosis.Name = "_txtDosis";
            this._txtDosis.Size = new System.Drawing.Size(238, 28);
            this._txtDosis.TabIndex = 10;
            // 
            // _numPeriodicidad
            // 
            this._numPeriodicidad.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._numPeriodicidad.Location = new System.Drawing.Point(18, 252);
            this._numPeriodicidad.Maximum = 365M;
            this._numPeriodicidad.Minimum = 1M;
            this._numPeriodicidad.Name = "_numPeriodicidad";
            this._numPeriodicidad.Size = new System.Drawing.Size(160, 28);
            this._numPeriodicidad.TabIndex = 12;
            this._numPeriodicidad.Value = 30M;
            // 
            // _chkProximoControl
            // 
            this._chkProximoControl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._chkProximoControl.Location = new System.Drawing.Point(264, 234);
            this._chkProximoControl.Name = "_chkProximoControl";
            this._chkProximoControl.Size = new System.Drawing.Size(238, 22);
            this._chkProximoControl.TabIndex = 13;
            this._chkProximoControl.CheckedChanged += new System.EventHandler(this.ChkProximoControl_CheckedChanged);
            // 
            // _dtpProximoControl
            // 
            this._dtpProximoControl.Enabled = false;
            this._dtpProximoControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpProximoControl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpProximoControl.Location = new System.Drawing.Point(264, 256);
            this._dtpProximoControl.Name = "_dtpProximoControl";
            this._dtpProximoControl.Size = new System.Drawing.Size(160, 28);
            this._dtpProximoControl.TabIndex = 14;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnGuardar.FlatAppearance.BorderSize = 0;
            this._btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGuardar.ForeColor = System.Drawing.Color.White;
            this._btnGuardar.Location = new System.Drawing.Point(316, 320);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(90, 36);
            this._btnGuardar.TabIndex = 15;
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // _btnCerrar
            // 
            this._btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCerrar.Location = new System.Drawing.Point(414, 320);
            this._btnCerrar.Name = "_btnCerrar";
            this._btnCerrar.Size = new System.Drawing.Size(90, 36);
            this._btnCerrar.TabIndex = 16;
            this._btnCerrar.Text = "Cerrar";
            this._btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // HistoriaClinicaForm
            // 
            this.AcceptButton = this._btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCerrar;
            this.ClientSize = new System.Drawing.Size(520, 430);
            this.Controls.Add(this._lblDiagnostico);
            this.Controls.Add(this._lblLimiteInferior);
            this.Controls.Add(this._lblLimiteSuperior);
            this.Controls.Add(this._lblMedicamento);
            this.Controls.Add(this._lblDosis);
            this.Controls.Add(this._lblPeriodicidad);
            this.Controls.Add(this._lblAviso);
            this.Controls.Add(this._cmbDiagnostico);
            this.Controls.Add(this._numInferior);
            this.Controls.Add(this._numSuperior);
            this.Controls.Add(this._txtMedicamento);
            this.Controls.Add(this._txtDosis);
            this.Controls.Add(this._numPeriodicidad);
            this.Controls.Add(this._chkProximoControl);
            this.Controls.Add(this._dtpProximoControl);
            this.Controls.Add(this._btnGuardar);
            this.Controls.Add(this._btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoriaClinicaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OpenRIN — Historia Clínica Hematológica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblDiagnostico;
        private System.Windows.Forms.Label _lblLimiteInferior;
        private System.Windows.Forms.Label _lblLimiteSuperior;
        private System.Windows.Forms.Label _lblMedicamento;
        private System.Windows.Forms.Label _lblDosis;
        private System.Windows.Forms.Label _lblPeriodicidad;
        private System.Windows.Forms.Label _lblAviso;
        private System.Windows.Forms.ComboBox _cmbDiagnostico;
        private System.Windows.Forms.NumericUpDown _numInferior;
        private System.Windows.Forms.NumericUpDown _numSuperior;
        private System.Windows.Forms.TextBox _txtMedicamento;
        private System.Windows.Forms.TextBox _txtDosis;
        private System.Windows.Forms.NumericUpDown _numPeriodicidad;
        private System.Windows.Forms.CheckBox _chkProximoControl;
        private System.Windows.Forms.DateTimePicker _dtpProximoControl;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnCerrar;
    }
}
