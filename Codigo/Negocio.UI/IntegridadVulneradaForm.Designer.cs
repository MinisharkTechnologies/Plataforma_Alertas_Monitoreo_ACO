// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class IntegridadVulneradaForm
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
            this._lblIcono = new System.Windows.Forms.Label();
            this._lblTitulo = new System.Windows.Forms.Label();
            this._lblMensaje = new System.Windows.Forms.Label();
            this._lblRegistros = new System.Windows.Forms.Label();
            this._lstAlterados = new System.Windows.Forms.ListView();
            this._colTabla = new System.Windows.Forms.ColumnHeader();
            this._colId = new System.Windows.Forms.ColumnHeader();
            this._colMotivo = new System.Windows.Forms.ColumnHeader();
            this._lblRecTitulo = new System.Windows.Forms.Label();
            this._lblRecExplicacion = new System.Windows.Forms.Label();
            this._lblUsuarioCap = new System.Windows.Forms.Label();
            this._txtUsuario = new System.Windows.Forms.TextBox();
            this._lblClaveCap = new System.Windows.Forms.Label();
            this._txtClave = new System.Windows.Forms.TextBox();
            this._btnEntrar = new System.Windows.Forms.Button();
            this._lblEstadoSesion = new System.Windows.Forms.Label();
            this._panelRecuperacion = new System.Windows.Forms.Panel();
            this._lblListaRespaldos = new System.Windows.Forms.Label();
            this._lstRespaldos = new System.Windows.Forms.ListView();
            this._colFecha = new System.Windows.Forms.ColumnHeader();
            this._colOrigen = new System.Windows.Forms.ColumnHeader();
            this._colEstado = new System.Windows.Forms.ColumnHeader();
            this._colTamano = new System.Windows.Forms.ColumnHeader();
            this._colArchivo = new System.Windows.Forms.ColumnHeader();
            this._btnRestaurarSel = new System.Windows.Forms.Button();
            this._btnRestaurarArchivo = new System.Windows.Forms.Button();
            this._btnRecalcular = new System.Windows.Forms.Button();
            this._btnSalir = new System.Windows.Forms.Button();
            this._panelRecuperacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblIcono
            // 
            this._lblIcono.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this._lblIcono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._lblIcono.Location = new System.Drawing.Point(20, 10);
            this._lblIcono.Name = "_lblIcono";
            this._lblIcono.Size = new System.Drawing.Size(70, 64);
            this._lblIcono.TabIndex = 0;
            this._lblIcono.Text = "⚠";
            this._lblIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblTitulo
            // 
            this._lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this._lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this._lblTitulo.Location = new System.Drawing.Point(96, 14);
            this._lblTitulo.Name = "_lblTitulo";
            this._lblTitulo.Size = new System.Drawing.Size(640, 30);
            this._lblTitulo.TabIndex = 1;
            this._lblTitulo.Text = "Base de datos vulnerada";
            // 
            // _lblMensaje
            // 
            this._lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this._lblMensaje.Location = new System.Drawing.Point(98, 46);
            this._lblMensaje.Name = "_lblMensaje";
            this._lblMensaje.Size = new System.Drawing.Size(640, 48);
            this._lblMensaje.TabIndex = 2;
            this._lblMensaje.Text = "La verificación de integridad detectó alteraciones en la base de datos realizadas por fuera del sistema. Se bloqueó el acceso y se requiere la intervención del administrador con urgencia.";
            // 
            // _lblRegistros
            // 
            this._lblRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._lblRegistros.Location = new System.Drawing.Point(24, 100);
            this._lblRegistros.Name = "_lblRegistros";
            this._lblRegistros.Size = new System.Drawing.Size(700, 20);
            this._lblRegistros.TabIndex = 3;
            this._lblRegistros.Text = "Registros alterados:";
            // 
            // _lstAlterados
            // 
            this._lstAlterados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this._lstAlterados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colTabla,
            this._colId,
            this._colMotivo});
            this._lstAlterados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lstAlterados.FullRowSelect = true;
            this._lstAlterados.GridLines = true;
            this._lstAlterados.HideSelection = false;
            this._lstAlterados.Location = new System.Drawing.Point(24, 122);
            this._lstAlterados.MultiSelect = false;
            this._lstAlterados.Name = "_lstAlterados";
            this._lstAlterados.Size = new System.Drawing.Size(712, 150);
            this._lstAlterados.TabIndex = 4;
            this._lstAlterados.UseCompatibleStateImageBehavior = false;
            this._lstAlterados.View = System.Windows.Forms.View.Details;
            // 
            // _colTabla
            // 
            this._colTabla.Text = "Tabla";
            this._colTabla.Width = 150;
            // 
            // _colId
            // 
            this._colId.Text = "Id";
            this._colId.Width = 60;
            // 
            // _colMotivo
            // 
            this._colMotivo.Text = "Motivo";
            this._colMotivo.Width = 480;
            // 
            // _lblRecTitulo
            // 
            this._lblRecTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblRecTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(138)))));
            this._lblRecTitulo.Location = new System.Drawing.Point(24, 286);
            this._lblRecTitulo.Name = "_lblRecTitulo";
            this._lblRecTitulo.Size = new System.Drawing.Size(700, 26);
            this._lblRecTitulo.TabIndex = 5;
            this._lblRecTitulo.Text = "Recuperación de la base";
            // 
            // _lblRecExplicacion
            // 
            this._lblRecExplicacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblRecExplicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._lblRecExplicacion.Location = new System.Drawing.Point(24, 314);
            this._lblRecExplicacion.Name = "_lblRecExplicacion";
            this._lblRecExplicacion.Size = new System.Drawing.Size(712, 20);
            this._lblRecExplicacion.TabIndex = 6;
            this._lblRecExplicacion.Text = "Para recuperar la base, inicie sesión con un usuario que tenga permiso de respaldos.";
            // 
            // _lblUsuarioCap
            // 
            this._lblUsuarioCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblUsuarioCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._lblUsuarioCap.Location = new System.Drawing.Point(24, 342);
            this._lblUsuarioCap.Name = "_lblUsuarioCap";
            this._lblUsuarioCap.Size = new System.Drawing.Size(120, 20);
            this._lblUsuarioCap.TabIndex = 7;
            this._lblUsuarioCap.Text = "Usuario";
            // 
            // _txtUsuario
            // 
            this._txtUsuario.Location = new System.Drawing.Point(24, 362);
            this._txtUsuario.Name = "_txtUsuario";
            this._txtUsuario.Size = new System.Drawing.Size(190, 26);
            this._txtUsuario.TabIndex = 8;
            // 
            // _lblClaveCap
            // 
            this._lblClaveCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblClaveCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._lblClaveCap.Location = new System.Drawing.Point(230, 342);
            this._lblClaveCap.Name = "_lblClaveCap";
            this._lblClaveCap.Size = new System.Drawing.Size(120, 20);
            this._lblClaveCap.TabIndex = 9;
            this._lblClaveCap.Text = "Contraseña";
            // 
            // _txtClave
            // 
            this._txtClave.Location = new System.Drawing.Point(230, 362);
            this._txtClave.Name = "_txtClave";
            this._txtClave.Size = new System.Drawing.Size(190, 26);
            this._txtClave.TabIndex = 10;
            this._txtClave.UseSystemPasswordChar = true;
            // 
            // _btnEntrar
            // 
            this._btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnEntrar.FlatAppearance.BorderSize = 0;
            this._btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEntrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnEntrar.ForeColor = System.Drawing.Color.White;
            this._btnEntrar.Location = new System.Drawing.Point(436, 358);
            this._btnEntrar.Name = "_btnEntrar";
            this._btnEntrar.Size = new System.Drawing.Size(150, 34);
            this._btnEntrar.TabIndex = 11;
            this._btnEntrar.Text = "Iniciar sesión";
            this._btnEntrar.UseVisualStyleBackColor = false;
            this._btnEntrar.Click += new System.EventHandler(this.BtnEntrar_Click);
            // 
            // _lblEstadoSesion
            // 
            this._lblEstadoSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblEstadoSesion.Location = new System.Drawing.Point(24, 396);
            this._lblEstadoSesion.Name = "_lblEstadoSesion";
            this._lblEstadoSesion.Size = new System.Drawing.Size(712, 20);
            this._lblEstadoSesion.TabIndex = 12;
            // 
            // _panelRecuperacion
            // 
            this._panelRecuperacion.Controls.Add(this._lblListaRespaldos);
            this._panelRecuperacion.Controls.Add(this._lstRespaldos);
            this._panelRecuperacion.Controls.Add(this._btnRestaurarSel);
            this._panelRecuperacion.Controls.Add(this._btnRestaurarArchivo);
            this._panelRecuperacion.Controls.Add(this._btnRecalcular);
            this._panelRecuperacion.Enabled = false;
            this._panelRecuperacion.Location = new System.Drawing.Point(24, 420);
            this._panelRecuperacion.Name = "_panelRecuperacion";
            this._panelRecuperacion.Size = new System.Drawing.Size(712, 210);
            this._panelRecuperacion.TabIndex = 13;
            // 
            // _lblListaRespaldos
            // 
            this._lblListaRespaldos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblListaRespaldos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._lblListaRespaldos.Location = new System.Drawing.Point(0, 0);
            this._lblListaRespaldos.Name = "_lblListaRespaldos";
            this._lblListaRespaldos.Size = new System.Drawing.Size(700, 20);
            this._lblListaRespaldos.TabIndex = 0;
            this._lblListaRespaldos.Text = "Respaldos de la base de negocio:";
            // 
            // _lstRespaldos
            // 
            this._lstRespaldos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colFecha,
            this._colOrigen,
            this._colEstado,
            this._colTamano,
            this._colArchivo});
            this._lstRespaldos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lstRespaldos.FullRowSelect = true;
            this._lstRespaldos.GridLines = true;
            this._lstRespaldos.HideSelection = false;
            this._lstRespaldos.Location = new System.Drawing.Point(0, 22);
            this._lstRespaldos.MultiSelect = false;
            this._lstRespaldos.Name = "_lstRespaldos";
            this._lstRespaldos.Size = new System.Drawing.Size(712, 110);
            this._lstRespaldos.TabIndex = 1;
            this._lstRespaldos.UseCompatibleStateImageBehavior = false;
            this._lstRespaldos.View = System.Windows.Forms.View.Details;
            // 
            // _colFecha
            // 
            this._colFecha.Text = "Fecha";
            this._colFecha.Width = 130;
            // 
            // _colOrigen
            // 
            this._colOrigen.Text = "Origen";
            this._colOrigen.Width = 80;
            // 
            // _colEstado
            // 
            this._colEstado.Text = "Estado";
            this._colEstado.Width = 110;
            // 
            // _colTamano
            // 
            this._colTamano.Text = "Tamaño";
            this._colTamano.Width = 70;
            // 
            // _colArchivo
            // 
            this._colArchivo.Text = "Archivo";
            this._colArchivo.Width = 300;
            // 
            // _btnRestaurarSel
            // 
            this._btnRestaurarSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this._btnRestaurarSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRestaurarSel.FlatAppearance.BorderSize = 0;
            this._btnRestaurarSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRestaurarSel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnRestaurarSel.ForeColor = System.Drawing.Color.White;
            this._btnRestaurarSel.Location = new System.Drawing.Point(0, 144);
            this._btnRestaurarSel.Name = "_btnRestaurarSel";
            this._btnRestaurarSel.Size = new System.Drawing.Size(220, 36);
            this._btnRestaurarSel.TabIndex = 2;
            this._btnRestaurarSel.Text = "Restaurar el seleccionado";
            this._btnRestaurarSel.UseVisualStyleBackColor = false;
            this._btnRestaurarSel.Click += new System.EventHandler(this.BtnRestaurarSel_Click);
            // 
            // _btnRestaurarArchivo
            // 
            this._btnRestaurarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnRestaurarArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRestaurarArchivo.FlatAppearance.BorderSize = 0;
            this._btnRestaurarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRestaurarArchivo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnRestaurarArchivo.ForeColor = System.Drawing.Color.White;
            this._btnRestaurarArchivo.Location = new System.Drawing.Point(232, 144);
            this._btnRestaurarArchivo.Name = "_btnRestaurarArchivo";
            this._btnRestaurarArchivo.Size = new System.Drawing.Size(240, 36);
            this._btnRestaurarArchivo.TabIndex = 3;
            this._btnRestaurarArchivo.Text = "Restaurar desde otro .bak…";
            this._btnRestaurarArchivo.UseVisualStyleBackColor = false;
            this._btnRestaurarArchivo.Click += new System.EventHandler(this.BtnRestaurarArchivo_Click);
            // 
            // _btnRecalcular
            // 
            this._btnRecalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this._btnRecalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRecalcular.FlatAppearance.BorderSize = 0;
            this._btnRecalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRecalcular.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnRecalcular.ForeColor = System.Drawing.Color.White;
            this._btnRecalcular.Location = new System.Drawing.Point(484, 144);
            this._btnRecalcular.Name = "_btnRecalcular";
            this._btnRecalcular.Size = new System.Drawing.Size(228, 36);
            this._btnRecalcular.TabIndex = 4;
            this._btnRecalcular.Text = "Recalcular dígitos";
            this._btnRecalcular.UseVisualStyleBackColor = false;
            this._btnRecalcular.Click += new System.EventHandler(this.BtnRecalcular_Click);
            // 
            // _btnSalir
            // 
            this._btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSalir.FlatAppearance.BorderSize = 0;
            this._btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnSalir.ForeColor = System.Drawing.Color.White;
            this._btnSalir.Location = new System.Drawing.Point(606, 642);
            this._btnSalir.Name = "_btnSalir";
            this._btnSalir.Size = new System.Drawing.Size(130, 36);
            this._btnSalir.TabIndex = 14;
            this._btnSalir.Text = "Salir";
            this._btnSalir.UseVisualStyleBackColor = false;
            this._btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // IntegridadVulneradaForm
            // 
            this.AcceptButton = this._btnEntrar;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 690);
            this.ControlBox = false;
            this.Controls.Add(this._lblIcono);
            this.Controls.Add(this._lblTitulo);
            this.Controls.Add(this._lblMensaje);
            this.Controls.Add(this._lblRegistros);
            this.Controls.Add(this._lstAlterados);
            this.Controls.Add(this._lblRecTitulo);
            this.Controls.Add(this._lblRecExplicacion);
            this.Controls.Add(this._lblUsuarioCap);
            this.Controls.Add(this._txtUsuario);
            this.Controls.Add(this._lblClaveCap);
            this.Controls.Add(this._txtClave);
            this.Controls.Add(this._btnEntrar);
            this.Controls.Add(this._lblEstadoSesion);
            this.Controls.Add(this._panelRecuperacion);
            this.Controls.Add(this._btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IntegridadVulneradaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base de datos vulnerada";
            this._panelRecuperacion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblIcono;
        private System.Windows.Forms.Label _lblTitulo;
        private System.Windows.Forms.Label _lblMensaje;
        private System.Windows.Forms.Label _lblRegistros;
        private System.Windows.Forms.ListView _lstAlterados;
        private System.Windows.Forms.ColumnHeader _colTabla;
        private System.Windows.Forms.ColumnHeader _colId;
        private System.Windows.Forms.ColumnHeader _colMotivo;
        private System.Windows.Forms.Label _lblRecTitulo;
        private System.Windows.Forms.Label _lblRecExplicacion;
        private System.Windows.Forms.Label _lblUsuarioCap;
        private System.Windows.Forms.TextBox _txtUsuario;
        private System.Windows.Forms.Label _lblClaveCap;
        private System.Windows.Forms.TextBox _txtClave;
        private System.Windows.Forms.Button _btnEntrar;
        private System.Windows.Forms.Label _lblEstadoSesion;
        private System.Windows.Forms.Panel _panelRecuperacion;
        private System.Windows.Forms.Label _lblListaRespaldos;
        private System.Windows.Forms.ListView _lstRespaldos;
        private System.Windows.Forms.ColumnHeader _colFecha;
        private System.Windows.Forms.ColumnHeader _colOrigen;
        private System.Windows.Forms.ColumnHeader _colEstado;
        private System.Windows.Forms.ColumnHeader _colTamano;
        private System.Windows.Forms.ColumnHeader _colArchivo;
        private System.Windows.Forms.Button _btnRestaurarSel;
        private System.Windows.Forms.Button _btnRestaurarArchivo;
        private System.Windows.Forms.Button _btnRecalcular;
        private System.Windows.Forms.Button _btnSalir;
    }
}
