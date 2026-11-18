// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class SeguimientoControl
    {
        /// <summary>Contenedor de componentes del diseñador.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Libera los recursos usados por el control.</summary>
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
        /// controles y sus propiedades para que Visual Studio pueda dibujar el control
        /// en tiempo de diseño. No modificar a mano salvo que se sepa lo que se hace.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._panelBarra = new System.Windows.Forms.Panel();
            this._btnDetectar = new System.Windows.Forms.Button();
            this._grillaCasos = new System.Windows.Forms.DataGridView();
            this._colCasoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colCasoUltimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colCasoDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colCasoIntentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colCasoProtocolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lblSinCasos = new System.Windows.Forms.Label();
            this._panelDetalle = new System.Windows.Forms.Panel();
            this._lblPacienteDetalle = new System.Windows.Forms.Label();
            this._lblProtocolo = new System.Windows.Forms.Label();
            this._lblContactoSeccion = new System.Windows.Forms.Label();
            this._lblTipoContacto = new System.Windows.Forms.Label();
            this._cmbTipoContacto = new System.Windows.Forms.ComboBox();
            this._lblResultado = new System.Windows.Forms.Label();
            this._cmbResultado = new System.Windows.Forms.ComboBox();
            this._lblObservaciones = new System.Windows.Forms.Label();
            this._txtObservaciones = new System.Windows.Forms.TextBox();
            this._btnRegistrarIntento = new System.Windows.Forms.Button();
            this._lblAviso = new System.Windows.Forms.Label();
            this._lblDecisionSeccion = new System.Windows.Forms.Label();
            this._lblDecision = new System.Windows.Forms.Label();
            this._cmbDecision = new System.Windows.Forms.ComboBox();
            this._lblPeriodicidad = new System.Windows.Forms.Label();
            this._numPeriodicidad = new System.Windows.Forms.NumericUpDown();
            this._lblDetalleDecision = new System.Windows.Forms.Label();
            this._txtDetalleDecision = new System.Windows.Forms.TextBox();
            this._btnRegistrarDecision = new System.Windows.Forms.Button();
            this._lblHistorial = new System.Windows.Forms.Label();
            this._grillaHistorial = new System.Windows.Forms.DataGridView();
            this._colHistFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colHistTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colHistResultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colHistDecision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colHistObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezadoCasos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloEncabezadoCasos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezadoCasos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezadoCasos.ForeColor = System.Drawing.Color.White;
            estiloEncabezadoCasos.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            System.Windows.Forms.DataGridViewCellStyle estiloCeldasCasos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloCeldasCasos.Font = new System.Drawing.Font("Segoe UI", 10F);
            estiloCeldasCasos.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCeldasCasos.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCeldasCasos.SelectionForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle estiloFilasAltCasos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloFilasAltCasos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            System.Windows.Forms.DataGridViewCellStyle estiloDias = new System.Windows.Forms.DataGridViewCellStyle();
            estiloDias.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloIntentos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloIntentos.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloProtocolo = new System.Windows.Forms.DataGridViewCellStyle();
            estiloProtocolo.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezadoHistorial = new System.Windows.Forms.DataGridViewCellStyle();
            estiloEncabezadoHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezadoHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezadoHistorial.ForeColor = System.Drawing.Color.White;
            estiloEncabezadoHistorial.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            System.Windows.Forms.DataGridViewCellStyle estiloCeldasHistorial = new System.Windows.Forms.DataGridViewCellStyle();
            estiloCeldasHistorial.Font = new System.Drawing.Font("Segoe UI", 10F);
            estiloCeldasHistorial.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCeldasHistorial.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCeldasHistorial.SelectionForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle estiloFilasAltHistorial = new System.Windows.Forms.DataGridViewCellStyle();
            estiloFilasAltHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            estiloCeldasHistorial.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ((System.ComponentModel.ISupportInitialize)(this._grillaCasos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numPeriodicidad)).BeginInit();
            this._panelBarra.SuspendLayout();
            this._panelDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelBarra
            // 
            this._panelBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelBarra.Controls.Add(this._btnDetectar);
            this._panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBarra.Height = 58;
            this._panelBarra.Name = "_panelBarra";
            this._panelBarra.TabIndex = 3;
            // 
            // _btnDetectar
            // 
            this._btnDetectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnDetectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDetectar.FlatAppearance.BorderSize = 0;
            this._btnDetectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDetectar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnDetectar.ForeColor = System.Drawing.Color.White;
            this._btnDetectar.Location = new System.Drawing.Point(0, 15);
            this._btnDetectar.Name = "_btnDetectar";
            this._btnDetectar.Size = new System.Drawing.Size(230, 32);
            this._btnDetectar.TabIndex = 0;
            this._btnDetectar.Text = "Detectar plazos vencidos";
            this._btnDetectar.UseVisualStyleBackColor = false;
            this._btnDetectar.Click += new System.EventHandler(this.BtnDetectar_Click);
            // 
            // _grillaCasos
            // 
            this._grillaCasos.AllowUserToAddRows = false;
            this._grillaCasos.AllowUserToDeleteRows = false;
            this._grillaCasos.AllowUserToResizeRows = false;
            this._grillaCasos.AlternatingRowsDefaultCellStyle = estiloFilasAltCasos;
            this._grillaCasos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grillaCasos.BackgroundColor = System.Drawing.Color.White;
            this._grillaCasos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grillaCasos.ColumnHeadersDefaultCellStyle = estiloEncabezadoCasos;
            this._grillaCasos.ColumnHeadersHeight = 34;
            this._grillaCasos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colCasoPaciente,
            this._colCasoUltimo,
            this._colCasoDias,
            this._colCasoIntentos,
            this._colCasoProtocolo});
            this._grillaCasos.DefaultCellStyle = estiloCeldasCasos;
            this._grillaCasos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grillaCasos.EnableHeadersVisualStyles = false;
            this._grillaCasos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grillaCasos.MultiSelect = false;
            this._grillaCasos.Name = "_grillaCasos";
            this._grillaCasos.ReadOnly = true;
            this._grillaCasos.RowHeadersVisible = false;
            this._grillaCasos.RowTemplate.Height = 32;
            this._grillaCasos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grillaCasos.TabIndex = 0;
            this._grillaCasos.SelectionChanged += new System.EventHandler(this.GrillaCasos_SelectionChanged);
            // 
            // _colCasoPaciente
            // 
            this._colCasoPaciente.FillWeight = 30F;
            this._colCasoPaciente.HeaderText = "Paciente";
            this._colCasoPaciente.Name = "paciente";
            // 
            // _colCasoUltimo
            // 
            this._colCasoUltimo.FillWeight = 18F;
            this._colCasoUltimo.HeaderText = "Último reporte";
            this._colCasoUltimo.Name = "ultimo";
            // 
            // _colCasoDias
            // 
            this._colCasoDias.DefaultCellStyle = estiloDias;
            this._colCasoDias.FillWeight = 12F;
            this._colCasoDias.HeaderText = "Días vencidos";
            this._colCasoDias.Name = "dias";
            // 
            // _colCasoIntentos
            // 
            this._colCasoIntentos.DefaultCellStyle = estiloIntentos;
            this._colCasoIntentos.FillWeight = 12F;
            this._colCasoIntentos.HeaderText = "Intentos";
            this._colCasoIntentos.Name = "intentos";
            // 
            // _colCasoProtocolo
            // 
            this._colCasoProtocolo.DefaultCellStyle = estiloProtocolo;
            this._colCasoProtocolo.FillWeight = 28F;
            this._colCasoProtocolo.HeaderText = "Protocolo";
            this._colCasoProtocolo.Name = "protocolo";
            // 
            // _lblSinCasos
            // 
            this._lblSinCasos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lblSinCasos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblSinCasos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this._lblSinCasos.Height = 24;
            this._lblSinCasos.Name = "_lblSinCasos";
            this._lblSinCasos.TabIndex = 1;
            // 
            // _panelDetalle
            // 
            this._panelDetalle.BackColor = System.Drawing.Color.White;
            this._panelDetalle.Controls.Add(this._grillaHistorial);
            this._panelDetalle.Controls.Add(this._lblPacienteDetalle);
            this._panelDetalle.Controls.Add(this._lblProtocolo);
            this._panelDetalle.Controls.Add(this._lblContactoSeccion);
            this._panelDetalle.Controls.Add(this._lblTipoContacto);
            this._panelDetalle.Controls.Add(this._cmbTipoContacto);
            this._panelDetalle.Controls.Add(this._lblResultado);
            this._panelDetalle.Controls.Add(this._cmbResultado);
            this._panelDetalle.Controls.Add(this._lblObservaciones);
            this._panelDetalle.Controls.Add(this._txtObservaciones);
            this._panelDetalle.Controls.Add(this._btnRegistrarIntento);
            this._panelDetalle.Controls.Add(this._lblAviso);
            this._panelDetalle.Controls.Add(this._lblDecisionSeccion);
            this._panelDetalle.Controls.Add(this._lblDecision);
            this._panelDetalle.Controls.Add(this._cmbDecision);
            this._panelDetalle.Controls.Add(this._lblPeriodicidad);
            this._panelDetalle.Controls.Add(this._numPeriodicidad);
            this._panelDetalle.Controls.Add(this._lblDetalleDecision);
            this._panelDetalle.Controls.Add(this._txtDetalleDecision);
            this._panelDetalle.Controls.Add(this._btnRegistrarDecision);
            this._panelDetalle.Controls.Add(this._lblHistorial);
            this._panelDetalle.Dock = System.Windows.Forms.DockStyle.Right;
            this._panelDetalle.Name = "_panelDetalle";
            this._panelDetalle.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this._panelDetalle.TabIndex = 2;
            this._panelDetalle.Width = 520;
            // 
            // _lblPacienteDetalle
            // 
            this._lblPacienteDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblPacienteDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(120)))));
            this._lblPacienteDetalle.Location = new System.Drawing.Point(14, 10);
            this._lblPacienteDetalle.Size = new System.Drawing.Size(480, 24);
            this._lblPacienteDetalle.Name = "_lblPacienteDetalle";
            this._lblPacienteDetalle.TabIndex = 1;
            // 
            // _lblProtocolo
            // 
            this._lblProtocolo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblProtocolo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblProtocolo.Location = new System.Drawing.Point(14, 36);
            this._lblProtocolo.Size = new System.Drawing.Size(480, 20);
            this._lblProtocolo.Name = "_lblProtocolo";
            this._lblProtocolo.TabIndex = 2;
            // 
            // _lblContactoSeccion
            // 
            this._lblContactoSeccion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblContactoSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._lblContactoSeccion.Location = new System.Drawing.Point(14, 64);
            this._lblContactoSeccion.Size = new System.Drawing.Size(480, 20);
            this._lblContactoSeccion.Text = "Registrar intento de contacto";
            this._lblContactoSeccion.Name = "_lblContactoSeccion";
            this._lblContactoSeccion.TabIndex = 3;
            // 
            // _lblTipoContacto
            // 
            this._lblTipoContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblTipoContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblTipoContacto.Location = new System.Drawing.Point(14, 86);
            this._lblTipoContacto.Size = new System.Drawing.Size(220, 16);
            this._lblTipoContacto.Text = "Tipo de contacto";
            this._lblTipoContacto.Name = "_lblTipoContacto";
            this._lblTipoContacto.TabIndex = 4;
            // 
            // _cmbTipoContacto
            // 
            this._cmbTipoContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoContacto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbTipoContacto.Items.AddRange(new object[] {
            "Llamado telefónico",
            "Mensaje de texto",
            "Correo electrónico",
            "Otro"});
            this._cmbTipoContacto.Location = new System.Drawing.Point(14, 104);
            this._cmbTipoContacto.Name = "_cmbTipoContacto";
            this._cmbTipoContacto.Size = new System.Drawing.Size(220, 28);
            this._cmbTipoContacto.TabIndex = 5;
            // 
            // _lblResultado
            // 
            this._lblResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblResultado.Location = new System.Drawing.Point(250, 86);
            this._lblResultado.Size = new System.Drawing.Size(240, 16);
            this._lblResultado.Text = "Resultado";
            this._lblResultado.Name = "_lblResultado";
            this._lblResultado.TabIndex = 6;
            // 
            // _cmbResultado
            // 
            this._cmbResultado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbResultado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbResultado.Items.AddRange(new object[] {
            "Exitoso (cierra la alerta)",
            "Fallido (suma intento)"});
            this._cmbResultado.Location = new System.Drawing.Point(250, 104);
            this._cmbResultado.Name = "_cmbResultado";
            this._cmbResultado.Size = new System.Drawing.Size(240, 28);
            this._cmbResultado.TabIndex = 7;
            // 
            // _lblObservaciones
            // 
            this._lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblObservaciones.Location = new System.Drawing.Point(14, 136);
            this._lblObservaciones.Size = new System.Drawing.Size(476, 16);
            this._lblObservaciones.Text = "Observaciones";
            this._lblObservaciones.Name = "_lblObservaciones";
            this._lblObservaciones.TabIndex = 8;
            // 
            // _txtObservaciones
            // 
            this._txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtObservaciones.Location = new System.Drawing.Point(14, 154);
            this._txtObservaciones.Name = "txtObservaciones";
            this._txtObservaciones.Size = new System.Drawing.Size(476, 26);
            this._txtObservaciones.TabIndex = 9;
            // 
            // _btnRegistrarIntento
            // 
            this._btnRegistrarIntento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnRegistrarIntento.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRegistrarIntento.FlatAppearance.BorderSize = 0;
            this._btnRegistrarIntento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRegistrarIntento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnRegistrarIntento.ForeColor = System.Drawing.Color.White;
            this._btnRegistrarIntento.Location = new System.Drawing.Point(14, 188);
            this._btnRegistrarIntento.Name = "_btnRegistrarIntento";
            this._btnRegistrarIntento.Size = new System.Drawing.Size(200, 34);
            this._btnRegistrarIntento.TabIndex = 10;
            this._btnRegistrarIntento.Text = "Registrar intento";
            this._btnRegistrarIntento.UseVisualStyleBackColor = false;
            this._btnRegistrarIntento.Click += new System.EventHandler(this.BtnRegistrarIntento_Click);
            // 
            // _lblAviso
            // 
            this._lblAviso.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._lblAviso.Location = new System.Drawing.Point(224, 190);
            this._lblAviso.Size = new System.Drawing.Size(266, 44);
            this._lblAviso.Name = "_lblAviso";
            this._lblAviso.TabIndex = 11;
            // 
            // _lblDecisionSeccion
            // 
            this._lblDecisionSeccion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblDecisionSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._lblDecisionSeccion.Location = new System.Drawing.Point(14, 234);
            this._lblDecisionSeccion.Size = new System.Drawing.Size(480, 20);
            this._lblDecisionSeccion.Text = "Decisión clínica";
            this._lblDecisionSeccion.Name = "_lblDecisionSeccion";
            this._lblDecisionSeccion.TabIndex = 12;
            // 
            // _lblDecision
            // 
            this._lblDecision.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblDecision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblDecision.Location = new System.Drawing.Point(14, 256);
            this._lblDecision.Size = new System.Drawing.Size(240, 16);
            this._lblDecision.Text = "Decisión clínica";
            this._lblDecision.Name = "_lblDecision";
            this._lblDecision.TabIndex = 13;
            // 
            // _cmbDecision
            // 
            this._cmbDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbDecision.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbDecision.Items.AddRange(new object[] {
            "Contactar personalmente",
            "Programar visita domiciliaria",
            "Cambiar periodicidad",
            "Declarar no contactable"});
            this._cmbDecision.Location = new System.Drawing.Point(14, 274);
            this._cmbDecision.Name = "_cmbDecision";
            this._cmbDecision.Size = new System.Drawing.Size(240, 28);
            this._cmbDecision.TabIndex = 14;
            this._cmbDecision.SelectedIndexChanged += new System.EventHandler(this.CmbDecision_SelectedIndexChanged);
            // 
            // _lblPeriodicidad
            // 
            this._lblPeriodicidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblPeriodicidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblPeriodicidad.Location = new System.Drawing.Point(270, 256);
            this._lblPeriodicidad.Size = new System.Drawing.Size(220, 16);
            this._lblPeriodicidad.Text = "Nueva periodicidad (días)";
            this._lblPeriodicidad.Name = "_lblPeriodicidad";
            this._lblPeriodicidad.TabIndex = 15;
            // 
            // _numPeriodicidad
            // 
            this._numPeriodicidad.Enabled = false;
            this._numPeriodicidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._numPeriodicidad.Location = new System.Drawing.Point(270, 274);
            this._numPeriodicidad.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this._numPeriodicidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numPeriodicidad.Name = "_numPeriodicidad";
            this._numPeriodicidad.Size = new System.Drawing.Size(100, 28);
            this._numPeriodicidad.TabIndex = 16;
            this._numPeriodicidad.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // _lblDetalleDecision
            // 
            this._lblDetalleDecision.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblDetalleDecision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblDetalleDecision.Location = new System.Drawing.Point(14, 306);
            this._lblDetalleDecision.Size = new System.Drawing.Size(476, 16);
            this._lblDetalleDecision.Text = "Detalle de la decisión";
            this._lblDetalleDecision.Name = "_lblDetalleDecision";
            this._lblDetalleDecision.TabIndex = 17;
            // 
            // _txtDetalleDecision
            // 
            this._txtDetalleDecision.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtDetalleDecision.Location = new System.Drawing.Point(14, 324);
            this._txtDetalleDecision.Name = "txtDetalleDecision";
            this._txtDetalleDecision.Size = new System.Drawing.Size(476, 26);
            this._txtDetalleDecision.TabIndex = 18;
            // 
            // _btnRegistrarDecision
            // 
            this._btnRegistrarDecision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnRegistrarDecision.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRegistrarDecision.FlatAppearance.BorderSize = 0;
            this._btnRegistrarDecision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRegistrarDecision.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnRegistrarDecision.ForeColor = System.Drawing.Color.White;
            this._btnRegistrarDecision.Location = new System.Drawing.Point(14, 358);
            this._btnRegistrarDecision.Name = "_btnRegistrarDecision";
            this._btnRegistrarDecision.Size = new System.Drawing.Size(200, 34);
            this._btnRegistrarDecision.TabIndex = 19;
            this._btnRegistrarDecision.Text = "Registrar decisión";
            this._btnRegistrarDecision.UseVisualStyleBackColor = false;
            this._btnRegistrarDecision.Click += new System.EventHandler(this.BtnRegistrarDecision_Click);
            // 
            // _lblHistorial
            // 
            this._lblHistorial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this._lblHistorial.Location = new System.Drawing.Point(14, 398);
            this._lblHistorial.Size = new System.Drawing.Size(480, 20);
            this._lblHistorial.Text = "Historial del caso";
            this._lblHistorial.Name = "_lblHistorial";
            this._lblHistorial.TabIndex = 20;
            // 
            // _grillaHistorial
            // 
            this._grillaHistorial.AllowUserToAddRows = false;
            this._grillaHistorial.AllowUserToDeleteRows = false;
            this._grillaHistorial.AllowUserToResizeRows = false;
            this._grillaHistorial.AlternatingRowsDefaultCellStyle = estiloFilasAltHistorial;
            this._grillaHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grillaHistorial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._grillaHistorial.BackgroundColor = System.Drawing.Color.White;
            this._grillaHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grillaHistorial.ColumnHeadersDefaultCellStyle = estiloEncabezadoHistorial;
            this._grillaHistorial.ColumnHeadersHeight = 34;
            this._grillaHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colHistFecha,
            this._colHistTipo,
            this._colHistResultado,
            this._colHistDecision,
            this._colHistObservaciones});
            this._grillaHistorial.DefaultCellStyle = estiloCeldasHistorial;
            this._grillaHistorial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._grillaHistorial.Height = 196;
            this._grillaHistorial.EnableHeadersVisualStyles = false;
            this._grillaHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grillaHistorial.MultiSelect = false;
            this._grillaHistorial.Name = "_grillaHistorial";
            this._grillaHistorial.ReadOnly = true;
            this._grillaHistorial.RowHeadersVisible = false;
            this._grillaHistorial.RowTemplate.Height = 32;
            this._grillaHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grillaHistorial.TabIndex = 0;
            // 
            // _colHistFecha
            // 
            this._colHistFecha.FillWeight = 24F;
            this._colHistFecha.HeaderText = "Fecha";
            this._colHistFecha.Name = "fecha";
            // 
            // _colHistTipo
            // 
            this._colHistTipo.FillWeight = 16F;
            this._colHistTipo.HeaderText = "Tipo de contacto";
            this._colHistTipo.Name = "tipo";
            // 
            // _colHistResultado
            // 
            this._colHistResultado.FillWeight = 16F;
            this._colHistResultado.HeaderText = "Resultado";
            this._colHistResultado.Name = "resultado";
            // 
            // _colHistDecision
            // 
            this._colHistDecision.FillWeight = 20F;
            this._colHistDecision.HeaderText = "Decisión";
            this._colHistDecision.Name = "decision";
            // 
            // _colHistObservaciones
            // 
            this._colHistObservaciones.FillWeight = 24F;
            this._colHistObservaciones.HeaderText = "Observaciones";
            this._colHistObservaciones.Name = "observaciones";
            // 
            // SeguimientoControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.Controls.Add(this._grillaCasos);
            this.Controls.Add(this._lblSinCasos);
            this.Controls.Add(this._panelDetalle);
            this.Controls.Add(this._panelBarra);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "SeguimientoControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 6);
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this._grillaCasos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numPeriodicidad)).EndInit();
            this._panelDetalle.ResumeLayout(false);
            this._panelBarra.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelBarra;
        private System.Windows.Forms.Button _btnDetectar;
        private System.Windows.Forms.DataGridView _grillaCasos;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colCasoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colCasoUltimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colCasoDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colCasoIntentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colCasoProtocolo;
        private System.Windows.Forms.Label _lblSinCasos;
        private System.Windows.Forms.Panel _panelDetalle;
        private System.Windows.Forms.Label _lblPacienteDetalle;
        private System.Windows.Forms.Label _lblProtocolo;
        private System.Windows.Forms.Label _lblContactoSeccion;
        private System.Windows.Forms.Label _lblTipoContacto;
        private System.Windows.Forms.ComboBox _cmbTipoContacto;
        private System.Windows.Forms.Label _lblResultado;
        private System.Windows.Forms.ComboBox _cmbResultado;
        private System.Windows.Forms.Label _lblObservaciones;
        private System.Windows.Forms.TextBox _txtObservaciones;
        private System.Windows.Forms.Button _btnRegistrarIntento;
        private System.Windows.Forms.Label _lblAviso;
        private System.Windows.Forms.Label _lblDecisionSeccion;
        private System.Windows.Forms.Label _lblDecision;
        private System.Windows.Forms.ComboBox _cmbDecision;
        private System.Windows.Forms.Label _lblPeriodicidad;
        private System.Windows.Forms.NumericUpDown _numPeriodicidad;
        private System.Windows.Forms.Label _lblDetalleDecision;
        private System.Windows.Forms.TextBox _txtDetalleDecision;
        private System.Windows.Forms.Button _btnRegistrarDecision;
        private System.Windows.Forms.Label _lblHistorial;
        private System.Windows.Forms.DataGridView _grillaHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colHistFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colHistTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colHistResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colHistDecision;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colHistObservaciones;
    }
}
