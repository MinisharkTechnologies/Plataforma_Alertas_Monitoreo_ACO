using System.Drawing;
using System.Windows.Forms;
using Negocio.BLL;
using Negocio.DAL.Context;
using Services.DomainModel;
using Services.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Pantalla de bloqueo por integridad (T08): reemplaza a la ventana de log-in cuando la verificación de
    /// arranque detecta alteraciones en la base realizadas por fuera del sistema. Muestra la lista de registros
    /// alterados y permite recuperar la base: un usuario con permiso de respaldos (SI004) inicia sesión, elige un
    /// respaldo sano de la lista (o otro archivo .bak) y lo restaura, o recalcula los dígitos con confirmación.
    /// Todo queda en la bitácora (capa «Integridad»). Devuelve <see cref="DialogResult.Retry"/> si la base quedó sana.
    /// </summary>
    public sealed partial class IntegridadVulneradaForm : Form
    {
        /// <summary>Código del permiso que habilita la recuperación.</summary>
        public const string PermisoRespaldos = "SI004";
        private const string BaseNegocio = "OpenRIN_Negocio";

        // Los controles se declaran en IntegridadVulneradaForm.Designer.cs (patrón de Visual Studio).
        private UsuarioAutenticado? _sesion;

        private static string T(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Crea la pantalla a partir del resultado de la auditoría (nulo si no pudo ejecutarse).</summary>
        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public IntegridadVulneradaForm()
        {
            InitializeComponent();
        }

        public IntegridadVulneradaForm(ResultadoAuditoria? auditoria, IReadOnlyList<string> problemas)
        {
            InitializeComponent();

            // En tiempo de diseño no se tocan la base de datos ni la bitácora.
            if (Disenio.Activo)
            {
                return;
            }

            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            if (auditoria != null && auditoria.Alterados.Count > 0)
            {
                foreach (RegistroAlterado r in auditoria.Alterados)
                {
                    _lstAlterados.Items.Add(new ListViewItem(new[] { r.Tabla, r.Id == 0 ? "—" : r.Id.ToString(), r.Motivo }));
                }
            }
            else
            {
                foreach (string p in problemas)
                {
                    _lstAlterados.Items.Add(new ListViewItem(new[] { "—", "—", p }));
                }
            }

            BitacoraService.Registrar(LogLevel.Fatal,
                $"Integridad — Alteración detectada: {(auditoria?.Alterados.Count ?? problemas.Count)} registro(s)/tabla(s) con dígitos verificadores inválidos. Ingreso bloqueado.",
                capa: "Integridad");
        }

        /// <summary>Abre la recuperación con las credenciales ingresadas.</summary>
        private void BtnEntrar_Click(object? sender, EventArgs e) => IniciarSesion();

        /// <summary>Restaura el respaldo seleccionado de la lista.</summary>
        private void BtnRestaurarSel_Click(object? sender, EventArgs e) => RestaurarSeleccionado();

        /// <summary>Restaura un respaldo elegido con el explorador de archivos.</summary>
        private void BtnRestaurarArchivo_Click(object? sender, EventArgs e) => RestaurarDesdeArchivo();

        /// <summary>Recalcula los dígitos verificadores (acepta el estado actual).</summary>
        private void BtnRecalcular_Click(object? sender, EventArgs e) => Recalcular();

        /// <summary>Cierra la pantalla sin recuperar la base.</summary>
        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void IniciarSesion()
        {
            try
            {
                UsuarioAutenticado usuario = SeguridadService.Autenticar(_txtUsuario.Text.Trim(), _txtClave.Text);
                if (!SeguridadService.TienePermiso(usuario.Id, PermisoRespaldos))
                {
                    BitacoraService.Warning($"Integridad — {usuario.NombreUsuario} intentó recuperar la base sin permiso de respaldos.", usuario.NombreUsuario);
                    Aviso(T("integridad.rec.sinPermiso"), MessageBoxIcon.Warning);
                    return;
                }

                _sesion = usuario;
                _txtClave.Clear();
                _lblEstadoSesion.ForeColor = Color.FromArgb(46, 125, 50);
                _lblEstadoSesion.Text = string.Format(T("integridad.rec.sesionDe"), usuario.NombreCompleto);
                _panelRecuperacion.Enabled = true;
                foreach (Button boton in new[] { _btnRestaurarSel, _btnRestaurarArchivo, _btnRecalcular })
                {
                    boton.ForeColor = Color.White; // al habilitar el panel, el botón vuelve a pintarse con su color
                    boton.Invalidate();
                }
                BitacoraService.Info("Integridad — inició sesión para recuperar la base.", usuario.NombreUsuario);
                CargarRespaldos();
            }
            catch (Exception ex)
            {
                Aviso(ex is ReglaNegocioException || ex is CredencialesInvalidasException || ex is UsuarioBloqueadoException
                    ? ex.Message : string.Format(T("integridad.rec.error"), ex.Message), MessageBoxIcon.Warning);
            }
        }

        private void CargarRespaldos()
        {
            _lstRespaldos.Items.Clear();
            try
            {
                foreach (RespaldoRegistro r in BackupService.ListarRespaldos().Where(x => x.BaseDatos == BaseNegocio))
                {
                    string estado = !r.ArchivoExiste ? T("integridad.rec.noExiste") : r.Sano ? T("integridad.rec.sano") : T("integridad.rec.noSano");
                    var item = new ListViewItem(new[]
                    {
                        r.Fecha.ToString("yyyy-MM-dd HH:mm:ss"), r.Origen, estado,
                        (r.TamanoBytes / 1048576.0).ToString("0.0") + " MB", r.Archivo
                    }) { Tag = r };
                    if (!r.ArchivoExiste || !r.Sano)
                    {
                        item.ForeColor = Color.Gray;
                    }
                    _lstRespaldos.Items.Add(item);
                }
                if (_lstRespaldos.Items.Count == 0)
                {
                    _lstRespaldos.Items.Add(new ListViewItem(new[] { "", "", T("integridad.rec.sinRespaldos"), "", "" }));
                }
            }
            catch (Exception ex)
            {
                Aviso(string.Format(T("integridad.rec.error"), ex.Message), MessageBoxIcon.Error);
            }
        }

        private void RestaurarSeleccionado()
        {
            if (_lstRespaldos.SelectedItems.Count == 0 || _lstRespaldos.SelectedItems[0].Tag is not RespaldoRegistro registro)
            {
                Aviso(T("sistema.respaldos.seleccione"), MessageBoxIcon.Information);
                return;
            }
            Restaurar(registro.Archivo);
        }

        private void RestaurarDesdeArchivo()
        {
            using var dialogo = new OpenFileDialog { Filter = T("integridad.rec.elegirArchivo"), CheckFileExists = true };
            if (dialogo.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            try
            {
                if (!string.Equals(BackupService.ObtenerBaseDelArchivo(dialogo.FileName), BaseNegocio, StringComparison.OrdinalIgnoreCase))
                {
                    Aviso(T("integridad.rec.soloNegocio"), MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                Aviso(string.Format(T("integridad.rec.error"), ex.Message), MessageBoxIcon.Error);
                return;
            }
            Restaurar(dialogo.FileName);
        }

        private void Restaurar(string archivo)
        {
            if (_sesion == null || !Confirmar(string.Format(T("integridad.rec.confirmarRestaurar"), archivo)))
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                BackupService.RestaurarBackup(archivo, _sesion.NombreUsuario);
                BitacoraService.Warning($"Integridad — la base de negocio se restauró desde {archivo}.", _sesion.NombreUsuario);
                TerminarSiEstaSana(T("integridad.rec.restaurada"));
            }
            catch (Exception ex)
            {
                BitacoraService.Error($"Integridad — falló la restauración desde {archivo}.", ex, _sesion.NombreUsuario);
                Aviso(string.Format(T("integridad.rec.error"), ex.Message), MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void Recalcular()
        {
            if (_sesion == null || !Confirmar(T("integridad.rec.confirmarRecalcular")))
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                int filas;
                using (var contexto = new NegocioDbContext())
                {
                    filas = new IntegridadLogic(contexto).RecalcularTodo();
                }
                int filasServices = Services.BLL.IntegridadServicesLogic.RecalcularTodo();
                BitacoraService.Warning($"Integridad — dígitos verificadores recalculados (Negocio: {filas} · Services: {filasServices} filas): se aceptó el estado actual de los datos.", _sesion.NombreUsuario);
                TerminarSiEstaSana(string.Format(T("integridad.rec.recalculada"), $"Negocio: {filas} · Services: {filasServices}"));
            }
            catch (Exception ex)
            {
                BitacoraService.Error("Integridad — falló el recálculo de dígitos.", ex, _sesion.NombreUsuario);
                Aviso(string.Format(T("integridad.rec.error"), ex.Message), MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>Vuelve a auditar: si quedó sana cierra la pantalla y deja seguir al ingreso; si no, actualiza la lista.</summary>
        private void TerminarSiEstaSana(string mensajeOk)
        {
            ResultadoAuditoria? nueva = VerificacionArranque.Auditar();
            if (nueva != null && nueva.Problemas.Count == 0)
            {
                BitacoraService.Info("Integridad — verificación posterior correcta: se habilita el ingreso.", _sesion?.NombreUsuario ?? "");
                Aviso(mensajeOk, MessageBoxIcon.Information);
                DialogResult = DialogResult.Retry;
                Close();
                return;
            }

            _lstAlterados.Items.Clear();
            foreach (RegistroAlterado r in nueva?.Alterados ?? new List<RegistroAlterado>())
            {
                _lstAlterados.Items.Add(new ListViewItem(new[] { r.Tabla, r.Id == 0 ? "—" : r.Id.ToString(), r.Motivo }));
            }
            Aviso(T("integridad.rec.sigueVulnerada"), MessageBoxIcon.Warning);
            CargarRespaldos();
        }

        private bool Confirmar(string texto)
            => MessageBox.Show(this, texto, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private void Aviso(string texto, MessageBoxIcon icono) => MessageBox.Show(this, texto, Text, MessageBoxButtons.OK, icono);
    }
}
