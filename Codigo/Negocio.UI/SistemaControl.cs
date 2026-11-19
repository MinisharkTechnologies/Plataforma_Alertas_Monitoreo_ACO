using System.Text.Encodings.Web;
using Services.DomainModel.Auditoria;
using System.Text.Json;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Services.DomainModel;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Administración del sistema (REQ-ARQ-004/006, solo perfil sysadmin): gestión de usuarios
    /// (listado, alta vía la API de seguridad, habilitación/deshabilitación) y consulta de la
    /// bitácora centralizada con filtro por nivel mínimo.
    /// </summary>
    public partial class SistemaControl : UserControl
    {



        private List<CambioAuditado> _cambios = new();

        private List<Idioma> _idiomasEditor = new();
        private List<TextoLocalizacion> _textosEditor = new();

        private bool _actualizandoArbol;

        private static readonly string[] EntidadesAuditables =
        {
            "Pacientes", "ObrasSociales", "Diagnosticos", "HistoriasClinicas", "EventosAdversos",
            "MedicionesRIN", "Alertas", "Turnos", "Seguimientos", "Usuarios", "ReportesEstadisticos"
        };

        private int _vistaActual;
        private List<UsuarioListado> _usuarios = new();

        /// <summary>Constructor para el disenador de Visual Studio (no se usa en ejecucion).</summary>
        public SistemaControl()
        {
            InitializeComponent();
        }

        /// <summary>Constructor de ejecucion: arma la interfaz y carga los datos reales.</summary>
        public SistemaControl(bool enEjecucion) : this()
        {
            if (!enEjecucion || Disenio.Activo)
            {
                return;
            }

            ConectarEventos();
            AplicarTextos();
            MostrarVista(0);
            CargarUsuarios();
        }

        /// <summary>Conecta los eventos de la interfaz (no van en el Designer para que VS no los reescriba).</summary>
        private void ConectarEventos()
        {
            _btnVistaUsuarios.Click += (s, e) => MostrarVista(0);
            _btnVistaBitacora.Click += (s, e) => MostrarVista(1);
            _btnVistaCambios.Click += (s, e) => MostrarVista(2);
            _btnVistaIdiomas.Click += (s, e) => MostrarVista(3);
            _btnVistaPerfiles.Click += (s, e) => MostrarVista(4);
            _btnVistaRespaldos.Click += (s, e) => MostrarVista(5);

            _btnNuevoUsuario.Click += (s, e) => AbrirAltaUsuario();
            _btnHabilitar.Click += (s, e) => CambiarEstadoSeleccionado(true);
            _btnDeshabilitar.Click += (s, e) => CambiarEstadoSeleccionado(false);

            _btnActualizar.Click += (s, e) => CargarBitacora();

            _btnBuscarCambios.Click += (s, e) => CargarCambios();
            _grillaCambios.SelectionChanged += (s, e) => MostrarDetalleCambio();
            _btnRestaurarCambio.Click += (s, e) => RestaurarCambioSeleccionado();

            _btnNuevoIdioma.Click += (s, e) => AbrirAltaIdioma();
            _btnEliminarIdioma.Click += (s, e) => EliminarIdiomaSeleccionado();
            _cmbIdiomaEditor.SelectedIndexChanged += (s, e) => CargarTextosDelIdioma();
            _btnAgregarLeyenda.Click += (s, e) => AgregarLeyendaInline();
            _btnGuardarTextos.Click += (s, e) => GuardarCambiosTextos();

            _cmbPerfiles.SelectedIndexChanged += (s, e) => CargarArbolDelPerfil();
            _btnMarcarTodo.Click += (s, e) => MarcarTodo(true);
            _btnDesmarcarTodo.Click += (s, e) => MarcarTodo(false);
            _btnGuardarPermisos.Click += (s, e) => GuardarPermisosDelPerfil();
            _treePermisos.AfterCheck += TreePermisos_AfterCheck;
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Recarga la vista activa (al entrar al módulo).</summary>
        public void Recargar()
        {
            switch (_vistaActual)
            {
                case 0:
                    CargarUsuarios();
                    break;
                case 1:
                    CargarBitacora();
                    break;
                case 2:
                    CargarCambios();
                    break;
                case 3:
                    CargarIdiomas();
                    break;
                case 4:
                    CargarPerfiles();
                    break;
                case 5:
                    _panelRespaldos.Recargar();
                    break;
            }
        }

        /// <summary>Reaplica textos por cambio de idioma y recarga.</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            Recargar();
        }

        private void MostrarVista(int vista)
        {
            _vistaActual = vista;
            _panelUsuarios.Visible = vista == 0;
            _panelBitacora.Visible = vista == 1;
            _panelCambios.Visible = vista == 2;
            _panelIdiomas.Visible = vista == 3;
            _panelPerfiles.Visible = vista == 4;
            _panelRespaldos.Visible = vista == 5;
            EstiloBotonVista(_btnVistaUsuarios, vista == 0);
            EstiloBotonVista(_btnVistaBitacora, vista == 1);
            EstiloBotonVista(_btnVistaCambios, vista == 2);
            EstiloBotonVista(_btnVistaIdiomas, vista == 3);
            EstiloBotonVista(_btnVistaPerfiles, vista == 4);
            EstiloBotonVista(_btnVistaRespaldos, vista == 5);
            Recargar();
        }

        private static void EstiloBotonVista(Button boton, bool activo)
        {
            boton.BackColor = activo ? Color.FromArgb(45, 108, 223) : Color.White;
            boton.ForeColor = activo ? Color.White : Color.FromArgb(28, 60, 105);
        }

        private void AplicarTextos()
        {
            _btnVistaUsuarios.Text = Localizacion("sistema.usuarios");
            _btnVistaBitacora.Text = Localizacion("sistema.bitacora");
            _btnVistaRespaldos.Text = Localizacion("sistema.respaldos");
            _panelRespaldos.AplicarTextos();
            _btnNuevoUsuario.Text = Localizacion("sistema.nuevoUsuario");
            _btnHabilitar.Text = Localizacion("sistema.habilitar");
            _btnDeshabilitar.Text = Localizacion("sistema.deshabilitar");
            _grillaUsuarios.Columns["usuario"].HeaderText = Localizacion("sistema.columna.usuario");
            _grillaUsuarios.Columns["nombre"].HeaderText = Localizacion("sistema.columna.nombre");
            _grillaUsuarios.Columns["perfil"].HeaderText = Localizacion("sistema.columna.perfil");
            _grillaUsuarios.Columns["email"].HeaderText = Localizacion("pacientes.email");
            _grillaUsuarios.Columns["activo"].HeaderText = Localizacion("sistema.columna.activo");
            _grillaUsuarios.Columns["intentos"].HeaderText = Localizacion("sistema.columna.intentos");
            _grillaUsuarios.Columns["bloqueado"].HeaderText = Localizacion("sistema.columna.bloqueado");

            _lblNivel.Text = Localizacion("sistema.nivel");
            int previo = _cmbNivel.SelectedIndex;
            _cmbNivel.Items.Clear();
            _cmbNivel.Items.Add(Localizacion("sistema.nivel.todos"));
            _cmbNivel.Items.Add("Info");
            _cmbNivel.Items.Add("Warning");
            _cmbNivel.Items.Add("Error");
            _cmbNivel.SelectedIndex = previo < 0 ? 0 : previo;
            _btnActualizar.Text = Localizacion("sistema.actualizar");
            _grillaBitacora.Columns["fecha"].HeaderText = Localizacion("rin.columna.fecha");
            _grillaBitacora.Columns["nivel"].HeaderText = Localizacion("sistema.columna.nivel");
            _grillaBitacora.Columns["capa"].HeaderText = Localizacion("sistema.columna.capa");
            _grillaBitacora.Columns["usuario"].HeaderText = Localizacion("sistema.columna.usuario");
            _grillaBitacora.Columns["mensaje"].HeaderText = Localizacion("sistema.columna.mensaje");

            _btnVistaCambios.Text = Localizacion("sistema.cambios");
            _lblEntidadCambios.Text = Localizacion("sistema.cambios.entidad");
            _lblIdCambios.Text = Localizacion("sistema.cambios.idRegistro");
            _btnBuscarCambios.Text = Localizacion("sistema.cambios.buscar");
            int seleccionPrevia = _cmbEntidadCambios.SelectedIndex;
            _cmbEntidadCambios.Items.Clear();
            _cmbEntidadCambios.Items.Add(Localizacion("sistema.cambios.todas"));
            foreach (string entidad in EntidadesAuditables)
            {
                _cmbEntidadCambios.Items.Add(entidad);
            }
            _cmbEntidadCambios.SelectedIndex = seleccionPrevia < 0 ? 0 : seleccionPrevia;
            _grillaCambios.Columns["fecha"].HeaderText = Localizacion("rin.columna.fecha");
            _grillaCambios.Columns["usuario"].HeaderText = Localizacion("sistema.columna.usuario");
            _grillaCambios.Columns["tipo"].HeaderText = Localizacion("sistema.cambios.columna.tipo");
            _grillaCambios.Columns["entidad"].HeaderText = Localizacion("sistema.cambios.columna.entidad");
            _grillaCambios.Columns["registro"].HeaderText = Localizacion("sistema.cambios.columna.registro");
            _lblCambioAnterior.Text = Localizacion("sistema.cambios.anterior");
            _lblCambioNuevo.Text = Localizacion("sistema.cambios.nuevo");
            _btnRestaurarCambio.Text = Localizacion("sistema.cambios.restaurar");

            _btnVistaIdiomas.Text = Localizacion("sistema.idiomas");
            _btnNuevoIdioma.Text = Localizacion("idiomas.nuevo");
            _btnEliminarIdioma.Text = Localizacion("idiomas.eliminar");
            _grillaIdiomas.Columns["codigo"].HeaderText = Localizacion("idiomas.codigo");
            _grillaIdiomas.Columns["nombre"].HeaderText = Localizacion("idiomas.nombre");
            _grillaTextos.Columns["clave"].HeaderText = Localizacion("idiomas.clave");
            _grillaTextos.Columns["valor"].HeaderText = Localizacion("idiomas.valor");
            _btnAgregarLeyenda.Text = Localizacion("idiomas.agregar");
            _btnGuardarTextos.Text = Localizacion("idiomas.guardar");

            _btnVistaPerfiles.Text = Localizacion("sistema.perfiles");
            _btnGuardarPermisos.Text = Localizacion("perfiles.guardar");
            _btnMarcarTodo.Text = Localizacion("perfiles.marcarTodo");
            _btnDesmarcarTodo.Text = Localizacion("perfiles.desmarcarTodo");
        }

        private void CargarUsuarios()
        {
            try
            {
                _usuarios = SeguridadService.ObtenerUsuarios();
                _grillaUsuarios.Rows.Clear();
                foreach (UsuarioListado usuario in _usuarios)
                {
                    int indice = _grillaUsuarios.Rows.Add(
                        usuario.NombreUsuario,
                        usuario.NombreCompleto,
                        usuario.Perfil,
                        usuario.Email ?? "—",
                        usuario.Activo ? Localizacion("sistema.si") : Localizacion("sistema.no"),
                        usuario.IntentosFallidos,
                        usuario.BloqueadoHasta?.ToString("dd/MM/yyyy HH:mm") ?? "—");

                    DataGridViewCell celdaActivo = _grillaUsuarios.Rows[indice].Cells[4];
                    celdaActivo.Style.ForeColor = usuario.Activo ? Color.FromArgb(30, 130, 75) : Color.FromArgb(185, 45, 40);
                    celdaActivo.Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    celdaActivo.Style.SelectionForeColor = celdaActivo.Style.ForeColor;
                }
                _grillaUsuarios.ClearSelection();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void CargarBitacora()
        {
            try
            {
                LogLevel? nivel = _cmbNivel.SelectedIndex switch
                {
                    1 => LogLevel.Info,
                    2 => LogLevel.Warning,
                    3 => LogLevel.Error,
                    _ => null
                };

                List<LogEntry> entradas = BitacoraService.ObtenerUltimos(200, nivel);
                _grillaBitacora.Rows.Clear();
                foreach (LogEntry entrada in entradas)
                {
                    int indice = _grillaBitacora.Rows.Add(
                        entrada.Fecha.ToString("dd/MM/yyyy HH:mm:ss"),
                        entrada.Nivel.ToString(),
                        entrada.Capa ?? "—",
                        entrada.Usuario ?? "—",
                        entrada.Mensaje);

                    DataGridViewCell celdaNivel = _grillaBitacora.Rows[indice].Cells[1];
                    if (entrada.Nivel >= LogLevel.Error)
                    {
                        celdaNivel.Style.ForeColor = Color.FromArgb(185, 45, 40);
                        celdaNivel.Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else if (entrada.Nivel == LogLevel.Warning)
                    {
                        celdaNivel.Style.ForeColor = Color.FromArgb(190, 125, 20);
                        celdaNivel.Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else
                    {
                        celdaNivel.Style.ForeColor = Color.FromArgb(90, 110, 135);
                    }
                    celdaNivel.Style.SelectionForeColor = celdaNivel.Style.ForeColor;
                }
                _grillaBitacora.ClearSelection();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void CargarCambios()
        {
            try
            {
                string? entidad = _cmbEntidadCambios.SelectedIndex <= 0 ? null : _cmbEntidadCambios.SelectedItem?.ToString();
                int? idRegistro = null;
                if (_txtIdCambios.Text.Trim().Length > 0)
                {
                    if (!int.TryParse(_txtIdCambios.Text.Trim(), out int id))
                    {
                        MessageBox.Show(FindForm(), Localizacion("sistema.cambios.sinId"), Localizacion("sistema.cambios"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    idRegistro = id;
                }

                using var contexto = new NegocioDbContext();
                _cambios = new AuditoriaLogic(contexto).ObtenerHistorial(entidad, idRegistro);
                _grillaCambios.Rows.Clear();
                foreach (CambioAuditado cambio in _cambios)
                {
                    int indice = _grillaCambios.Rows.Add(
                        cambio.FechaCambio.ToString("dd/MM/yyyy HH:mm:ss"),
                        cambio.Usuario,
                        cambio.TipoCambio,
                        cambio.Entidad,
                        cambio.IdRegistro);

                    DataGridViewCell celdaTipo = _grillaCambios.Rows[indice].Cells[2];
                    celdaTipo.Style.ForeColor = cambio.TipoCambio switch
                    {
                        "Alta" => Color.FromArgb(30, 130, 75),
                        "Baja" => Color.FromArgb(185, 45, 40),
                        _ => Color.FromArgb(190, 125, 20)
                    };
                    celdaTipo.Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    celdaTipo.Style.SelectionForeColor = celdaTipo.Style.ForeColor;
                }
                _grillaCambios.ClearSelection();
                MostrarDetalleCambio();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void MostrarDetalleCambio()
        {
            if (_grillaCambios.SelectedRows.Count == 0 || _grillaCambios.SelectedRows[0].Index >= _cambios.Count)
            {
                _txtCambioAnterior.Text = string.Empty;
                _txtCambioNuevo.Text = string.Empty;
                return;
            }
            CambioAuditado cambio = _cambios[_grillaCambios.SelectedRows[0].Index];
            _txtCambioAnterior.Text = EmbellecerJson(cambio.DatosAnteriores);
            _txtCambioNuevo.Text = EmbellecerJson(cambio.DatosNuevos);
        }

        /// <summary>Reformatea un JSON de auditoría con sangría para su lectura (sin escapes).</summary>
        private static string EmbellecerJson(string? json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return string.Empty;
            }
            try
            {
                using JsonDocument documento = JsonDocument.Parse(json);
                return JsonSerializer.Serialize(documento.RootElement, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
            }
            catch (JsonException)
            {
                return json;
            }
        }

        private void RestaurarCambioSeleccionado()
        {
            if (_grillaCambios.SelectedRows.Count == 0 || _grillaCambios.SelectedRows[0].Index >= _cambios.Count)
            {
                MessageBox.Show(FindForm(), Localizacion("sistema.cambios.selCambio"), Localizacion("sistema.cambios"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CambioAuditado cambio = _cambios[_grillaCambios.SelectedRows[0].Index];
            if (MessageBox.Show(FindForm(), Localizacion("sistema.cambios.confirmar"), Localizacion("sistema.cambios"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string usuario = SesionActual.Instancia.NombreUsuario;
                if (usuario.Length == 0)
                {
                    usuario = "sistema";
                }
                using var contexto = new NegocioDbContext();
                (bool ok, string mensaje) = new AuditoriaLogic(contexto).Restaurar(cambio.Id, usuario);
                MessageBox.Show(FindForm(), mensaje, Localizacion("sistema.cambios"),
                    MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                CargarCambios();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        // ------------------------------------------------------------------ idiomas (T05)

        private void CargarIdiomas()
        {
            try
            {
                _idiomasEditor = LocalizationService.Idiomas.ToList();
                _grillaIdiomas.Rows.Clear();
                foreach (Idioma idioma in _idiomasEditor)
                {
                    _grillaIdiomas.Rows.Add(idioma.Codigo, idioma.Nombre);
                }
                _grillaIdiomas.ClearSelection();

                int previo = _cmbIdiomaEditor.SelectedIndex;
                _cmbIdiomaEditor.Items.Clear();
                foreach (Idioma idioma in _idiomasEditor)
                {
                    _cmbIdiomaEditor.Items.Add(idioma);
                }
                _cmbIdiomaEditor.SelectedIndex = previo < 0 || previo >= _idiomasEditor.Count ? 0 : previo;
                CargarTextosDelIdioma();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void CargarTextosDelIdioma()
        {
            if (_cmbIdiomaEditor.SelectedIndex < 0 || _cmbIdiomaEditor.SelectedIndex >= _idiomasEditor.Count)
            {
                return;
            }
            try
            {
                string codigo = _idiomasEditor[_cmbIdiomaEditor.SelectedIndex].Codigo;
                _textosEditor = LocalizationService.ObtenerTextosDe(codigo);
                _grillaTextos.Rows.Clear();
                foreach (TextoLocalizacion texto in _textosEditor)
                {
                    _grillaTextos.Rows.Add(texto.Clave, texto.Valor);
                }
                _grillaTextos.ClearSelection();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void GuardarCambiosTextos()
        {
            if (_cmbIdiomaEditor.SelectedIndex < 0 || _cmbIdiomaEditor.SelectedIndex >= _idiomasEditor.Count)
            {
                MessageBox.Show(FindForm(), Localizacion("idiomas.sinSeleccion"), Localizacion("sistema.idiomas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string codigo = _idiomasEditor[_cmbIdiomaEditor.SelectedIndex].Codigo;
                int guardados = 0;
                for (int i = 0; i < _grillaTextos.Rows.Count && i < _textosEditor.Count; i++)
                {
                    string clave = _grillaTextos.Rows[i].Cells[0].Value?.ToString() ?? string.Empty;
                    string valor = _grillaTextos.Rows[i].Cells[1].Value?.ToString() ?? string.Empty;
                    if (!string.Equals(valor, _textosEditor[i].Valor, StringComparison.Ordinal))
                    {
                        LocalizationService.GuardarTexto(codigo, clave, valor);
                        guardados++;
                    }
                }
                MessageBox.Show(FindForm(), Localizacion("idiomas.guardadoOk") + $" ({guardados})",
                    Localizacion("sistema.idiomas"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTextosDelIdioma();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void AgregarLeyendaInline()
        {
            if (_cmbIdiomaEditor.SelectedIndex < 0 || _cmbIdiomaEditor.SelectedIndex >= _idiomasEditor.Count)
            {
                MessageBox.Show(FindForm(), Localizacion("idiomas.sinSeleccion"), Localizacion("sistema.idiomas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string clave = _txtNuevaClave.Text.Trim();
            if (clave.Length == 0)
            {
                MessageBox.Show(FindForm(), Localizacion("idiomas.claveObligatoria"), Localizacion("sistema.idiomas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string codigo = _idiomasEditor[_cmbIdiomaEditor.SelectedIndex].Codigo;
                LocalizationService.GuardarTexto(codigo, clave, _txtNuevoValor.Text);
                _txtNuevaClave.Clear();
                _txtNuevoValor.Clear();
                CargarTextosDelIdioma();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void AbrirAltaIdioma()
        {
            using var formulario = new IdiomaNuevoForm();
            if (formulario.ShowDialog(FindForm()) == DialogResult.OK)
            {
                CargarIdiomas();
            }
        }

        private void EliminarIdiomaSeleccionado()
        {
            if (_grillaIdiomas.SelectedRows.Count == 0)
            {
                MessageBox.Show(FindForm(), Localizacion("idiomas.sinSeleccion"), Localizacion("sistema.idiomas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string codigo = _grillaIdiomas.SelectedRows[0].Cells[0].Value?.ToString() ?? string.Empty;
            if (MessageBox.Show(FindForm(), Localizacion("idiomas.confirmarEliminar") + $" ({codigo})",
                    Localizacion("sistema.idiomas"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                LocalizationService.EliminarIdioma(codigo);
                CargarIdiomas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(FindForm(), ex.Message, Localizacion("sistema.idiomas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ------------------------------------------------------------------ perfiles y permisos (T04)

        private void CargarPerfiles()
        {
            try
            {
                string? previo = _cmbPerfiles.SelectedItem?.ToString();
                _cmbPerfiles.Items.Clear();
                foreach (string perfil in SeguridadService.ObtenerPerfiles())
                {
                    _cmbPerfiles.Items.Add(perfil);
                }
                int indice = previo == null ? 0 : Math.Max(0, _cmbPerfiles.Items.IndexOf(previo));
                _cmbPerfiles.SelectedIndex = _cmbPerfiles.Items.Count > 0 ? indice : -1;
                CargarArbolDelPerfil();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void CargarArbolDelPerfil()
        {
            if (_cmbPerfiles.SelectedIndex < 0)
            {
                return;
            }
            try
            {
                string perfil = _cmbPerfiles.SelectedItem?.ToString() ?? string.Empty;
                _actualizandoArbol = true;
                try
                {
                    _treePermisos.BeginUpdate();
                    _treePermisos.Nodes.Clear();
                    PermisoCompuesto raiz = SeguridadService.ObtenerArbolPermisos();
                    LlenarArbol(_treePermisos.Nodes, raiz);
                    AplicarAsignaciones(_treePermisos.Nodes, SeguridadService.ObtenerPermisosDePerfil(perfil));
                    _treePermisos.ExpandAll();
                }
                finally
                {
                    _treePermisos.EndUpdate();
                    _actualizandoArbol = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        /// <summary>Llena el TreeView con el árbol de permisos (función recursiva, T04).</summary>
        private static void LlenarArbol(TreeNodeCollection destino, PermisoCompuesto raiz)
        {
            foreach (Permiso hijo in raiz.Hijos)
            {
                TreeNode nodo = destino.Add($"{hijo.Codigo} — {hijo.Nombre}");
                nodo.Tag = hijo.Codigo;
                if (hijo is PermisoCompuesto compuesto)
                {
                    LlenarArbol(nodo.Nodes, compuesto);
                }
            }
        }

        /// <summary>Aplica las asignaciones del perfil sobre el árbol (función recursiva, T04).</summary>
        private static void AplicarAsignaciones(TreeNodeCollection nodos, List<string> asignados)
        {
            foreach (TreeNode nodo in nodos)
            {
                nodo.Checked = nodo.Tag is string codigo && asignados.Contains(codigo);
                AplicarAsignaciones(nodo.Nodes, asignados);
            }
        }

        /// <summary>Propaga el estado marcado a todo el subárbol (función recursiva, T04).</summary>
        private static void PropagarASubarbol(TreeNode raiz, bool marcado)
        {
            foreach (TreeNode hijo in raiz.Nodes)
            {
                hijo.Checked = marcado;
                PropagarASubarbol(hijo, marcado);
            }
        }

        /// <summary>Recolecta los códigos marcados del árbol (función recursiva, T04).</summary>
        private static void RecolectarMarcados(TreeNodeCollection nodos, List<string> destino)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Checked && nodo.Tag is string codigo)
                {
                    destino.Add(codigo);
                }
                RecolectarMarcados(nodo.Nodes, destino);
            }
        }

        private void TreePermisos_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (_actualizandoArbol || e.Node == null)
            {
                return;
            }
            _actualizandoArbol = true;
            try
            {
                PropagarASubarbol(e.Node, e.Node.Checked);
            }
            finally
            {
                _actualizandoArbol = false;
            }
        }

        private void MarcarTodo(bool marcado)
        {
            _actualizandoArbol = true;
            try
            {
                foreach (TreeNode nodo in _treePermisos.Nodes)
                {
                    nodo.Checked = marcado;
                    PropagarASubarbol(nodo, marcado);
                }
            }
            finally
            {
                _actualizandoArbol = false;
            }
        }

        private void GuardarPermisosDelPerfil()
        {
            if (_cmbPerfiles.SelectedIndex < 0)
            {
                MessageBox.Show(FindForm(), Localizacion("perfiles.sinPerfil"), Localizacion("sistema.perfiles"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string perfil = _cmbPerfiles.SelectedItem?.ToString() ?? string.Empty;
                var codigos = new List<string>();
                RecolectarMarcados(_treePermisos.Nodes, codigos);
                SeguridadService.GuardarPermisosDePerfil(perfil, codigos);
                MessageBox.Show(FindForm(), Localizacion("perfiles.guardado"), Localizacion("sistema.perfiles"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }

        private void AbrirAltaUsuario()
        {
            using var formulario = new UsuarioNuevoForm();
            if (formulario.ShowDialog(FindForm()) == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void CambiarEstadoSeleccionado(bool activo)
        {
            if (_grillaUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show(FindForm(), Localizacion("sistema.selUsuario"), Localizacion("sistema.usuarios"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indice = _grillaUsuarios.SelectedRows[0].Index;
            if (indice < 0 || indice >= _usuarios.Count)
            {
                return;
            }
            UsuarioListado seleccionado = _usuarios[indice];

            string pregunta = Localizacion(activo ? "sistema.confirmarHabilitar" : "sistema.confirmarDeshabilitar");
            if (MessageBox.Show(FindForm(), $"{pregunta}{Environment.NewLine}({seleccionado.NombreUsuario})",
                    Localizacion("sistema.usuarios"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                SeguridadService.CambiarEstadoUsuario(seleccionado.NombreUsuario, activo, "Administración del sistema.");
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "SistemaControl");
            }
        }
    }
}
