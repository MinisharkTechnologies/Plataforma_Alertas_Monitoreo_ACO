// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class LoginForm
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
            this._lblTitulo = new System.Windows.Forms.Label();
            this._lblSubtitulo = new System.Windows.Forms.Label();
            this._panelTarjeta = new System.Windows.Forms.Panel();
            this._lblUsuario = new System.Windows.Forms.Label();
            this._txtUsuario = new System.Windows.Forms.TextBox();
            this._lblContrasena = new System.Windows.Forms.Label();
            this._txtContrasena = new System.Windows.Forms.TextBox();
            this._btnIngresar = new System.Windows.Forms.Button();
            this._lnkRecuperar = new System.Windows.Forms.LinkLabel();
            this._lblIdioma = new System.Windows.Forms.Label();
            this._cmbIdioma = new System.Windows.Forms.ComboBox();
            this._lblVersion = new System.Windows.Forms.Label();
            this._panelTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblTitulo
            // 
            this._lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this._lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(138)))));
            this._lblTitulo.Location = new System.Drawing.Point(36, 26);
            this._lblTitulo.Name = "_lblTitulo";
            this._lblTitulo.Size = new System.Drawing.Size(268, 40);
            this._lblTitulo.TabIndex = 0;
            this._lblTitulo.Text = "OpenRIN";
            // 
            // _lblSubtitulo
            // 
            this._lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(107)))), ((int)(((byte)(138)))));
            this._lblSubtitulo.Location = new System.Drawing.Point(38, 68);
            this._lblSubtitulo.Name = "_lblSubtitulo";
            this._lblSubtitulo.Size = new System.Drawing.Size(388, 20);
            this._lblSubtitulo.TabIndex = 1;
            this._lblSubtitulo.Text = "Plataforma Integral de Alertas y Monitoreo";
            // 
            // _panelTarjeta
            // 
            this._panelTarjeta.BackColor = System.Drawing.Color.White;
            this._panelTarjeta.Controls.Add(this._lblUsuario);
            this._panelTarjeta.Controls.Add(this._txtUsuario);
            this._panelTarjeta.Controls.Add(this._lblContrasena);
            this._panelTarjeta.Controls.Add(this._txtContrasena);
            this._panelTarjeta.Controls.Add(this._btnIngresar);
            this._panelTarjeta.Controls.Add(this._lnkRecuperar);
            this._panelTarjeta.Controls.Add(this._lblIdioma);
            this._panelTarjeta.Controls.Add(this._cmbIdioma);
            this._panelTarjeta.Location = new System.Drawing.Point(36, 104);
            this._panelTarjeta.Name = "_panelTarjeta";
            this._panelTarjeta.Size = new System.Drawing.Size(388, 348);
            this._panelTarjeta.TabIndex = 2;
            // 
            // _lblUsuario
            // 
            this._lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblUsuario.Location = new System.Drawing.Point(24, 26);
            this._lblUsuario.Name = "_lblUsuario";
            this._lblUsuario.Size = new System.Drawing.Size(340, 18);
            this._lblUsuario.TabIndex = 0;
            this._lblUsuario.Text = "Usuario";
            // 
            // _txtUsuario
            // 
            this._txtUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._txtUsuario.Location = new System.Drawing.Point(24, 48);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.Size = new System.Drawing.Size(340, 28);
            this._txtUsuario.TabIndex = 1;
            // 
            // _lblContrasena
            // 
            this._lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblContrasena.Location = new System.Drawing.Point(24, 92);
            this._lblContrasena.Name = "_lblContrasena";
            this._lblContrasena.Size = new System.Drawing.Size(340, 18);
            this._lblContrasena.TabIndex = 2;
            this._lblContrasena.Text = "Contraseña";
            // 
            // _txtContrasena
            // 
            this._txtContrasena.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._txtContrasena.Location = new System.Drawing.Point(24, 114);
            this._txtContrasena.Name = "_txtContrasena";
            this._txtContrasena.Size = new System.Drawing.Size(340, 28);
            this._txtContrasena.TabIndex = 3;
            this._txtContrasena.UseSystemPasswordChar = true;
            // 
            // _btnIngresar
            // 
            this._btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnIngresar.FlatAppearance.BorderSize = 0;
            this._btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnIngresar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._btnIngresar.ForeColor = System.Drawing.Color.White;
            this._btnIngresar.Location = new System.Drawing.Point(24, 168);
            this._btnIngresar.Name = "_btnIngresar";
            this._btnIngresar.Size = new System.Drawing.Size(340, 42);
            this._btnIngresar.TabIndex = 4;
            this._btnIngresar.Text = "Ingresar";
            this._btnIngresar.UseVisualStyleBackColor = false;
            this._btnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // _lnkRecuperar
            // 
            this._lnkRecuperar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lnkRecuperar.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._lnkRecuperar.Location = new System.Drawing.Point(24, 224);
            this._lnkRecuperar.Name = "_lnkRecuperar";
            this._lnkRecuperar.Size = new System.Drawing.Size(340, 20);
            this._lnkRecuperar.TabIndex = 5;
            this._lnkRecuperar.TabStop = true;
            this._lnkRecuperar.Text = "¿Olvidó su contraseña?";
            this._lnkRecuperar.Click += new System.EventHandler(this.LnkRecuperar_Click);
            // 
            // _lblIdioma
            // 
            this._lblIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblIdioma.Location = new System.Drawing.Point(24, 264);
            this._lblIdioma.Name = "_lblIdioma";
            this._lblIdioma.Size = new System.Drawing.Size(340, 18);
            this._lblIdioma.TabIndex = 6;
            this._lblIdioma.Text = "Idioma";
            // 
            // _cmbIdioma
            // 
            this._cmbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbIdioma.Location = new System.Drawing.Point(24, 286);
            this._cmbIdioma.Name = "_cmbIdioma";
            this._cmbIdioma.Size = new System.Drawing.Size(220, 26);
            this._cmbIdioma.TabIndex = 7;
            this._cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.CmbIdioma_SelectedIndexChanged);
            // 
            // _lblVersion
            // 
            this._lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this._lblVersion.Location = new System.Drawing.Point(38, 468);
            this._lblVersion.Name = "_lblVersion";
            this._lblVersion.Size = new System.Drawing.Size(388, 18);
            this._lblVersion.TabIndex = 3;
            this._lblVersion.Text = "OpenRIN · .NET 8 · v1.0";
            // 
            // LoginForm
            // 
            this.AcceptButton = this._btnIngresar;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 520);
            this.Controls.Add(this._panelTarjeta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenRIN — Iniciar Sesión";
            this._panelTarjeta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblTitulo;
        private System.Windows.Forms.Label _lblSubtitulo;
        private System.Windows.Forms.Panel _panelTarjeta;
        private System.Windows.Forms.Label _lblUsuario;
        private System.Windows.Forms.TextBox _txtUsuario;
        private System.Windows.Forms.Label _lblContrasena;
        private System.Windows.Forms.TextBox _txtContrasena;
        private System.Windows.Forms.Button _btnIngresar;
        private System.Windows.Forms.LinkLabel _lnkRecuperar;
        private System.Windows.Forms.Label _lblIdioma;
        private System.Windows.Forms.ComboBox _cmbIdioma;
        private System.Windows.Forms.Label _lblVersion;
    }
}
