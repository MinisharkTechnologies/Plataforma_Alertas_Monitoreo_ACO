using Services.BLL;
using Services.DomainModel;

namespace Services.Facade
{
    /// <summary>
    /// Fachada pública del módulo de seguridad (REQ-ARQ-006): autenticación centralizada,
    /// verificación de permisos y registro de usuarios.
    /// Consumida por el formulario de login del Negocio y por cualquier otro módulo
    /// que requiera validar credenciales o permisos.
    /// </summary>
    public static class SeguridadService
    {
        /// <summary>Autentica un usuario y, si las credenciales son válidas, devuelve la sesión iniciada.</summary>
        public static UsuarioAutenticado Autenticar(string usuario, string contrasena)
            => SeguridadLogic.Autenticar(usuario, contrasena);

        /// <summary>Indica si el usuario posee el permiso indicado (consulta roles y permisos).</summary>
        public static bool TienePermiso(int idUsuario, string permiso)
            => SeguridadLogic.TienePermiso(idUsuario, permiso);

        /// <summary>Registra un nuevo usuario con contraseña hasheada (PBKDF2 + sal). Devuelve el Id generado.</summary>
        public static int RegistrarUsuario(
            string nombreUsuario,
            string nombreCompleto,
            string contrasena,
            string perfil,
            string? email = null,
            string? preguntaSeguridad = null,
            string? respuestaSeguridad = null)
            => SeguridadLogic.RegistrarUsuario(nombreUsuario, nombreCompleto, contrasena, perfil, email, preguntaSeguridad, respuestaSeguridad);

        /// <summary>Indica si ya existe un usuario registrado con ese nombre.</summary>
        public static bool ExisteNombreUsuario(string nombreUsuario)
            => SeguridadLogic.ExisteNombreUsuario(nombreUsuario);

        /// <summary>Habilita o deshabilita las credenciales de un usuario (auditado en bitácora).</summary>
        public static void CambiarEstadoUsuario(string nombreUsuario, bool activo, string? motivo = null)
            => SeguridadLogic.CambiarEstadoUsuario(nombreUsuario, activo, motivo);
    }
}
