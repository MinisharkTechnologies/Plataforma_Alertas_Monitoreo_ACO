// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class IdiomaNuevoForm
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
            this._lblCodigo = new System.Windows.Forms.Label();
            this._txtCodigo = new System.Windows.Forms.TextBox();
            this._lblNombre = new System.Windows.Forms.Label();
            this._txtNombre = new System.Windows.Forms.TextBox();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblCodigo
            // 
            this._lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblCodigo.Location = new System.Drawing.Point(24, 30);
            this._lblCodigo.Name = "_lblCodigo";
            this._lblCodigo.Size = new System.Drawing.Size(90, 20);
            this._lblCodigo.TabIndex = 0;
            this._lblCodigo.Text = "Código:";
            // 
            // _txtCodigo
            // 
            this._txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtCodigo.Location = new System.Drawing.Point(120, 26);
            this._txtCodigo.Name = "_txtCodigo";
            this._txtCodigo.Size = new System.Drawing.Size(150, 28);
            this._txtCodigo.TabIndex = 1;
            // 
            // _lblNombre
            // 
            this._lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblNombre.Location = new System.Drawing.Point(24, 78);
            this._lblNombre.Name = "_lblNombre";
            this._lblNombre.Size = new System.Drawing.Size(90, 20);
            this._lblNombre.TabIndex = 2;
            this._lblNombre.Text = "Nombre:";
            // 
            // _txtNombre
            // 
            this._txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtNombre.Location = new System.Drawing.Point(120, 74);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(280, 28);
            this._txtNombre.TabIndex = 3;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnGuardar.FlatAppearance.BorderSize = 0;
            this._btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnGuardar.ForeColor = System.Drawing.Color.White;
            this._btnGuardar.Location = new System.Drawing.Point(170, 132);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(120, 36);
            this._btnGuardar.TabIndex = 4;
            this._btnGuardar.Text = "Aceptar";
            this._btnGuardar.UseVisualStyleBackColor = false;
            this._btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.BackColor = System.Drawing.Color.White;
            this._btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this._btnCancelar.Location = new System.Drawing.Point(300, 132);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(100, 36);
            this._btnCancelar.TabIndex = 5;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = false;
            this._btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // IdiomaNuevoForm
            // 
            this.AcceptButton = this._btnGuardar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(430, 190);
            this.Controls.Add(this._lblCodigo);
            this.Controls.Add(this._txtCodigo);
            this.Controls.Add(this._lblNombre);
            this.Controls.Add(this._txtNombre);
            this.Controls.Add(this._btnGuardar);
            this.Controls.Add(this._btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdiomaNuevoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo idioma";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblCodigo;
        private System.Windows.Forms.TextBox _txtCodigo;
        private System.Windows.Forms.Label _lblNombre;
        private System.Windows.Forms.TextBox _txtNombre;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}
