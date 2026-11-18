using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;
using Negocio.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Reportes estadísticos (REQ-FUNC-011/012/013): reporte mensual de eficacia con semáforo
    /// óptimo/subóptimo/deficiente, reporte de eficacia agrupado por diagnóstico (destacando
    /// los grupos con bajo desempeño), historial clínico unificado por paciente y exportación
    /// auditada del historial a PDF/Excel.
    /// </summary>
    public partial class ReportesControl : UserControl
    {
        private readonly string _nombreUsuario = string.Empty;

        // Los controles de la interfaz se declaran en ReportesControl.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.

        private int _vistaActual;
        private int _idPacienteHistorial;

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public ReportesControl()
        {
            InitializeComponent();
        }

        public ReportesControl(string nombreUsuario) : this()
        {
            _nombreUsuario = nombreUsuario;

            // En tiempo de diseño no se toca la base de datos.
            if (Disenio.Activo)
            {
                return;
            }

            AplicarTextos();
            MostrarVista(0);
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Reaplica textos por cambio de idioma.</summary>
        public void RefrescarTextos() => AplicarTextos();

        /// <summary>Restablece la vista por defecto (al entrar al módulo).</summary>
        public void Recargar() => MostrarVista(_vistaActual);

        /// <summary>Muestra la vista de reporte mensual.</summary>
        private void BtnVistaMensual_Click(object? sender, EventArgs e) => MostrarVista(0);

        /// <summary>Muestra la vista de reporte por diagnóstico.</summary>
        private void BtnVistaDiagnostico_Click(object? sender, EventArgs e) => MostrarVista(1);

        /// <summary>Muestra la vista de historial del paciente.</summary>
        private void BtnVistaHistorial_Click(object? sender, EventArgs e) => MostrarVista(2);

        /// <summary>Genera el reporte mensual del período seleccionado.</summary>
        private void BtnGenerarMensual_Click(object? sender, EventArgs e) => CargarMensual();

        /// <summary>Genera el reporte por diagnóstico del período seleccionado.</summary>
        private void BtnGenerarDiagnostico_Click(object? sender, EventArgs e) => CargarDiagnosticos();

        /// <summary>Busca el historial al presionar Enter en el campo de DNI.</summary>
        private void TxtDni_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarHistorial();
            }
        }

        /// <summary>Busca el paciente por documento y muestra su historial unificado.</summary>
        private void BtnBuscar_Click(object? sender, EventArgs e) => BuscarHistorial();

        /// <summary>Exporta el historial del paciente en el formato elegido.</summary>
        private void BtnExportar_Click(object? sender, EventArgs e) => ExportarHistorial();

        private void MostrarVista(int vista)
        {
            _vistaActual = vista;
            _panelMensual.Visible = vista == 0;
            _panelDiagnostico.Visible = vista == 1;
            _panelHistorial.Visible = vista == 2;

            EstiloBotonVista(_btnVistaMensual, vista == 0);
            EstiloBotonVista(_btnVistaDiagnostico, vista == 1);
            EstiloBotonVista(_btnVistaHistorial, vista == 2);
        }

        private static void EstiloBotonVista(Button boton, bool activo)
        {
            boton.BackColor = activo ? Color.FromArgb(45, 108, 223) : Color.White;
            boton.ForeColor = activo ? Color.White : Color.FromArgb(28, 60, 105);
        }

        private void AplicarTextos()
        {
            _btnVistaMensual.Text = Localizacion("reportes.mensual");
            _btnVistaDiagnostico.Text = Localizacion("reportes.diagnostico");
            _btnVistaHistorial.Text = Localizacion("reportes.historial");
            _lblPeriodo.Text = Localizacion("reportes.periodo");

            _btnGenerarMensual.Text = Localizacion("reportes.generar");
            _lblTituloIndicador.Text = Localizacion("reportes.indicadorGlobal");
            if (_lblIndicador.Text.Length == 0 || _lblIndicador.Text == "—")
            {
                _lblIndicador.Text = "—";
            }
            _grillaPacientes.Columns["paciente"].HeaderText = Localizacion("panel.columna.paciente");
            _grillaPacientes.Columns["mediciones"].HeaderText = Localizacion("reportes.columna.mediciones");
            _grillaPacientes.Columns["porcentaje"].HeaderText = Localizacion("reportes.columna.porcentaje");
            _grillaPacientes.Columns["clasificacion"].HeaderText = Localizacion("reportes.columna.clasificacion");

            _btnGenerarDiagnostico.Text = Localizacion("reportes.generarDiag");
            _grillaDiagnosticos.Columns["diagnostico"].HeaderText = Localizacion("reportes.columna.diagnostico");
            _grillaDiagnosticos.Columns["pacientes"].HeaderText = Localizacion("reportes.columna.pacientes");
            _grillaDiagnosticos.Columns["indicador"].HeaderText = Localizacion("reportes.columna.indicador");
            _grillaDiagnosticos.Columns["optimos"].HeaderText = Localizacion("reportes.clas.optimo");
            _grillaDiagnosticos.Columns["suboptimos"].HeaderText = Localizacion("reportes.clas.suboptimo");
            _grillaDiagnosticos.Columns["deficientes"].HeaderText = Localizacion("reportes.clas.deficiente");
            _grillaDiagnosticos.Columns["bajoDesempeno"].HeaderText = "";

            _lblDni.Text = Localizacion("rin.identificacion");
            _btnBuscar.Text = Localizacion("comun.buscar");
            if (_lblPacienteHistorial.Text.Length == 0)
            {
                _lblPacienteHistorial.Text = Localizacion("reportes.historialVacio");
            }
            _lblFormato.Text = Localizacion("reportes.formato");
            int formatoPrevio = _cmbFormato.SelectedIndex;
            _cmbFormato.Items.Clear();
            _cmbFormato.Items.Add("PDF");
            _cmbFormato.Items.Add("Excel");
            _cmbFormato.Items.Add("JSON");
            _cmbFormato.SelectedIndex = formatoPrevio < 0 ? 0 : formatoPrevio;
            _btnExportar.Text = Localizacion("reportes.exportar");
            _grillaHistorial.Columns["fecha"].HeaderText = Localizacion("rin.columna.fecha");
            _grillaHistorial.Columns["tipo"].HeaderText = Localizacion("reportes.columna.tipo");
            _grillaHistorial.Columns["descripcion"].HeaderText = Localizacion("reportes.columna.descripcion");

            if (_lblResumen.Text.Length == 0)
            {
                _lblResumen.Text = Localizacion("reportes.sinReporte");
            }
        }

        private string ClaseTexto(ClasificacionControl clase) => clase switch
        {
            ClasificacionControl.Optimo => Localizacion("reportes.clas.optimo"),
            ClasificacionControl.Suboptimo => Localizacion("reportes.clas.suboptimo"),
            _ => Localizacion("reportes.clas.deficiente")
        };

        private static Color ColorClase(ClasificacionControl clase) => clase switch
        {
            ClasificacionControl.Optimo => Color.FromArgb(30, 130, 75),
            ClasificacionControl.Suboptimo => Color.FromArgb(190, 125, 20),
            _ => Color.FromArgb(185, 45, 40)
        };

        private void CargarMensual()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                ReporteEstadistico reporte = new ReporteLogic(contexto)
                    .GenerarReporteMensual(_dtpMes.Value.Year, _dtpMes.Value.Month, _nombreUsuario);

                var clase = ReporteLogic.Clasificar(reporte.IndicadorGlobalEficacia);
                _lblIndicador.Text = $"{reporte.IndicadorGlobalEficacia:0.00} %";
                _lblIndicador.ForeColor = ColorClase(clase);
                _lblClasificacionGlobal.Text = ClaseTexto(clase);
                _lblClasificacionGlobal.ForeColor = ColorClase(clase);

                int sinMediciones = 0;
                _grillaPacientes.Rows.Clear();
                if (!string.IsNullOrWhiteSpace(reporte.DetalleJson))
                {
                    using JsonDocument doc = JsonDocument.Parse(reporte.DetalleJson);
                    if (doc.RootElement.TryGetProperty("PacientesSinMediciones", out JsonElement sin))
                    {
                        sinMediciones = sin.GetInt32();
                    }
                    if (doc.RootElement.TryGetProperty("Pacientes", out JsonElement pacientes))
                    {
                        foreach (JsonElement paciente in pacientes.EnumerateArray())
                        {
                            string nombre = paciente.GetProperty("NombreCompleto").GetString() ?? "—";
                            int mediciones = paciente.GetProperty("Mediciones").GetInt32();
                            decimal porcentaje = paciente.GetProperty("PorcentajeEnRango").GetDecimal();
                            string claseTexto = paciente.GetProperty("Clasificacion").GetString() ?? "";
                            Enum.TryParse(claseTexto, out ClasificacionControl clasePaciente);
                            int indice = _grillaPacientes.Rows.Add(nombre, mediciones, $"{porcentaje:0.00} %", ClaseTexto(clasePaciente));
                            DataGridViewCell celda = _grillaPacientes.Rows[indice].Cells[3];
                            celda.Style.BackColor = ColorClase(clasePaciente);
                            celda.Style.ForeColor = Color.White;
                            celda.Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            celda.Style.SelectionBackColor = ColorClase(clasePaciente);
                            celda.Style.SelectionForeColor = Color.White;
                        }
                    }
                }

                _grillaPacientes.ClearSelection();
                int conDatos = reporte.CantidadOptimos + reporte.CantidadSuboptimos + reporte.CantidadDeficientes;
                _lblResumen.Text =
                    $"{Localizacion("reportes.pacientesDatos")} {conDatos}   ·   " +
                    $"{Localizacion("reportes.clas.optimo")}: {reporte.CantidadOptimos}   ·   " +
                    $"{Localizacion("reportes.clas.suboptimo")}: {reporte.CantidadSuboptimos}   ·   " +
                    $"{Localizacion("reportes.clas.deficiente")}: {reporte.CantidadDeficientes}   ·   " +
                    $"{Localizacion("reportes.sinMediciones")} {sinMediciones}";
            }
            catch (ValidacionNegocioException ex)
            {
                _lblResumen.Text = string.Join(Environment.NewLine, ex.Errores);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "ReportesControl");
            }
        }

        private void CargarDiagnosticos()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                List<FilaReporteDiagnostico> filas = new ReporteLogic(contexto)
                    .GenerarReportePorDiagnostico(_dtpMes.Value.Year, _dtpMes.Value.Month, null, _nombreUsuario);

                _grillaDiagnosticos.Rows.Clear();
                foreach (FilaReporteDiagnostico fila in filas)
                {
                    int indice = _grillaDiagnosticos.Rows.Add(
                        fila.NombreDiagnostico,
                        fila.CantidadPacientes,
                        $"{fila.IndicadorPromedio:0.00} %",
                        fila.CantidadOptimos,
                        fila.CantidadSuboptimos,
                        fila.CantidadDeficientes,
                        fila.BajoDesempeno ? Localizacion("reportes.bajoDesempeno") : string.Empty);

                    if (fila.BajoDesempeno)
                    {
                        _grillaDiagnosticos.Rows[indice].DefaultCellStyle.BackColor = Color.FromArgb(253, 236, 234);
                        _grillaDiagnosticos.Rows[indice].DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 222, 219);
                        _grillaDiagnosticos.Rows[indice].Cells[6].Style.ForeColor = Color.FromArgb(185, 45, 40);
                        _grillaDiagnosticos.Rows[indice].Cells[6].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        _grillaDiagnosticos.Rows[indice].Cells[2].Style.ForeColor = Color.FromArgb(185, 45, 40);
                        _grillaDiagnosticos.Rows[indice].Cells[2].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    }
                }
                _grillaDiagnosticos.ClearSelection();
            }
            catch (ValidacionNegocioException ex)
            {
                MessageBox.Show(FindForm(), string.Join(Environment.NewLine, ex.Errores), Localizacion("mod.reportes"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "ReportesControl");
            }
        }

        private void BuscarHistorial()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                Paciente? paciente = new PacienteLogic(contexto).BuscarPorDNI(_txtDni.Text.Trim());
                if (paciente == null)
                {
                    _idPacienteHistorial = 0;
                    _grillaHistorial.Rows.Clear();
                    _lblPacienteHistorial.Text = Localizacion("rin.pacienteNoEncontrado");
                    return;
                }

                _idPacienteHistorial = paciente.Id;
                _lblPacienteHistorial.Text = $"{paciente.NombreCompleto} ({paciente.DNI})";

                List<ItemHistorial> items = new ReporteLogic(contexto).ObtenerHistorialPaciente(paciente.Id);
                _grillaHistorial.Rows.Clear();
                foreach (ItemHistorial item in items)
                {
                    _grillaHistorial.Rows.Add(item.Fecha.ToString("dd/MM/yyyy"), item.Tipo, item.Descripcion);
                }
                if (items.Count == 0)
                {
                    _lblPacienteHistorial.Text += $" — {Localizacion("reportes.sinItems")}";
                }
                _grillaHistorial.ClearSelection();
            }
            catch (ValidacionNegocioException ex)
            {
                _lblPacienteHistorial.Text = string.Join(Environment.NewLine, ex.Errores);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "ReportesControl");
            }
        }

        private void ExportarHistorial()
        {
            if (_idPacienteHistorial == 0)
            {
                MessageBox.Show(FindForm(), Localizacion("reportes.historialVacio"), Localizacion("mod.reportes"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formato = _cmbFormato.SelectedIndex == 1 ? "Excel" : "PDF";
            try
            {
                using var contexto = new NegocioDbContext();
                Paciente paciente = contexto.Pacientes.AsNoTracking().First(p => p.Id == _idPacienteHistorial);
                ExportacionHistorial exportacion = new ReporteLogic(contexto)
                    .ExportarHistorialPaciente(_idPacienteHistorial, formato, _nombreUsuario);
                string ruta = Exportadores.EscribirHistorial(exportacion, paciente.NombreCompleto, formato);

                MessageBox.Show(FindForm(), $"{Localizacion("reportes.exportadoOk")}{Environment.NewLine}{ruta}",
                    Localizacion("reportes.exportar"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidacionNegocioException ex)
            {
                MessageBox.Show(FindForm(), string.Join(Environment.NewLine, ex.Errores), Localizacion("mod.reportes"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "ReportesControl");
            }
        }
    }
}
