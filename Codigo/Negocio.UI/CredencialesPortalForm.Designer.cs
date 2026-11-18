// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class CredencialesPortalForm
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
            this._lblAviso = new System.Windows.Forms.Label();
            this._lblUsuario = new System.Windows.Forms.Label();
            this._txtUsuario = new System.Windows.Forms.TextBox();
            this._lblClave = new System.Windows.Forms.Label();
            this._txtClave = new System.Windows.Forms.TextBox();
            this._btnCopiar = new System.Windows.Forms.Button();
            this._btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblTitulo
            // 
            this._lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(120)))));
            this._lblTitulo.Location = new System.Drawing.Point(18, 14);
            this._lblTitulo.Name = "_lblTitulo";
            this._lblTitulo.Size = new System.Drawing.Size(424, 26);
            this._lblTitulo.TabIndex = 0;
            this._lblTitulo.Text = "Credenciales del portal generadas";
            // 
            // _lblAviso
            // 
            this._lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))));
            this._lblAviso.Location = new System.Drawing.Point(18, 44);
            this._lblAviso.Name = "_lblAviso";
            this._lblAviso.Size = new System.Drawing.Size(424, 44);
            this._lblAviso.TabIndex = 1;
            this._lblAviso.Text = "Entregue estas credenciales al paciente. La contraseña temporal no volverá a mostrarse.";
            // 
            // _lblUsuario
            // 
            this._lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblUsuario.Location = new System.Drawing.Point(18, 96);
            this._lblUsuario.Name = "_lblUsuario";
            this._lblUsuario.Size = new System.Drawing.Size(200, 18);
            this._lblUsuario.TabIndex = 2;
            this._lblUsuario.Text = "Usuario";
            // 
            // _txtUsuario
            // 
            this._txtUsuario.Font = new System.Drawing.Font("Consolas", 11F);
            this._txtUsuario.Location = new System.Drawing.Point(18, 116);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.ReadOnly = true;
            this._txtUsuario.Size = new System.Drawing.Size(424, 28);
            this._txtUsuario.TabIndex = 3;
            // 
            // _lblClave
            // 
            this._lblClave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblClave.Location = new System.Drawing.Point(18, 152);
            this._lblClave.Name = "_lblClave";
            this._lblClave.Size = new System.Drawing.Size(200, 18);
            this._lblClave.TabIndex = 4;
            this._lblClave.Text = "Contraseña";
            // 
            // _txtClave
            // 
            this._txtClave.Font = new System.Drawing.Font("Consolas", 11F);
            this._txtClave.Location = new System.Drawing.Point(18, 172);
            this._txtClave.Name = "_txtClave";
            this._txtClave.ReadOnly = true;
            this._txtClave.Size = new System.Drawing.Size(424, 28);
            this._txtClave.TabIndex = 5;
            // 
            // _btnCopiar
            // 
            this._btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCopiar.Location = new System.Drawing.Point(18, 218);
            this._btnCopiar.Name = "_btnCopiar";
            this._btnCopiar.Size = new System.Drawing.Size(160, 34);
            this._btnCopiar.TabIndex = 6;
            this._btnCopiar.Text = "Copiar contraseña";
            this._btnCopiar.Click += new System.EventHandler(this.BtnCopiar_Click);
            // 
            // _btnCerrar
            // 
            this._btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnCerrar.FlatAppearance.BorderSize = 0;
            this._btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnCerrar.ForeColor = System.Drawing.Color.White;
            this._btnCerrar.Location = new System.Drawing.Point(348, 218);
            this._btnCerrar.Name = "_btnCerrar";
            this._btnCerrar.Size = new System.Drawing.Size(94, 34);
            this._btnCerrar.TabIndex = 7;
            this._btnCerrar.Text = "Cerrar";
            this._btnCerrar.UseVisualStyleBackColor = false;
            this._btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // CredencialesPortalForm
            // 
            this.AcceptButton = this._btnCerrar;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 300);
            this.Controls.Add(this._lblTitulo);
            this.Controls.Add(this._lblAviso);
            this.Controls.Add(this._lblUsuario);
            this.Controls.Add(this._txtUsuario);
            this.Controls.Add(this._lblClave);
            this.Controls.Add(this._txtClave);
            this.Controls.Add(this._btnCopiar);
            this.Controls.Add(this._btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CredencialesPortalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Text = "Credenciales del portal generadas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblTitulo;
        private System.Windows.Forms.Label _lblAviso;
        private System.Windows.Forms.Label _lblUsuario;
        private System.Windows.Forms.TextBox _txtUsuario;
        private System.Windows.Forms.Label _lblClave;
        private System.Windows.Forms.TextBox _txtClave;
        private System.Windows.Forms.Button _btnCopiar;
        private System.Windows.Forms.Button _btnCerrar;
    }
}
