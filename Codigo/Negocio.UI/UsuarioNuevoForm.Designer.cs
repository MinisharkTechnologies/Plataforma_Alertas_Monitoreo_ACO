// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class UsuarioNuevoForm
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
            this._lblUsuario = new System.Windows.Forms.Label();
            this._lblPerfil = new System.Windows.Forms.Label();
            this._lblNombre = new System.Windows.Forms.Label();
            this._lblEmail = new System.Windows.Forms.Label();
            this._lblContrasena = new System.Windows.Forms.Label();
            this._lblPregunta = new System.Windows.Forms.Label();
            this._lblRespuesta = new System.Windows.Forms.Label();
            this._txtUsuario = new System.Windows.Forms.TextBox();
            this._cmbPerfil = new System.Windows.Forms.ComboBox();
            this._txtNombre = new System.Windows.Forms.TextBox();
            this._txtEmail = new System.Windows.Forms.TextBox();
            this._txtContrasena = new System.Windows.Forms.TextBox();
            this._cmbPregunta = new System.Windows.Forms.ComboBox();
            this._txtRespuesta = new System.Windows.Forms.TextBox();
            this._lblAviso = new System.Windows.Forms.Label();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblUsuario
            // 
            this._lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblUsuario.Location = new System.Drawing.Point(18, 12);
            this._lblUsuario.Name = "_lblUsuario";
            this._lblUsuario.Size = new System.Drawing.Size(220, 18);
            this._lblUsuario.TabIndex = 0;
            this._lblUsuario.Text = "Usuario";
            // 
            // _lblPerfil
            // 
            this._lblPerfil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblPerfil.Location = new System.Drawing.Point(250, 12);
            this._lblPerfil.Name = "_lblPerfil";
            this._lblPerfil.Size = new System.Drawing.Size(230, 18);
            this._lblPerfil.TabIndex = 1;
            this._lblPerfil.Text = "Perfil";
            // 
            // _lblNombre
            // 
            this._lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblNombre.Location = new System.Drawing.Point(18, 68);
            this._lblNombre.Name = "_lblNombre";
            this._lblNombre.Size = new System.Drawing.Size(462, 18);
            this._lblNombre.TabIndex = 2;
            this._lblNombre.Text = "Nombre completo";
            // 
            // _lblEmail
            // 
            this._lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblEmail.Location = new System.Drawing.Point(18, 124);
            this._lblEmail.Name = "_lblEmail";
            this._lblEmail.Size = new System.Drawing.Size(462, 18);
            this._lblEmail.TabIndex = 3;
            this._lblEmail.Text = "Correo electrónico";
            // 
            // _lblContrasena
            // 
            this._lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblContrasena.Location = new System.Drawing.Point(18, 180);
            this._lblContrasena.Name = "_lblContrasena";
            this._lblContrasena.Size = new System.Drawing.Size(220, 18);
            this._lblContrasena.TabIndex = 4;
            this._lblContrasena.Text = "Contraseña";
            // 
            // _lblPregunta
            // 
            this._lblPregunta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblPregunta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblPregunta.Location = new System.Drawing.Point(260, 180);
            this._lblPregunta.Name = "_lblPregunta";
            this._lblPregunta.Size = new System.Drawing.Size(220, 18);
            this._lblPregunta.TabIndex = 5;
            this._lblPregunta.Text = "Pregunta de seguridad:";
            // 
            // _lblRespuesta
            // 
            this._lblRespuesta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblRespuesta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblRespuesta.Location = new System.Drawing.Point(18, 238);
            this._lblRespuesta.Name = "_lblRespuesta";
            this._lblRespuesta.Size = new System.Drawing.Size(220, 18);
            this._lblRespuesta.TabIndex = 6;
            this._lblRespuesta.Text = "Respuesta";
            // 
            // _txtUsuario
            // 
            this._txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtUsuario.Location = new System.Drawing.Point(18, 30);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.Size = new System.Drawing.Size(220, 28);
            this._txtUsuario.TabIndex = 7;
            // 
            // _cmbPerfil
            // 
            this._cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbPerfil.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbPerfil.Items.AddRange(new object[] {
            "administrativo",
            "medico",
            "paciente",
            "familiar_autorizado",
            "sysadmin"});
            this._cmbPerfil.Location = new System.Drawing.Point(250, 30);
            this._cmbPerfil.Name = "_cmbPerfil";
            this._cmbPerfil.SelectedIndex = 0;
            this._cmbPerfil.Size = new System.Drawing.Size(230, 28);
            this._cmbPerfil.TabIndex = 8;
            // 
            // _txtNombre
            // 
            this._txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtNombre.Location = new System.Drawing.Point(18, 86);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(462, 28);
            this._txtNombre.TabIndex = 9;
            // 
            // _txtEmail
            // 
            this._txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtEmail.Location = new System.Drawing.Point(18, 142);
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.Size = new System.Drawing.Size(462, 28);
            this._txtEmail.TabIndex = 10;
            // 
            // _txtContrasena
            // 
            this._txtContrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtContrasena.Location = new System.Drawing.Point(18, 198);
            this._txtContrasena.Name = "_txtContrasena";
            this._txtContrasena.Size = new System.Drawing.Size(220, 28);
            this._txtContrasena.TabIndex = 11;
            this._txtContrasena.UseSystemPasswordChar = true;
            // 
            // _cmbPregunta
            // 
            this._cmbPregunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbPregunta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cmbPregunta.Items.AddRange(new object[] {
            "¿Ciudad donde creció?",
            "¿Nombre de su primera mascota?",
            "¿Nombre de su escuela primaria?"});
            this._cmbPregunta.Location = new System.Drawing.Point(260, 198);
            this._cmbPregunta.Name = "_cmbPregunta";
            this._cmbPregunta.Size = new System.Drawing.Size(220, 28);
            this._cmbPregunta.TabIndex = 12;
            // 
            // _txtRespuesta
            // 
            this._txtRespuesta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtRespuesta.Location = new System.Drawing.Point(18, 256);
            this._txtRespuesta.Name = "_txtRespuesta";
            this._txtRespuesta.Size = new System.Drawing.Size(220, 28);
            this._txtRespuesta.TabIndex = 13;
            // 
            // _lblAviso
            // 
            this._lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._lblAviso.Location = new System.Drawing.Point(18, 292);
            this._lblAviso.Name = "_lblAviso";
            this._lblAviso.Size = new System.Drawing.Size(462, 40);
            this._lblAviso.TabIndex = 14;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnGuardar.FlatAppearance.BorderSize = 0;
            this._btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGuardar.ForeColor = System.Drawing.Color.White;
            this._btnGuardar.Location = new System.Drawing.Point(296, 352);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(90, 36);
            this._btnGuardar.TabIndex = 15;
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.UseVisualStyleBackColor = false;
            this._btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.Location = new System.Drawing.Point(392, 352);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(88, 36);
            this._btnCancelar.TabIndex = 16;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // UsuarioNuevoForm
            // 
            this.AcceptButton = this._btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(500, 414);
            this.Controls.Add(this._lblUsuario);
            this.Controls.Add(this._lblPerfil);
            this.Controls.Add(this._lblNombre);
            this.Controls.Add(this._lblEmail);
            this.Controls.Add(this._lblContrasena);
            this.Controls.Add(this._lblPregunta);
            this.Controls.Add(this._lblRespuesta);
            this.Controls.Add(this._txtUsuario);
            this.Controls.Add(this._cmbPerfil);
            this.Controls.Add(this._txtNombre);
            this.Controls.Add(this._txtEmail);
            this.Controls.Add(this._txtContrasena);
            this.Controls.Add(this._cmbPregunta);
            this.Controls.Add(this._txtRespuesta);
            this.Controls.Add(this._lblAviso);
            this.Controls.Add(this._btnGuardar);
            this.Controls.Add(this._btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsuarioNuevoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Text = "OpenRIN — Nuevo usuario";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblUsuario;
        private System.Windows.Forms.Label _lblPerfil;
        private System.Windows.Forms.Label _lblNombre;
        private System.Windows.Forms.Label _lblEmail;
        private System.Windows.Forms.Label _lblContrasena;
        private System.Windows.Forms.Label _lblPregunta;
        private System.Windows.Forms.Label _lblRespuesta;
        private System.Windows.Forms.TextBox _txtUsuario;
        private System.Windows.Forms.ComboBox _cmbPerfil;
        private System.Windows.Forms.TextBox _txtNombre;
        private System.Windows.Forms.TextBox _txtEmail;
        private System.Windows.Forms.TextBox _txtContrasena;
        private System.Windows.Forms.ComboBox _cmbPregunta;
        private System.Windows.Forms.TextBox _txtRespuesta;
        private System.Windows.Forms.Label _lblAviso;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}
