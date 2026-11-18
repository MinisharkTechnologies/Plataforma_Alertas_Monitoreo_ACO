// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class PacienteEditorForm
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
            this._lblNombre = new System.Windows.Forms.Label();
            this._lblDocumento = new System.Windows.Forms.Label();
            this._lblTelefono = new System.Windows.Forms.Label();
            this._lblEmail = new System.Windows.Forms.Label();
            this._lblObraSocial = new System.Windows.Forms.Label();
            this._lblAfiliado = new System.Windows.Forms.Label();
            this._txtNombre = new System.Windows.Forms.TextBox();
            this._txtDni = new System.Windows.Forms.TextBox();
            this._txtTelefono = new System.Windows.Forms.TextBox();
            this._txtEmail = new System.Windows.Forms.TextBox();
            this._cmbObraSocial = new System.Windows.Forms.ComboBox();
            this._txtAfiliado = new System.Windows.Forms.TextBox();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblNombre
            // 
            this._lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblNombre.Location = new System.Drawing.Point(18, 14);
            this._lblNombre.Name = "_lblNombre";
            this._lblNombre.Size = new System.Drawing.Size(210, 18);
            this._lblNombre.TabIndex = 0;
            this._lblNombre.Text = "Nombre completo";
            // 
            // _lblDocumento
            // 
            this._lblDocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblDocumento.Location = new System.Drawing.Point(18, 70);
            this._lblDocumento.Name = "_lblDocumento";
            this._lblDocumento.Size = new System.Drawing.Size(210, 18);
            this._lblDocumento.TabIndex = 2;
            this._lblDocumento.Text = "Documento (DNI)";
            // 
            // _lblTelefono
            // 
            this._lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblTelefono.Location = new System.Drawing.Point(234, 70);
            this._lblTelefono.Name = "_lblTelefono";
            this._lblTelefono.Size = new System.Drawing.Size(210, 18);
            this._lblTelefono.TabIndex = 4;
            this._lblTelefono.Text = "Teléfono";
            // 
            // _lblEmail
            // 
            this._lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblEmail.Location = new System.Drawing.Point(18, 126);
            this._lblEmail.Name = "_lblEmail";
            this._lblEmail.Size = new System.Drawing.Size(210, 18);
            this._lblEmail.TabIndex = 6;
            this._lblEmail.Text = "Correo electrónico";
            // 
            // _lblObraSocial
            // 
            this._lblObraSocial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblObraSocial.Location = new System.Drawing.Point(18, 182);
            this._lblObraSocial.Name = "_lblObraSocial";
            this._lblObraSocial.Size = new System.Drawing.Size(210, 18);
            this._lblObraSocial.TabIndex = 8;
            this._lblObraSocial.Text = "Obra social";
            // 
            // _lblAfiliado
            // 
            this._lblAfiliado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblAfiliado.Location = new System.Drawing.Point(310, 182);
            this._lblAfiliado.Name = "_lblAfiliado";
            this._lblAfiliado.Size = new System.Drawing.Size(210, 18);
            this._lblAfiliado.TabIndex = 10;
            this._lblAfiliado.Text = "N° de afiliado";
            // 
            // _txtNombre
            // 
            this._txtNombre.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._txtNombre.Location = new System.Drawing.Point(18, 34);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(444, 28);
            this._txtNombre.TabIndex = 1;
            // 
            // _txtDni
            // 
            this._txtDni.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._txtDni.Location = new System.Drawing.Point(18, 90);
            this._txtDni.Name = "_txtDni";
            this._txtDni.Size = new System.Drawing.Size(200, 28);
            this._txtDni.TabIndex = 3;
            // 
            // _txtTelefono
            // 
            this._txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._txtTelefono.Location = new System.Drawing.Point(234, 90);
            this._txtTelefono.Name = "_txtTelefono";
            this._txtTelefono.Size = new System.Drawing.Size(228, 28);
            this._txtTelefono.TabIndex = 5;
            // 
            // _txtEmail
            // 
            this._txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._txtEmail.Location = new System.Drawing.Point(18, 146);
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.Size = new System.Drawing.Size(444, 28);
            this._txtEmail.TabIndex = 7;
            // 
            // _cmbObraSocial
            // 
            this._cmbObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbObraSocial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbObraSocial.Location = new System.Drawing.Point(18, 202);
            this._cmbObraSocial.Name = "_cmbObraSocial";
            this._cmbObraSocial.Size = new System.Drawing.Size(280, 28);
            this._cmbObraSocial.TabIndex = 9;
            // 
            // _txtAfiliado
            // 
            this._txtAfiliado.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._txtAfiliado.Location = new System.Drawing.Point(310, 202);
            this._txtAfiliado.Name = "_txtAfiliado";
            this._txtAfiliado.Size = new System.Drawing.Size(152, 28);
            this._txtAfiliado.TabIndex = 11;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnGuardar.FlatAppearance.BorderSize = 0;
            this._btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGuardar.ForeColor = System.Drawing.Color.White;
            this._btnGuardar.Location = new System.Drawing.Point(276, 266);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(90, 36);
            this._btnGuardar.TabIndex = 12;
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.Location = new System.Drawing.Point(374, 266);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(90, 36);
            this._btnCancelar.TabIndex = 13;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // PacienteEditorForm
            // 
            this.AcceptButton = this._btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(480, 380);
            this.Controls.Add(this._lblNombre);
            this.Controls.Add(this._lblDocumento);
            this.Controls.Add(this._lblTelefono);
            this.Controls.Add(this._lblEmail);
            this.Controls.Add(this._lblObraSocial);
            this.Controls.Add(this._lblAfiliado);
            this.Controls.Add(this._txtNombre);
            this.Controls.Add(this._txtDni);
            this.Controls.Add(this._txtTelefono);
            this.Controls.Add(this._txtEmail);
            this.Controls.Add(this._cmbObraSocial);
            this.Controls.Add(this._txtAfiliado);
            this.Controls.Add(this._btnGuardar);
            this.Controls.Add(this._btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PacienteEditorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OpenRIN — Alta de Paciente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblNombre;
        private System.Windows.Forms.Label _lblDocumento;
        private System.Windows.Forms.Label _lblTelefono;
        private System.Windows.Forms.Label _lblEmail;
        private System.Windows.Forms.Label _lblObraSocial;
        private System.Windows.Forms.Label _lblAfiliado;
        private System.Windows.Forms.TextBox _txtNombre;
        private System.Windows.Forms.TextBox _txtDni;
        private System.Windows.Forms.TextBox _txtTelefono;
        private System.Windows.Forms.TextBox _txtEmail;
        private System.Windows.Forms.ComboBox _cmbObraSocial;
        private System.Windows.Forms.TextBox _txtAfiliado;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}
