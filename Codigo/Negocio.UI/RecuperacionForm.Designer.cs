// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class RecuperacionForm
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
            this._txtUsuario = new System.Windows.Forms.TextBox();
            this._btnVerPregunta = new System.Windows.Forms.Button();
            this._lblPregunta = new System.Windows.Forms.Label();
            this._lblRespuesta = new System.Windows.Forms.Label();
            this._txtRespuesta = new System.Windows.Forms.TextBox();
            this._lblNueva = new System.Windows.Forms.Label();
            this._txtNuevaContrasena = new System.Windows.Forms.TextBox();
            this._lblAviso = new System.Windows.Forms.Label();
            this._btnCambiar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblUsuario
            // 
            this._lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblUsuario.Location = new System.Drawing.Point(18, 14);
            this._lblUsuario.Name = "_lblUsuario";
            this._lblUsuario.Size = new System.Drawing.Size(240, 18);
            this._lblUsuario.TabIndex = 0;
            this._lblUsuario.Text = "Usuario";
            // 
            // _txtUsuario
            // 
            this._txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtUsuario.Location = new System.Drawing.Point(18, 32);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.Size = new System.Drawing.Size(240, 28);
            this._txtUsuario.TabIndex = 1;
            this._txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUsuario_KeyDown);
            // 
            // _btnVerPregunta
            // 
            this._btnVerPregunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnVerPregunta.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnVerPregunta.FlatAppearance.BorderSize = 0;
            this._btnVerPregunta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnVerPregunta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnVerPregunta.ForeColor = System.Drawing.Color.White;
            this._btnVerPregunta.Location = new System.Drawing.Point(270, 31);
            this._btnVerPregunta.Name = "_btnVerPregunta";
            this._btnVerPregunta.Size = new System.Drawing.Size(172, 30);
            this._btnVerPregunta.TabIndex = 2;
            this._btnVerPregunta.Text = "Ver pregunta de seguridad";
            this._btnVerPregunta.UseVisualStyleBackColor = false;
            this._btnVerPregunta.Click += new System.EventHandler(this.BtnVerPregunta_Click);
            // 
            // _lblPregunta
            // 
            this._lblPregunta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblPregunta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(120)))));
            this._lblPregunta.Location = new System.Drawing.Point(18, 74);
            this._lblPregunta.Name = "_lblPregunta";
            this._lblPregunta.Size = new System.Drawing.Size(424, 40);
            this._lblPregunta.TabIndex = 3;
            // 
            // _lblRespuesta
            // 
            this._lblRespuesta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblRespuesta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblRespuesta.Location = new System.Drawing.Point(18, 118);
            this._lblRespuesta.Name = "_lblRespuesta";
            this._lblRespuesta.Size = new System.Drawing.Size(240, 18);
            this._lblRespuesta.TabIndex = 4;
            this._lblRespuesta.Text = "Respuesta";
            // 
            // _txtRespuesta
            // 
            this._txtRespuesta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtRespuesta.Location = new System.Drawing.Point(18, 136);
            this._txtRespuesta.Name = "_txtRespuesta";
            this._txtRespuesta.Size = new System.Drawing.Size(280, 28);
            this._txtRespuesta.TabIndex = 5;
            // 
            // _lblNueva
            // 
            this._lblNueva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblNueva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblNueva.Location = new System.Drawing.Point(18, 174);
            this._lblNueva.Name = "_lblNueva";
            this._lblNueva.Size = new System.Drawing.Size(240, 18);
            this._lblNueva.TabIndex = 6;
            this._lblNueva.Text = "Nueva contraseña";
            // 
            // _txtNuevaContrasena
            // 
            this._txtNuevaContrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtNuevaContrasena.Location = new System.Drawing.Point(18, 192);
            this._txtNuevaContrasena.Name = "_txtNuevaContrasena";
            this._txtNuevaContrasena.Size = new System.Drawing.Size(280, 28);
            this._txtNuevaContrasena.TabIndex = 7;
            this._txtNuevaContrasena.UseSystemPasswordChar = true;
            // 
            // _lblAviso
            // 
            this._lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._lblAviso.Location = new System.Drawing.Point(18, 226);
            this._lblAviso.Name = "_lblAviso";
            this._lblAviso.Size = new System.Drawing.Size(424, 40);
            this._lblAviso.TabIndex = 8;
            // 
            // _btnCambiar
            // 
            this._btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnCambiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCambiar.FlatAppearance.BorderSize = 0;
            this._btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCambiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnCambiar.ForeColor = System.Drawing.Color.White;
            this._btnCambiar.Location = new System.Drawing.Point(248, 292);
            this._btnCambiar.Name = "_btnCambiar";
            this._btnCambiar.Size = new System.Drawing.Size(194, 36);
            this._btnCambiar.TabIndex = 9;
            this._btnCambiar.Text = "Cambiar contraseña";
            this._btnCambiar.UseVisualStyleBackColor = false;
            this._btnCambiar.Click += new System.EventHandler(this.BtnCambiar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.Location = new System.Drawing.Point(18, 292);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(90, 36);
            this._btnCancelar.TabIndex = 10;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // RecuperacionForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(460, 344);
            this.Controls.Add(this._lblUsuario);
            this.Controls.Add(this._txtUsuario);
            this.Controls.Add(this._btnVerPregunta);
            this.Controls.Add(this._lblPregunta);
            this.Controls.Add(this._lblRespuesta);
            this.Controls.Add(this._txtRespuesta);
            this.Controls.Add(this._lblNueva);
            this.Controls.Add(this._txtNuevaContrasena);
            this.Controls.Add(this._lblAviso);
            this.Controls.Add(this._btnCambiar);
            this.Controls.Add(this._btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecuperacionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Text = "OpenRIN — Recuperación de contraseña";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblUsuario;
        private System.Windows.Forms.TextBox _txtUsuario;
        private System.Windows.Forms.Button _btnVerPregunta;
        private System.Windows.Forms.Label _lblPregunta;
        private System.Windows.Forms.Label _lblRespuesta;
        private System.Windows.Forms.TextBox _txtRespuesta;
        private System.Windows.Forms.Label _lblNueva;
        private System.Windows.Forms.TextBox _txtNuevaContrasena;
        private System.Windows.Forms.Label _lblAviso;
        private System.Windows.Forms.Button _btnCambiar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}
