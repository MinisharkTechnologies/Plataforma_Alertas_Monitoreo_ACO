using Services.DomainModel;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Administración del sistema (REQ-ARQ-004/006, solo perfil sysadmin): gestión de usuarios
    /// (listado, alta vía la API de seguridad, habilitación/deshabilitación) y consulta de la
    /// bitácora centralizada con filtro por nivel mínimo.
    /// </summary>
    public class SistemaControl : UserControl
    {
        private readonly Button _btnVistaUsuarios = new();
        private readonly Button _btnVistaBitacora = new();

        private readonly Panel _panelUsuarios = new();
        private readonly Button _btnNuevoUsuario = new();
        private readonly Button _btnHabilitar = new();
        private readonly Button _btnDeshabilitar = new();
        private readonly DataGridView _grillaUsuarios = new();

        private readonly Panel _panelBitacora = new();
        private readonly Label _lblNivel = new();
        private readonly ComboBox _cmbNivel = new();
        private readonly Button _btnActualizar = new();
        private readonly DataGridView _grillaBitacora = new();

        private int _vistaActual;
        private List<UsuarioListado> _usuarios = new();

        public SistemaControl()
        {
            ConstruirInterfaz();
            AplicarTextos();
            MostrarVista(0);
            CargarUsuarios();
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Recarga la vista activa (al entrar al módulo).</summary>
        public void Recargar()
        {
            if (_vistaActual == 0)
            {
                CargarUsuarios();
            }
            else
            {
                CargarBitacora();
            }
        }

        /// <summary>Reaplica textos por cambio de idioma y recarga.</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            Recargar();
        }

        private void ConstruirInterfaz()
        {
            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(244, 249, 254);
            Padding = new Padding(8, 4, 8, 6);

            // ---- Barra superior: vistas ----
            var panelBarra = new Panel { Dock = DockStyle.Top, Height = 58, BackColor = BackColor };
            ConfigurarBotonVista(_btnVistaUsuarios, 0);
            ConfigurarBotonVista(_btnVistaBitacora, 176);
            panelBarra.Controls.Add(_btnVistaUsuarios);
            panelBarra.Controls.Add(_btnVistaBitacora);

            // ---- Vista 1: usuarios ----
            _panelUsuarios.Dock = DockStyle.Fill;
            _panelUsuarios.BackColor = Color.White;

            _btnNuevoUsuario.Location = new Point(14, 12);
            _btnNuevoUsuario.Size = new Size(180, 32);
            EstiloPrimario(_btnNuevoUsuario);
            _btnNuevoUsuario.Click += (s, e) => AbrirAltaUsuario();

            _btnHabilitar.Location = new Point(204, 12);
            _btnHabilitar.Size = new Size(140, 32);
            EstiloSecundario(_btnHabilitar);
            _btnHabilitar.Click += (s, e) => CambiarEstadoSeleccionado(true);

            _btnDeshabilitar.Location = new Point(354, 12);
            _btnDeshabilitar.Size = new Size(150, 32);
            EstiloSecundario(_btnDeshabilitar);
            _btnDeshabilitar.Click += (s, e) => CambiarEstadoSeleccionado(false);

            var hostUsuarios = new Panel { Dock = DockStyle.Fill, Padding = new Padding(14, 56, 14, 14) };
            _grillaUsuarios.Dock = DockStyle.Fill;
            EstiloGrilla(_grillaUsuarios);
            _grillaUsuarios.Columns.Add("usuario", "");
            _grillaUsuarios.Columns.Add("nombre", "");
            _grillaUsuarios.Columns.Add("perfil", "");
            _grillaUsuarios.Columns.Add("email", "");
            _grillaUsuarios.Columns.Add("activo", "");
            _grillaUsuarios.Columns.Add("intentos", "");
            _grillaUsuarios.Columns.Add("bloqueado", "");
            _grillaUsuarios.Columns["usuario"].FillWeight = 16;
            _grillaUsuarios.Columns["nombre"].FillWeight = 24;
            _grillaUsuarios.Columns["perfil"].FillWeight = 14;
            _grillaUsuarios.Columns["email"].FillWeight = 18;
            _grillaUsuarios.Columns["activo"].FillWeight = 8;
            _grillaUsuarios.Columns["intentos"].FillWeight = 8;
            _grillaUsuarios.Columns["bloqueado"].FillWeight = 12;
            foreach (string columna in new[] { "perfil", "activo", "intentos", "bloqueado" })
            {
                _grillaUsuarios.Columns[columna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            _panelUsuarios.Controls.Add(hostUsuarios);
            hostUsuarios.Controls.Add(_grillaUsuarios);
            _panelUsuarios.Controls.Add(_btnNuevoUsuario);
            _panelUsuarios.Controls.Add(_btnHabilitar);
            _panelUsuarios.Controls.Add(_btnDeshabilitar);
            _btnNuevoUsuario.BringToFront();
            _btnHabilitar.BringToFront();
            _btnDeshabilitar.BringToFront();

            // ---- Vista 2: bitácora ----
            _panelBitacora.Dock = DockStyle.Fill;
            _panelBitacora.BackColor = Color.White;

            _lblNivel.Location = new Point(14, 20);
            _lblNivel.Size = new Size(110, 20);
            _lblNivel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblNivel.ForeColor = Color.FromArgb(60, 85, 115);

            _cmbNivel.Location = new Point(128, 16);
            _cmbNivel.Size = new Size(160, 28);
            _cmbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbNivel.Font = new Font("Segoe UI", 9.5F);

            _btnActualizar.Location = new Point(300, 15);
            _btnActualizar.Size = new Size(140, 30);
            EstiloSecundario(_btnActualizar);
            _btnActualizar.Click += (s, e) => CargarBitacora();

            var hostBitacora = new Panel { Dock = DockStyle.Fill, Padding = new Padding(14, 56, 14, 14) };
            _grillaBitacora.Dock = DockStyle.Fill;
            EstiloGrilla(_grillaBitacora);
            _grillaBitacora.Columns.Add("fecha", "");
            _grillaBitacora.Columns.Add("nivel", "");
            _grillaBitacora.Columns.Add("capa", "");
            _grillaBitacora.Columns.Add("usuario", "");
            _grillaBitacora.Columns.Add("mensaje", "");
            _grillaBitacora.Columns["fecha"].FillWeight = 14;
            _grillaBitacora.Columns["nivel"].FillWeight = 9;
            _grillaBitacora.Columns["capa"].FillWeight = 12;
            _grillaBitacora.Columns["usuario"].FillWeight = 14;
            _grillaBitacora.Columns["mensaje"].FillWeight = 51;
            foreach (string columna in new[] { "nivel", "capa" })
            {
                _grillaBitacora.Columns[columna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            _panelBitacora.Controls.Add(hostBitacora);
            hostBitacora.Controls.Add(_grillaBitacora);
            _panelBitacora.Controls.Add(_lblNivel);
            _panelBitacora.Controls.Add(_cmbNivel);
            _panelBitacora.Controls.Add(_btnActualizar);
            _lblNivel.BringToFront();
            _cmbNivel.BringToFront();
            _btnActualizar.BringToFront();

            Controls.Add(_panelUsuarios);
            Controls.Add(_panelBitacora);
            Controls.Add(panelBarra);
        }

        private static void EstiloPrimario(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.BackColor = Color.FromArgb(45, 108, 223);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
        }

        private static void EstiloSecundario(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.BackColor = Color.White;
            boton.ForeColor = Color.FromArgb(28, 60, 105);
            boton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            boton.FlatAppearance.BorderColor = Color.FromArgb(202, 220, 240);
            boton.Cursor = Cursors.Hand;
        }

        private static void EstiloGrilla(DataGridView grilla)
        {
            grilla.ReadOnly = true;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.AllowUserToResizeRows = false;
            grilla.RowHeadersVisible = false;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.MultiSelect = false;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grilla.BackgroundColor = Color.White;
            grilla.BorderStyle = BorderStyle.None;
            grilla.GridColor = Color.FromArgb(225, 235, 245);
            grilla.EnableHeadersVisualStyles = false;
            grilla.ColumnHeadersHeight = 34;
            grilla.RowTemplate.Height = 30;
            grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 98, 176);
            grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grilla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 98, 176);
            grilla.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            grilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 250);
            grilla.DefaultCellStyle.SelectionForeColor = Color.Black;
            grilla.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 251, 255);
        }

        private void ConfigurarBotonVista(Button boton, int x)
        {
            boton.Location = new Point(x, 15);
            boton.Size = new Size(168, 32);
            boton.FlatStyle = FlatStyle.Flat;
            boton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;
            boton.FlatAppearance.BorderColor = Color.FromArgb(202, 220, 240);
            boton.Click += (s, e) => MostrarVista(boton == _btnVistaUsuarios ? 0 : 1);
        }

        private void MostrarVista(int vista)
        {
            _vistaActual = vista;
            _panelUsuarios.Visible = vista == 0;
            _panelBitacora.Visible = vista == 1;
            EstiloBotonVista(_btnVistaUsuarios, vista == 0);
            EstiloBotonVista(_btnVistaBitacora, vista == 1);
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
