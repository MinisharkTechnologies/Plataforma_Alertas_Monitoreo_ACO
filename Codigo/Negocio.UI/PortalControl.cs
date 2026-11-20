using Microsoft.EntityFrameworkCore;
using Negocio.BLL;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Usuario = Services.DomainModel.Usuario;
using Negocio.DomainModel.Enums;
using Negocio.DomainModel.Exceptions;
using Services.Facade;

namespace Negocio.UI
{
    /// <summary>
    /// Portal del paciente: vista para la persona anticoagulada autenticada (REQ-FUNC-005/013):
    /// reporta su propio RIN por el canal digital y consulta su historial clínico unificado.
    /// El vínculo sesión → paciente se resuelve por Paciente.IdUsuarioPortal.
    /// </summary>
    public partial class PortalControl : UserControl
    {
        private readonly int _idUsuario;
        private readonly string _nombreUsuario = string.Empty;

        // Los controles que se ven en pantalla se declaran en PortalControl.Designer.cs
        // (patrón estándar de Visual Studio) para que el diseñador pueda dibujarlos.
        private Paciente? _paciente;

        /// <summary>Constructor para el diseñador de Visual Studio (no se usa en ejecución).</summary>
        public PortalControl()
        {
            InitializeComponent();
        }

        public PortalControl(int idUsuario, string nombreUsuario) : this()
        {
            // En tiempo de diseño (diseñador de Visual Studio) no se tocan servicios ni la base de datos:
            // alcanza con que los controles se hayan creado para que el control se dibuje.
            if (Disenio.Activo)
            {
                return;
            }

            _idUsuario = idUsuario;
            _nombreUsuario = nombreUsuario;

            AplicarTextos();
            Recargar();
        }

        private static string Localizacion(string clave) => LocalizationService.ObtenerTexto(clave);

        /// <summary>Resuelve el paciente vinculado a la sesión y recarga la vista.</summary>
        public void Recargar()
        {
            ResolverPaciente();
            if (_paciente != null)
            {
                CargarHistorial();
            }
        }

        /// <summary>Reaplica textos por cambio de idioma y recarga.</summary>
        public void RefrescarTextos()
        {
            AplicarTextos();
            Recargar();
        }

        // Manejadores de eventos de la interfaz (se conectan desde PortalControl.Designer.cs).

        private void BtnEnviar_Click(object? sender, EventArgs e) => EnviarReporte();

        private void AplicarTextos()
        {
            _lblReportar.Text = Localizacion("portal.reportar");
            _lblValor.Text = Localizacion("rin.valor");
            _lblFecha.Text = Localizacion("rin.fecha");
            _lblCanal.Text = Localizacion("rin.canal");
            _lblCanalValor.Text = Localizacion("rin.canal.digital");
            _btnEnviar.Text = Localizacion("portal.enviar");
            _lblHistorial.Text = Localizacion("portal.historial");
            _grillaHistorial.Columns["fecha"].HeaderText = Localizacion("rin.columna.fecha");
            _grillaHistorial.Columns["tipo"].HeaderText = Localizacion("reportes.columna.tipo");
            _grillaHistorial.Columns["descripcion"].HeaderText = Localizacion("reportes.columna.descripcion");

            _lblBienvenida.Text = _paciente != null
                ? $"{Localizacion("portal.bienvenida")} {_paciente.NombreCompleto}"
                : Localizacion("portal.sinVinculo");
        }

        private void ResolverPaciente()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                Usuario? usuarioNegocio = contexto.Usuarios.AsNoTracking()
                    .FirstOrDefault(u => u.NombreUsuario == _nombreUsuario);
                _paciente = usuarioNegocio == null
                    ? null
                    : contexto.Pacientes.AsNoTracking().FirstOrDefault(p => p.IdUsuarioPortal == usuarioNegocio.Id);

                if (_paciente != null)
                {
                    _lblBienvenida.Text = $"{Localizacion("portal.bienvenida")} {_paciente.NombreCompleto}";
                }

                bool puedeReportar = SeguridadService.TienePermiso(_idUsuario, "PORTAL_REPORTAR_RIN");
                bool puedeVer = SeguridadService.TienePermiso(_idUsuario, "PORTAL_VER_HISTORIAL");
                _panelReporte.Visible = puedeReportar;
                _panelHistorial.Visible = puedeVer;

                if (_paciente == null)
                {
                    _lblBienvenida.Text = Localizacion("portal.sinVinculo");
                    _panelReporte.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "PortalControl", mostrarMensaje: false);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                using var contexto = new NegocioDbContext();
                List<ItemHistorial> items = new ReporteLogic(contexto).ObtenerHistorialPaciente(_paciente!.Id);
                _grillaHistorial.Rows.Clear();
                foreach (ItemHistorial item in items)
                {
                    _grillaHistorial.Rows.Add(item.Fecha.ToString("dd/MM/yyyy"), item.Tipo, item.Descripcion);
                }
                _grillaHistorial.ClearSelection();
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "PortalControl", mostrarMensaje: false);
            }
        }

        private void EnviarReporte()
        {
            if (_paciente == null)
            {
                return;
            }

            try
            {
                using var contexto = new NegocioDbContext();
                var medicion = new MedicionRIN
                {
                    IdPaciente = _paciente.Id,
                    ValorRIN = _numValor.Value,
                    FechaMedicion = _dtpFecha.Value.Date,
                    Canal = CanalReporteRIN.Digital
                };

                ResultadoReporteRIN resultado = new MedicionRINLogic(contexto).Reportar(medicion, _nombreUsuario);

                _lblEstado.ForeColor = Color.FromArgb(30, 130, 75);
                _lblEstado.Text = Localizacion("portal.gracias") +
                    (resultado.AlertaGenerada != null ? $"  {Localizacion("portal.notificado")}" : string.Empty);
                CargarHistorial();
            }
            catch (ValidacionNegocioException ex)
            {
                _lblEstado.ForeColor = Color.FromArgb(180, 40, 40);
                _lblEstado.Text = string.Join(Environment.NewLine, ex.Errores);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManejarExcepcion(ex, "PortalControl");
            }
        }
    }
}
