using System;
using Services.BLL.Infrastructure;
using Services.DAL.Implementations;
using Services.DAL.Interfaces;
using Services.DomainModel;
using Services.DomainModel.Exceptions;

namespace Services.BLL
{
    /// <summary>
    /// Lógica de seguridad (REQ-ARQ-006): autenticación centralizada, autorización por permisos
    /// y política anti fuerza bruta (5 intentos fallidos consecutivos → bloqueo de 15 minutos).
    /// Auditoría completa en bitácora de accesos exitosos y fallidos.
    /// </summary>
    internal static class SeguridadLogic
    {
        private const int MaxIntentosFallidos = 5; // REQ-ARQ-006
        private const int MinutosBloqueo = 15;     // REQ-ARQ-006
        private const int LargoMinimoContrasena = 8;

        private static readonly IUsuarioRepository RepositorioUsuarios = new SqlUsuarioRepository();

        public static UsuarioAutenticado Autenticar(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                throw new CredencialesInvalidasException("Usuario o contraseña incorrectos.");
            }

            Usuario? usuario = RepositorioUsuarios.ObtenerPorNombreUsuario(nombreUsuario.Trim());

            if (usuario == null)
            {
                BitacoraLogic.Registrar(LogLevel.Warning,
                    $"Inicio de sesión fallido: usuario inexistente '{nombreUsuario}'.",
                    capa: "Seguridad");
                throw new CredencialesInvalidasException("Usuario o contraseña incorrectos.");
            }

            if (usuario.BloqueadoHasta.HasValue && usuario.BloqueadoHasta.Value > DateTime.Now)
            {
                int minutos = (int)Math.Ceiling((usuario.BloqueadoHasta.Value - DateTime.Now).TotalMinutes);
                BitacoraLogic.Registrar(LogLevel.Warning,
                    $"Intento de acceso a cuenta bloqueada '{usuario.NombreUsuario}' (restan {minutos} min).",
                    usuario: usuario.NombreUsuario, capa: "Seguridad");
                throw new UsuarioBloqueadoException(
                    $"La cuenta está bloqueada temporalmente por seguridad. Intente nuevamente en {minutos} minuto(s).");
            }

            if (!usuario.Activo)
            {
                BitacoraLogic.Registrar(LogLevel.Warning,
                    $"Intento de acceso con usuario deshabilitado '{usuario.NombreUsuario}'.",
                    usuario: usuario.NombreUsuario, capa: "Seguridad");
                throw new CredencialesInvalidasException("El usuario no está habilitado. Contacte al administrador.");
            }

            if (!CryptographyLogic.VerificarHash(contrasena, usuario.HashPassword))
            {
                RegistrarFallo(usuario);
                throw new CredencialesInvalidasException("Usuario o contraseña incorrectos.");
            }

            // Éxito: se resetea el contador y se libera cualquier bloqueo vencido.
            if (usuario.IntentosFallidos != 0 || usuario.BloqueadoHasta.HasValue)
            {
                RepositorioUsuarios.ActualizarAcceso(usuario.Id, 0, null);
            }

            BitacoraLogic.Registrar(LogLevel.Info,
                $"Inicio de sesión exitoso de '{usuario.NombreUsuario}' (perfil {usuario.Perfil}).",
                usuario: usuario.NombreUsuario, capa: "Seguridad");

            return new UsuarioAutenticado
            {
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Perfil = usuario.Perfil
            };
        }

        public static bool TienePermiso(int idUsuario, string permiso)
        {
            if (string.IsNullOrWhiteSpace(permiso))
            {
                return false;
            }

            Usuario? usuario = RepositorioUsuarios.ObtenerPorId(idUsuario);
            if (usuario == null || !usuario.Activo)
            {
                return false;
            }

            // El administrador del sistema posee acceso total (criterio de diseño, REQ-ARQ-006).
            if (string.Equals(usuario.Perfil, "sysadmin", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return RepositorioUsuarios.PerfilTienePermiso(usuario.Perfil, permiso);
        }

        public static int RegistrarUsuario(
            string nombreUsuario,
            string nombreCompleto,
            string contrasena,
            string perfil,
            string? email = null,
            string? preguntaSeguridad = null,
            string? respuestaSeguridad = null)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                throw new ArgumentException("El nombre completo es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(perfil))
            {
                throw new ArgumentException("El perfil es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(contrasena) || contrasena.Length < LargoMinimoContrasena)
            {
                throw new ArgumentException($"La contraseña debe tener al menos {LargoMinimoContrasena} caracteres.");
            }
            if (RepositorioUsuarios.ExisteNombreUsuario(nombreUsuario.Trim()))
            {
                throw new ArgumentException($"Ya existe un usuario con el nombre '{nombreUsuario}'.");
            }

            Usuario usuario = new Usuario
            {
                NombreUsuario = nombreUsuario.Trim(),
                NombreCompleto = nombreCompleto.Trim(),
                HashPassword = CryptographyLogic.Hashear(contrasena),
                Perfil = perfil.Trim(),
                Email = email,
                PreguntaSeguridad = preguntaSeguridad,
                RespuestaHash = string.IsNullOrWhiteSpace(respuestaSeguridad)
                    ? null
                    : CryptographyLogic.Hashear(respuestaSeguridad),
                Activo = true,
                IntentosFallidos = 0
            };

            int id = RepositorioUsuarios.Registrar(usuario);
            BitacoraLogic.Registrar(LogLevel.Info,
                $"Usuario registrado '{usuario.NombreUsuario}' (perfil {usuario.Perfil}).",
                capa: "Seguridad");
            return id;
        }

        private static void RegistrarFallo(Usuario usuario)
        {
            int intentos = usuario.IntentosFallidos + 1;
            DateTime? bloqueo = null;

            if (intentos >= MaxIntentosFallidos)
            {
                bloqueo = DateTime.Now.AddMinutes(MinutosBloqueo);
                intentos = 0; // el bloqueo temporal reemplaza al contador
                BitacoraLogic.Registrar(LogLevel.Warning,
                    $"Cuenta '{usuario.NombreUsuario}' BLOQUEADA por {MinutosBloqueo} minutos tras {MaxIntentosFallidos} intentos fallidos.",
                    usuario: usuario.NombreUsuario, capa: "Seguridad");
            }
            else
            {
                BitacoraLogic.Registrar(LogLevel.Warning,
                    $"Inicio de sesión fallido de '{usuario.NombreUsuario}' (intento {intentos}/{MaxIntentosFallidos}).",
                    usuario: usuario.NombreUsuario, capa: "Seguridad");
            }

            RepositorioUsuarios.ActualizarAcceso(usuario.Id, intentos, bloqueo);
        }
    }
}
