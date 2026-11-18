// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class TextoDialogoForm
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
            this._lblEtiqueta = new System.Windows.Forms.Label();
            this._txtValor = new System.Windows.Forms.TextBox();
            this._btnAceptar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblEtiqueta
            // 
            this._lblEtiqueta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblEtiqueta.Location = new System.Drawing.Point(18, 16);
            this._lblEtiqueta.Name = "_lblEtiqueta";
            this._lblEtiqueta.Size = new System.Drawing.Size(384, 20);
            this._lblEtiqueta.TabIndex = 0;
            this._lblEtiqueta.Text = "Texto:";
            // 
            // _txtValor
            // 
            this._txtValor.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._txtValor.Location = new System.Drawing.Point(18, 42);
            this._txtValor.Name = "_txtValor";
            this._txtValor.Size = new System.Drawing.Size(384, 28);
            this._txtValor.TabIndex = 1;
            // 
            // _btnAceptar
            // 
            this._btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnAceptar.FlatAppearance.BorderSize = 0;
            this._btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnAceptar.ForeColor = System.Drawing.Color.White;
            this._btnAceptar.Location = new System.Drawing.Point(222, 100);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(90, 32);
            this._btnAceptar.TabIndex = 2;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = false;
            this._btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.Location = new System.Drawing.Point(318, 100);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(84, 32);
            this._btnCancelar.TabIndex = 3;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TextoDialogoForm
            // 
            this.AcceptButton = this._btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCancelar;
            this.ClientSize = new System.Drawing.Size(420, 170);
            this.Controls.Add(this._lblEtiqueta);
            this.Controls.Add(this._txtValor);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this._btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextoDialogoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Text = "Texto";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblEtiqueta;
        private System.Windows.Forms.TextBox _txtValor;
        private System.Windows.Forms.Button _btnAceptar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}
