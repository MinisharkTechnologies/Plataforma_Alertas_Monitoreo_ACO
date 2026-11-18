// Archivo generado con el patrón del diseñador de Windows Forms.
// El contexto de nullabilidad se desactiva porque los controles se asignan en
// InitializeComponent() y Visual Studio reescribe este archivo al guardar el diseño.
#nullable disable

namespace Negocio.UI
{
    partial class ReportesControl
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
            this._btnVistaMensual = new System.Windows.Forms.Button();
            this._btnVistaDiagnostico = new System.Windows.Forms.Button();
            this._btnVistaHistorial = new System.Windows.Forms.Button();
            this._lblPeriodo = new System.Windows.Forms.Label();
            this._dtpMes = new System.Windows.Forms.DateTimePicker();
            this._panelMensual = new System.Windows.Forms.Panel();
            this._btnGenerarMensual = new System.Windows.Forms.Button();
            this._lblTituloIndicador = new System.Windows.Forms.Label();
            this._lblIndicador = new System.Windows.Forms.Label();
            this._lblClasificacionGlobal = new System.Windows.Forms.Label();
            this._lblResumen = new System.Windows.Forms.Label();
            this._hostPacientes = new System.Windows.Forms.Panel();
            this._grillaPacientes = new System.Windows.Forms.DataGridView();
            this._colPacPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colPacMediciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colPacPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colPacClasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._panelDiagnostico = new System.Windows.Forms.Panel();
            this._btnGenerarDiagnostico = new System.Windows.Forms.Button();
            this._hostDiagnosticos = new System.Windows.Forms.Panel();
            this._grillaDiagnosticos = new System.Windows.Forms.DataGridView();
            this._colDiagDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDiagPacientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDiagIndicador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDiagOptimos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDiagSuboptimos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDiagDeficientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDiagBajoDesempeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._panelHistorial = new System.Windows.Forms.Panel();
            this._lblDni = new System.Windows.Forms.Label();
            this._txtDni = new System.Windows.Forms.TextBox();
            this._btnBuscar = new System.Windows.Forms.Button();
            this._lblPacienteHistorial = new System.Windows.Forms.Label();
            this._lblFormato = new System.Windows.Forms.Label();
            this._cmbFormato = new System.Windows.Forms.ComboBox();
            this._btnExportar = new System.Windows.Forms.Button();
            this._hostHistorial = new System.Windows.Forms.Panel();
            this._grillaHistorial = new System.Windows.Forms.DataGridView();
            this._colHistFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colHistTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colHistDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezadoPacientes = new System.Windows.Forms.DataGridViewCellStyle();
            estiloEncabezadoPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezadoPacientes.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezadoPacientes.ForeColor = System.Drawing.Color.White;
            estiloEncabezadoPacientes.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            System.Windows.Forms.DataGridViewCellStyle estiloCeldasPacientes = new System.Windows.Forms.DataGridViewCellStyle();
            estiloCeldasPacientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            estiloCeldasPacientes.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCeldasPacientes.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCeldasPacientes.SelectionForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle estiloFilasAltPacientes = new System.Windows.Forms.DataGridViewCellStyle();
            estiloFilasAltPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            System.Windows.Forms.DataGridViewCellStyle estiloPacMediciones = new System.Windows.Forms.DataGridViewCellStyle();
            estiloPacMediciones.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloPacPorcentaje = new System.Windows.Forms.DataGridViewCellStyle();
            estiloPacPorcentaje.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloPacClasificacion = new System.Windows.Forms.DataGridViewCellStyle();
            estiloPacClasificacion.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezadoDiagnosticos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloEncabezadoDiagnosticos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            estiloEncabezadoDiagnosticos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            estiloEncabezadoDiagnosticos.ForeColor = System.Drawing.Color.White;
            estiloEncabezadoDiagnosticos.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            System.Windows.Forms.DataGridViewCellStyle estiloCeldasDiagnosticos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloCeldasDiagnosticos.Font = new System.Drawing.Font("Segoe UI", 10F);
            estiloCeldasDiagnosticos.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            estiloCeldasDiagnosticos.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            estiloCeldasDiagnosticos.SelectionForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle estiloFilasAltDiagnosticos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloFilasAltDiagnosticos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            System.Windows.Forms.DataGridViewCellStyle estiloDiagPacientes = new System.Windows.Forms.DataGridViewCellStyle();
            estiloDiagPacientes.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloDiagIndicador = new System.Windows.Forms.DataGridViewCellStyle();
            estiloDiagIndicador.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloDiagOptimos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloDiagOptimos.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloDiagSuboptimos = new System.Windows.Forms.DataGridViewCellStyle();
            estiloDiagSuboptimos.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloDiagDeficientes = new System.Windows.Forms.DataGridViewCellStyle();
            estiloDiagDeficientes.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            System.Windows.Forms.DataGridViewCellStyle estiloDiagBajoDesempeno = new System.Windows.Forms.DataGridViewCellStyle();
            estiloDiagBajoDesempeno.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            ((System.ComponentModel.ISupportInitialize)(this._grillaPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaDiagnosticos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaHistorial)).BeginInit();
            this._panelBarra.SuspendLayout();
            this._panelMensual.SuspendLayout();
            this._hostPacientes.SuspendLayout();
            this._panelDiagnostico.SuspendLayout();
            this._hostDiagnosticos.SuspendLayout();
            this._panelHistorial.SuspendLayout();
            this._hostHistorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelBarra
            // 
            this._panelBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this._panelBarra.Controls.Add(this._btnVistaMensual);
            this._panelBarra.Controls.Add(this._btnVistaDiagnostico);
            this._panelBarra.Controls.Add(this._btnVistaHistorial);
            this._panelBarra.Controls.Add(this._lblPeriodo);
            this._panelBarra.Controls.Add(this._dtpMes);
            this._panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBarra.Height = 58;
            this._panelBarra.Name = "_panelBarra";
            this._panelBarra.TabIndex = 3;
            // 
            // _btnVistaMensual
            // 
            this._btnVistaMensual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnVistaMensual.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnVistaMensual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnVistaMensual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnVistaMensual.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnVistaMensual.ForeColor = System.Drawing.Color.White;
            this._btnVistaMensual.Location = new System.Drawing.Point(0, 15);
            this._btnVistaMensual.Name = "_btnVistaMensual";
            this._btnVistaMensual.Size = new System.Drawing.Size(168, 32);
            this._btnVistaMensual.TabIndex = 0;
            this._btnVistaMensual.Text = "Reporte mensual";
            this._btnVistaMensual.UseVisualStyleBackColor = false;
            this._btnVistaMensual.Click += new System.EventHandler(this.BtnVistaMensual_Click);
            // 
            // _btnVistaDiagnostico
            // 
            this._btnVistaDiagnostico.BackColor = System.Drawing.Color.White;
            this._btnVistaDiagnostico.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnVistaDiagnostico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnVistaDiagnostico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnVistaDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnVistaDiagnostico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this._btnVistaDiagnostico.Location = new System.Drawing.Point(176, 15);
            this._btnVistaDiagnostico.Name = "_btnVistaDiagnostico";
            this._btnVistaDiagnostico.Size = new System.Drawing.Size(168, 32);
            this._btnVistaDiagnostico.TabIndex = 1;
            this._btnVistaDiagnostico.Text = "Por diagnóstico";
            this._btnVistaDiagnostico.UseVisualStyleBackColor = false;
            this._btnVistaDiagnostico.Click += new System.EventHandler(this.BtnVistaDiagnostico_Click);
            // 
            // _btnVistaHistorial
            // 
            this._btnVistaHistorial.BackColor = System.Drawing.Color.White;
            this._btnVistaHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnVistaHistorial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this._btnVistaHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnVistaHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnVistaHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this._btnVistaHistorial.Location = new System.Drawing.Point(352, 15);
            this._btnVistaHistorial.Name = "_btnVistaHistorial";
            this._btnVistaHistorial.Size = new System.Drawing.Size(168, 32);
            this._btnVistaHistorial.TabIndex = 2;
            this._btnVistaHistorial.Text = "Historial del paciente";
            this._btnVistaHistorial.UseVisualStyleBackColor = false;
            this._btnVistaHistorial.Click += new System.EventHandler(this.BtnVistaHistorial_Click);
            // 
            // _lblPeriodo
            // 
            this._lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblPeriodo.Text = "Período:";
            this._lblPeriodo.Location = new System.Drawing.Point(760, 20);
            this._lblPeriodo.Name = "_lblPeriodo";
            this._lblPeriodo.Size = new System.Drawing.Size(72, 20);
            this._lblPeriodo.TabIndex = 3;
            // 
            // _dtpMes
            // 
            this._dtpMes.CustomFormat = "MMMM yyyy";
            this._dtpMes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpMes.Location = new System.Drawing.Point(836, 16);
            this._dtpMes.Name = "_dtpMes";
            this._dtpMes.ShowUpDown = true;
            this._dtpMes.Size = new System.Drawing.Size(170, 28);
            this._dtpMes.TabIndex = 4;
            // 
            // _panelMensual
            // 
            this._panelMensual.BackColor = System.Drawing.Color.White;
            this._panelMensual.Controls.Add(this._lblResumen);
            this._panelMensual.Controls.Add(this._lblClasificacionGlobal);
            this._panelMensual.Controls.Add(this._lblIndicador);
            this._panelMensual.Controls.Add(this._lblTituloIndicador);
            this._panelMensual.Controls.Add(this._btnGenerarMensual);
            this._panelMensual.Controls.Add(this._hostPacientes);
            this._panelMensual.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelMensual.Name = "_panelMensual";
            this._panelMensual.TabIndex = 0;
            // 
            // _btnGenerarMensual
            // 
            this._btnGenerarMensual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnGenerarMensual.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnGenerarMensual.FlatAppearance.BorderSize = 0;
            this._btnGenerarMensual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGenerarMensual.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnGenerarMensual.ForeColor = System.Drawing.Color.White;
            this._btnGenerarMensual.Location = new System.Drawing.Point(14, 12);
            this._btnGenerarMensual.Name = "_btnGenerarMensual";
            this._btnGenerarMensual.Size = new System.Drawing.Size(210, 32);
            this._btnGenerarMensual.TabIndex = 0;
            this._btnGenerarMensual.Text = "Ver reporte del mes";
            this._btnGenerarMensual.UseVisualStyleBackColor = false;
            this._btnGenerarMensual.Click += new System.EventHandler(this.BtnGenerarMensual_Click);
            // 
            // _lblTituloIndicador
            // 
            this._lblTituloIndicador.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblTituloIndicador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblTituloIndicador.Text = "Indicador global de eficacia";
            this._lblTituloIndicador.Location = new System.Drawing.Point(14, 54);
            this._lblTituloIndicador.Name = "_lblTituloIndicador";
            this._lblTituloIndicador.Size = new System.Drawing.Size(420, 20);
            this._lblTituloIndicador.TabIndex = 1;
            // 
            // _lblIndicador
            // 
            this._lblIndicador.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this._lblIndicador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this._lblIndicador.Text = "—";
            this._lblIndicador.Location = new System.Drawing.Point(12, 72);
            this._lblIndicador.Name = "_lblIndicador";
            this._lblIndicador.Size = new System.Drawing.Size(330, 56);
            this._lblIndicador.TabIndex = 2;
            // 
            // _lblClasificacionGlobal
            // 
            this._lblClasificacionGlobal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblClasificacionGlobal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this._lblClasificacionGlobal.Location = new System.Drawing.Point(16, 128);
            this._lblClasificacionGlobal.Name = "_lblClasificacionGlobal";
            this._lblClasificacionGlobal.Size = new System.Drawing.Size(320, 26);
            this._lblClasificacionGlobal.TabIndex = 3;
            // 
            // _lblResumen
            // 
            this._lblResumen.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this._lblResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this._lblResumen.Location = new System.Drawing.Point(370, 76);
            this._lblResumen.Name = "_lblResumen";
            this._lblResumen.Size = new System.Drawing.Size(760, 60);
            this._lblResumen.TabIndex = 4;
            // 
            // _hostPacientes
            // 
            this._hostPacientes.Controls.Add(this._grillaPacientes);
            this._hostPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._hostPacientes.Name = "_hostPacientes";
            this._hostPacientes.Padding = new System.Windows.Forms.Padding(14, 166, 14, 14);
            this._hostPacientes.TabIndex = 5;
            // 
            // _grillaPacientes
            // 
            this._grillaPacientes.AllowUserToAddRows = false;
            this._grillaPacientes.AllowUserToDeleteRows = false;
            this._grillaPacientes.AllowUserToResizeRows = false;
            this._grillaPacientes.AlternatingRowsDefaultCellStyle = estiloFilasAltPacientes;
            this._grillaPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grillaPacientes.BackgroundColor = System.Drawing.Color.White;
            this._grillaPacientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grillaPacientes.ColumnHeadersDefaultCellStyle = estiloEncabezadoPacientes;
            this._grillaPacientes.ColumnHeadersHeight = 34;
            this._grillaPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colPacPaciente,
            this._colPacMediciones,
            this._colPacPorcentaje,
            this._colPacClasificacion});
            this._grillaPacientes.DefaultCellStyle = estiloCeldasPacientes;
            this._grillaPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grillaPacientes.EnableHeadersVisualStyles = false;
            this._grillaPacientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grillaPacientes.MultiSelect = false;
            this._grillaPacientes.Name = "_grillaPacientes";
            this._grillaPacientes.ReadOnly = true;
            this._grillaPacientes.RowHeadersVisible = false;
            this._grillaPacientes.RowTemplate.Height = 32;
            this._grillaPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grillaPacientes.TabIndex = 0;
            // 
            // _colPacPaciente
            // 
            this._colPacPaciente.FillWeight = 40F;
            this._colPacPaciente.HeaderText = "Paciente";
            this._colPacPaciente.Name = "paciente";
            // 
            // _colPacMediciones
            // 
            this._colPacMediciones.DefaultCellStyle = estiloPacMediciones;
            this._colPacMediciones.FillWeight = 14F;
            this._colPacMediciones.HeaderText = "Mediciones";
            this._colPacMediciones.Name = "mediciones";
            // 
            // _colPacPorcentaje
            // 
            this._colPacPorcentaje.DefaultCellStyle = estiloPacPorcentaje;
            this._colPacPorcentaje.FillWeight = 16F;
            this._colPacPorcentaje.HeaderText = "% en rango";
            this._colPacPorcentaje.Name = "porcentaje";
            // 
            // _colPacClasificacion
            // 
            this._colPacClasificacion.DefaultCellStyle = estiloPacClasificacion;
            this._colPacClasificacion.FillWeight = 18F;
            this._colPacClasificacion.HeaderText = "Clasificación";
            this._colPacClasificacion.Name = "clasificacion";
            // 
            // _panelDiagnostico
            // 
            this._panelDiagnostico.BackColor = System.Drawing.Color.White;
            this._panelDiagnostico.Controls.Add(this._btnGenerarDiagnostico);
            this._panelDiagnostico.Controls.Add(this._hostDiagnosticos);
            this._panelDiagnostico.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelDiagnostico.Name = "_panelDiagnostico";
            this._panelDiagnostico.TabIndex = 1;
            this._panelDiagnostico.Visible = false;
            // 
            // _btnGenerarDiagnostico
            // 
            this._btnGenerarDiagnostico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnGenerarDiagnostico.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnGenerarDiagnostico.FlatAppearance.BorderSize = 0;
            this._btnGenerarDiagnostico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGenerarDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnGenerarDiagnostico.ForeColor = System.Drawing.Color.White;
            this._btnGenerarDiagnostico.Location = new System.Drawing.Point(14, 12);
            this._btnGenerarDiagnostico.Name = "_btnGenerarDiagnostico";
            this._btnGenerarDiagnostico.Size = new System.Drawing.Size(210, 32);
            this._btnGenerarDiagnostico.TabIndex = 0;
            this._btnGenerarDiagnostico.Text = "Generar reporte";
            this._btnGenerarDiagnostico.UseVisualStyleBackColor = false;
            this._btnGenerarDiagnostico.Click += new System.EventHandler(this.BtnGenerarDiagnostico_Click);
            // 
            // _hostDiagnosticos
            // 
            this._hostDiagnosticos.Controls.Add(this._grillaDiagnosticos);
            this._hostDiagnosticos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._hostDiagnosticos.Name = "_hostDiagnosticos";
            this._hostDiagnosticos.Padding = new System.Windows.Forms.Padding(14, 56, 14, 14);
            this._hostDiagnosticos.TabIndex = 1;
            // 
            // _grillaDiagnosticos
            // 
            this._grillaDiagnosticos.AllowUserToAddRows = false;
            this._grillaDiagnosticos.AllowUserToDeleteRows = false;
            this._grillaDiagnosticos.AllowUserToResizeRows = false;
            this._grillaDiagnosticos.AlternatingRowsDefaultCellStyle = estiloFilasAltDiagnosticos;
            this._grillaDiagnosticos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grillaDiagnosticos.BackgroundColor = System.Drawing.Color.White;
            this._grillaDiagnosticos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grillaDiagnosticos.ColumnHeadersDefaultCellStyle = estiloEncabezadoDiagnosticos;
            this._grillaDiagnosticos.ColumnHeadersHeight = 34;
            this._grillaDiagnosticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colDiagDiagnostico,
            this._colDiagPacientes,
            this._colDiagIndicador,
            this._colDiagOptimos,
            this._colDiagSuboptimos,
            this._colDiagDeficientes,
            this._colDiagBajoDesempeno});
            this._grillaDiagnosticos.DefaultCellStyle = estiloCeldasDiagnosticos;
            this._grillaDiagnosticos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grillaDiagnosticos.EnableHeadersVisualStyles = false;
            this._grillaDiagnosticos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this._grillaDiagnosticos.MultiSelect = false;
            this._grillaDiagnosticos.Name = "_grillaDiagnosticos";
            this._grillaDiagnosticos.ReadOnly = true;
            this._grillaDiagnosticos.RowHeadersVisible = false;
            this._grillaDiagnosticos.RowTemplate.Height = 32;
            this._grillaDiagnosticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grillaDiagnosticos.TabIndex = 0;
            // 
            // _colDiagDiagnostico
            // 
            this._colDiagDiagnostico.FillWeight = 30F;
            this._colDiagDiagnostico.HeaderText = "Diagnóstico";
            this._colDiagDiagnostico.Name = "diagnostico";
            // 
            // _colDiagPacientes
            // 
            this._colDiagPacientes.DefaultCellStyle = estiloDiagPacientes;
            this._colDiagPacientes.FillWeight = 10F;
            this._colDiagPacientes.HeaderText = "Pacientes";
            this._colDiagPacientes.Name = "pacientes";
            // 
            // _colDiagIndicador
            // 
            this._colDiagIndicador.DefaultCellStyle = estiloDiagIndicador;
            this._colDiagIndicador.FillWeight = 14F;
            this._colDiagIndicador.HeaderText = "Indicador prom. (%)";
            this._colDiagIndicador.Name = "indicador";
            // 
            // _colDiagOptimos
            // 
            this._colDiagOptimos.DefaultCellStyle = estiloDiagOptimos;
            this._colDiagOptimos.FillWeight = 10F;
            this._colDiagOptimos.HeaderText = "Óptimo";
            this._colDiagOptimos.Name = "optimos";
            // 
            // _colDiagSuboptimos
            // 
            this._colDiagSuboptimos.DefaultCellStyle = estiloDiagSuboptimos;
            this._colDiagSuboptimos.FillWeight = 10F;
            this._colDiagSuboptimos.HeaderText = "Subóptimo";
            this._colDiagSuboptimos.Name = "suboptimos";
            // 
            // _colDiagDeficientes
            // 
            this._colDiagDeficientes.DefaultCellStyle = estiloDiagDeficientes;
            this._colDiagDeficientes.FillWeight = 10F;
            this._colDiagDeficientes.HeaderText = "Deficiente";
            this._colDiagDeficientes.Name = "deficientes";
            // 
            // _colDiagBajoDesempeno
            // 
            this._colDiagBajoDesempeno.DefaultCellStyle = estiloDiagBajoDesempeno;
            this._colDiagBajoDesempeno.FillWeight = 16F;
            this._colDiagBajoDesempeno.HeaderText = "";
            this._colDiagBajoDesempeno.Name = "bajoDesempeno";
            // 
            // _panelHistorial
            // 
            this._panelHistorial.BackColor = System.Drawing.Color.White;
            this._panelHistorial.Controls.Add(this._btnExportar);
            this._panelHistorial.Controls.Add(this._cmbFormato);
            this._panelHistorial.Controls.Add(this._btnBuscar);
            this._panelHistorial.Controls.Add(this._lblFormato);
            this._panelHistorial.Controls.Add(this._lblPacienteHistorial);
            this._panelHistorial.Controls.Add(this._lblDni);
            this._panelHistorial.Controls.Add(this._txtDni);
            this._panelHistorial.Controls.Add(this._hostHistorial);
            this._panelHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelHistorial.Name = "_panelHistorial";
            this._panelHistorial.TabIndex = 2;
            this._panelHistorial.Visible = false;
            // 
            // _lblDni
            // 
            this._lblDni.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblDni.Text = "Identificación del paciente (DNI):";
            this._lblDni.Location = new System.Drawing.Point(14, 10);
            this._lblDni.Name = "_lblDni";
            this._lblDni.Size = new System.Drawing.Size(300, 18);
            this._lblDni.TabIndex = 0;
            // 
            // _txtDni
            // 
            this._txtDni.Font = new System.Drawing.Font("Segoe UI", 11F);
            this._txtDni.Location = new System.Drawing.Point(14, 28);
            this._txtDni.Name = "txtDniHist";
            this._txtDni.Size = new System.Drawing.Size(200, 28);
            this._txtDni.TabIndex = 1;
            this._txtDni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDni_KeyDown);
            // 
            // _btnBuscar
            // 
            this._btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnBuscar.FlatAppearance.BorderSize = 0;
            this._btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnBuscar.ForeColor = System.Drawing.Color.White;
            this._btnBuscar.Location = new System.Drawing.Point(226, 27);
            this._btnBuscar.Name = "_btnBuscar";
            this._btnBuscar.Size = new System.Drawing.Size(110, 30);
            this._btnBuscar.TabIndex = 2;
            this._btnBuscar.Text = "Buscar";
            this._btnBuscar.UseVisualStyleBackColor = false;
            this._btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // _lblPacienteHistorial
            // 
            this._lblPacienteHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblPacienteHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(120)))));
            this._lblPacienteHistorial.Location = new System.Drawing.Point(350, 30);
            this._lblPacienteHistorial.Name = "_lblPacienteHistorial";
            this._lblPacienteHistorial.Size = new System.Drawing.Size(560, 24);
            this._lblPacienteHistorial.TabIndex = 3;
            // 
            // _lblFormato
            // 
            this._lblFormato.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblFormato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this._lblFormato.Text = "Formato:";
            this._lblFormato.Location = new System.Drawing.Point(14, 70);
            this._lblFormato.Name = "_lblFormato";
            this._lblFormato.Size = new System.Drawing.Size(80, 18);
            this._lblFormato.TabIndex = 4;
            // 
            // _cmbFormato
            // 
            this._cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbFormato.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cmbFormato.Items.AddRange(new object[] {
            "PDF",
            "Excel",
            "JSON"});
            this._cmbFormato.Location = new System.Drawing.Point(96, 66);
            this._cmbFormato.Name = "_cmbFormato";
            this._cmbFormato.Size = new System.Drawing.Size(120, 26);
            this._cmbFormato.TabIndex = 5;
            // 
            // _btnExportar
            // 
            this._btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(108)))), ((int)(((byte)(223)))));
            this._btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnExportar.FlatAppearance.BorderSize = 0;
            this._btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnExportar.ForeColor = System.Drawing.Color.White;
            this._btnExportar.Location = new System.Drawing.Point(230, 64);
            this._btnExportar.Name = "_btnExportar";
            this._btnExportar.Size = new System.Drawing.Size(190, 30);
            this._btnExportar.TabIndex = 6;
            this._btnExportar.Text = "Exportar historial";
            this._btnExportar.UseVisualStyleBackColor = false;
            this._btnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // _hostHistorial
            // 
            this._hostHistorial.Controls.Add(this._grillaHistorial);
            this._hostHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this._hostHistorial.Name = "_hostHistorial";
            this._hostHistorial.Padding = new System.Windows.Forms.Padding(14, 104, 14, 14);
            this._hostHistorial.TabIndex = 7;
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
            this._colHistDescripcion});
            this._grillaHistorial.DefaultCellStyle = estiloCeldasHistorial;
            this._grillaHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this._colHistFecha.FillWeight = 16F;
            this._colHistFecha.HeaderText = "Fecha";
            this._colHistFecha.Name = "fecha";
            // 
            // _colHistTipo
            // 
            this._colHistTipo.FillWeight = 16F;
            this._colHistTipo.HeaderText = "Tipo";
            this._colHistTipo.Name = "tipo";
            // 
            // _colHistDescripcion
            // 
            this._colHistDescripcion.FillWeight = 68F;
            this._colHistDescripcion.HeaderText = "Descripción";
            this._colHistDescripcion.Name = "descripcion";
            // 
            // ReportesControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.Controls.Add(this._panelMensual);
            this.Controls.Add(this._panelDiagnostico);
            this.Controls.Add(this._panelHistorial);
            this.Controls.Add(this._panelBarra);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "ReportesControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 6);
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this._grillaPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaDiagnosticos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._grillaHistorial)).EndInit();
            this._hostHistorial.ResumeLayout(false);
            this._panelHistorial.ResumeLayout(false);
            this._hostDiagnosticos.ResumeLayout(false);
            this._panelDiagnostico.ResumeLayout(false);
            this._hostPacientes.ResumeLayout(false);
            this._panelMensual.ResumeLayout(false);
            this._panelBarra.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelBarra;
        private System.Windows.Forms.Button _btnVistaMensual;
        private System.Windows.Forms.Button _btnVistaDiagnostico;
        private System.Windows.Forms.Button _btnVistaHistorial;
        private System.Windows.Forms.Label _lblPeriodo;
        private System.Windows.Forms.DateTimePicker _dtpMes;
        private System.Windows.Forms.Panel _panelMensual;
        private System.Windows.Forms.Button _btnGenerarMensual;
        private System.Windows.Forms.Label _lblTituloIndicador;
        private System.Windows.Forms.Label _lblIndicador;
        private System.Windows.Forms.Label _lblClasificacionGlobal;
        private System.Windows.Forms.Label _lblResumen;
        private System.Windows.Forms.Panel _hostPacientes;
        private System.Windows.Forms.DataGridView _grillaPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colPacPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colPacMediciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colPacPorcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colPacClasificacion;
        private System.Windows.Forms.Panel _panelDiagnostico;
        private System.Windows.Forms.Button _btnGenerarDiagnostico;
        private System.Windows.Forms.Panel _hostDiagnosticos;
        private System.Windows.Forms.DataGridView _grillaDiagnosticos;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDiagDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDiagPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDiagIndicador;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDiagOptimos;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDiagSuboptimos;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDiagDeficientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDiagBajoDesempeno;
        private System.Windows.Forms.Panel _panelHistorial;
        private System.Windows.Forms.Label _lblDni;
        private System.Windows.Forms.TextBox _txtDni;
        private System.Windows.Forms.Button _btnBuscar;
        private System.Windows.Forms.Label _lblPacienteHistorial;
        private System.Windows.Forms.Label _lblFormato;
        private System.Windows.Forms.ComboBox _cmbFormato;
        private System.Windows.Forms.Button _btnExportar;
        private System.Windows.Forms.Panel _hostHistorial;
        private System.Windows.Forms.DataGridView _grillaHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colHistFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colHistTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colHistDescripcion;
    }
}
