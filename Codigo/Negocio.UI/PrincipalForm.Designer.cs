// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class PrincipalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._panelCabecera = new System.Windows.Forms.Panel();
            this._picLogo = new System.Windows.Forms.PictureBox();
            this._lblApp = new System.Windows.Forms.Label();
            this._lblSesion = new System.Windows.Forms.Label();
            this._flowCabecera = new System.Windows.Forms.FlowLayoutPanel();
            this._btnCerrarSesion = new System.Windows.Forms.Button();
            this._btnAyuda = new System.Windows.Forms.Button();
            this._cmbIdioma = new System.Windows.Forms.ComboBox();
            this._lblIntegridad = new System.Windows.Forms.Label();
            this._panelMenu = new System.Windows.Forms.Panel();
            this._lblMenuTitulo = new System.Windows.Forms.Label();
            this._flowModulos = new System.Windows.Forms.FlowLayoutPanel();
            this._panelContenido = new System.Windows.Forms.Panel();
            this._panelVista = new System.Windows.Forms.Panel();
            this._panelTitulo = new System.Windows.Forms.Panel();
            this._lblModuloTitulo = new System.Windows.Forms.Label();
            this._lblModuloDetalle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._picLogo)).BeginInit();
            this._panelCabecera.SuspendLayout();
            this._flowCabecera.SuspendLayout();
            this._panelMenu.SuspendLayout();
            this._panelContenido.SuspendLayout();
            this._panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelCabecera
            // 
            this._panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._panelCabecera.Controls.Add(this._picLogo);
            this._panelCabecera.Controls.Add(this._lblApp);
            this._panelCabecera.Controls.Add(this._lblSesion);
            this._panelCabecera.Controls.Add(this._flowCabecera);
            this._panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelCabecera.Height = 74;
            this._panelCabecera.Name = "_panelCabecera";
            this._panelCabecera.TabIndex = 0;
            // 
            // _picLogo
            // 
            this._picLogo.BackColor = System.Drawing.Color.Transparent;
            this._picLogo.Image = Recursos.CargarIcono(64)?.ToBitmap();
            this._picLogo.Location = new System.Drawing.Point(22, 13);
            this._picLogo.Name = "_picLogo";
            this._picLogo.Size = new System.Drawing.Size(46, 46);
            this._picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picLogo.TabIndex = 0;
            this._picLogo.TabStop = false;
            // 
            // _lblApp
            // 
            this._lblApp.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this._lblApp.ForeColor = System.Drawing.Color.White;
            this._lblApp.Location = new System.Drawing.Point(80, 10);
            this._lblApp.Name = "_lblApp";
            this._lblApp.Size = new System.Drawing.Size(300, 34);
            this._lblApp.TabIndex = 1;
            this._lblApp.Text = "OpenRIN";
            // 
            // _lblSesion
            // 
            this._lblSesion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(250)))));
            this._lblSesion.Location = new System.Drawing.Point(82, 46);
            this._lblSesion.Name = "_lblSesion";
            this._lblSesion.Size = new System.Drawing.Size(640, 20);
            this._lblSesion.TabIndex = 2;
            this._lblSesion.Text = "Sesión:";
            // 
            // _flowCabecera
            // 
            this._flowCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._flowCabecera.Controls.Add(this._btnCerrarSesion);
            this._flowCabecera.Controls.Add(this._btnAyuda);
            this._flowCabecera.Controls.Add(this._cmbIdioma);
            this._flowCabecera.Controls.Add(this._lblIntegridad);
            this._flowCabecera.Dock = System.Windows.Forms.DockStyle.Right;
            this._flowCabecera.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._flowCabecera.Name = "_flowCabecera";
            this._flowCabecera.Padding = new System.Windows.Forms.Padding(0, 18, 16, 0);
            this._flowCabecera.TabIndex = 3;
            this._flowCabecera.Width = 670;
            this._flowCabecera.WrapContents = false;
            // 
            // _btnCerrarSesion
            // 
            this._btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(198)))));
            this._btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(195)))), ((int)(((byte)(232)))));
            this._btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this._btnCerrarSesion.Name = "_btnCerrarSesion";
            this._btnCerrarSesion.Size = new System.Drawing.Size(130, 36);
            this._btnCerrarSesion.TabIndex = 0;
            this._btnCerrarSesion.Text = "Cerrar sesión";
            this._btnCerrarSesion.UseVisualStyleBackColor = false;
            this._btnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // _btnAyuda
            // 
            this._btnAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(198)))));
            this._btnAyuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAyuda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(195)))), ((int)(((byte)(232)))));
            this._btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAyuda.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnAyuda.ForeColor = System.Drawing.Color.White;
            this._btnAyuda.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this._btnAyuda.Name = "_btnAyuda";
            this._btnAyuda.Size = new System.Drawing.Size(90, 36);
            this._btnAyuda.TabIndex = 1;
            this._btnAyuda.Text = "Ayuda";
            this._btnAyuda.UseVisualStyleBackColor = false;
            this._btnAyuda.Click += new System.EventHandler(this.BtnAyuda_Click);
            // 
            // _cmbIdioma
            // 
            this._cmbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbIdioma.Margin = new System.Windows.Forms.Padding(10, 4, 6, 0);
            this._cmbIdioma.Name = "_cmbIdioma";
            this._cmbIdioma.Size = new System.Drawing.Size(170, 28);
            this._cmbIdioma.TabIndex = 2;
            this._cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.CmbIdioma_SelectedIndexChanged);
            // 
            // _lblIntegridad
            // 
            this._lblIntegridad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblIntegridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(250)))));
            this._lblIntegridad.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this._lblIntegridad.Name = "_lblIntegridad";
            this._lblIntegridad.Size = new System.Drawing.Size(170, 36);
            this._lblIntegridad.TabIndex = 3;
            this._lblIntegridad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _panelMenu
            // 
            this._panelMenu.BackColor = System.Drawing.Color.White;
            this._panelMenu.Controls.Add(this._lblMenuTitulo);
            this._panelMenu.Controls.Add(this._flowModulos);
            this._panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this._panelMenu.Name = "_panelMenu";
            this._panelMenu.TabIndex = 1;
            this._panelMenu.Width = 248;
            // 
            // _lblMenuTitulo
            // 
            this._lblMenuTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblMenuTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._lblMenuTitulo.Location = new System.Drawing.Point(16, 16);
            this._lblMenuTitulo.Name = "_lblMenuTitulo";
            this._lblMenuTitulo.Size = new System.Drawing.Size(216, 24);
            this._lblMenuTitulo.TabIndex = 0;
            this._lblMenuTitulo.Text = "Módulos";
            // 
            // _flowModulos
            // 
            this._flowModulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this._flowModulos.AutoScroll = true;
            this._flowModulos.BackColor = System.Drawing.Color.White;
            this._flowModulos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowModulos.Location = new System.Drawing.Point(0, 52);
            this._flowModulos.Name = "_flowModulos";
            this._flowModulos.Size = new System.Drawing.Size(248, 700);
            this._flowModulos.TabIndex = 1;
            this._flowModulos.WrapContents = false;
            // 
            // _panelContenido
            // 
            this._panelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelContenido.Controls.Add(this._panelVista);
            this._panelContenido.Controls.Add(this._panelTitulo);
            this._panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelContenido.Name = "_panelContenido";
            this._panelContenido.TabIndex = 2;
            // 
            // _panelVista
            // 
            this._panelVista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelVista.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelVista.Name = "_panelVista";
            this._panelVista.TabIndex = 0;
            // 
            // _panelTitulo
            // 
            this._panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelTitulo.Controls.Add(this._lblModuloTitulo);
            this._panelTitulo.Controls.Add(this._lblModuloDetalle);
            this._panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelTitulo.Height = 104;
            this._panelTitulo.Name = "_panelTitulo";
            this._panelTitulo.TabIndex = 1;
            // 
            // _lblModuloTitulo
            // 
            this._lblModuloTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this._lblModuloTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(120)))));
            this._lblModuloTitulo.Location = new System.Drawing.Point(36, 22);
            this._lblModuloTitulo.Name = "_lblModuloTitulo";
            this._lblModuloTitulo.Size = new System.Drawing.Size(900, 40);
            this._lblModuloTitulo.TabIndex = 0;
            this._lblModuloTitulo.Text = "Panel Principal";
            // 
            // _lblModuloDetalle
            // 
            this._lblModuloDetalle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._lblModuloDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(110)))), ((int)(((byte)(135)))));
            this._lblModuloDetalle.Location = new System.Drawing.Point(38, 68);
            this._lblModuloDetalle.Name = "_lblModuloDetalle";
            this._lblModuloDetalle.Size = new System.Drawing.Size(900, 24);
            this._lblModuloDetalle.TabIndex = 1;
            this._lblModuloDetalle.Text = "Seleccione un módulo del menú lateral para comenzar.";
            // 
            // PrincipalForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this._panelContenido);
            this.Controls.Add(this._panelMenu);
            this.Controls.Add(this._panelCabecera);
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "PrincipalForm";
            this.Text = "OpenRIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._picLogo)).EndInit();
            this._panelCabecera.ResumeLayout(false);
            this._flowCabecera.ResumeLayout(false);
            this._panelMenu.ResumeLayout(false);
            this._panelContenido.ResumeLayout(false);
            this._panelTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panelCabecera;
        private System.Windows.Forms.PictureBox _picLogo;
        private System.Windows.Forms.Label _lblApp;
        private System.Windows.Forms.Label _lblSesion;
        private System.Windows.Forms.FlowLayoutPanel _flowCabecera;
        private System.Windows.Forms.Button _btnCerrarSesion;
        private System.Windows.Forms.Button _btnAyuda;
        private System.Windows.Forms.ComboBox _cmbIdioma;
        private System.Windows.Forms.Label _lblIntegridad;
        private System.Windows.Forms.Panel _panelMenu;
        private System.Windows.Forms.Label _lblMenuTitulo;
        private System.Windows.Forms.FlowLayoutPanel _flowModulos;
        private System.Windows.Forms.Panel _panelContenido;
        private System.Windows.Forms.Panel _panelVista;
        private System.Windows.Forms.Panel _panelTitulo;
        private System.Windows.Forms.Label _lblModuloTitulo;
        private System.Windows.Forms.Label _lblModuloDetalle;
    }
}
