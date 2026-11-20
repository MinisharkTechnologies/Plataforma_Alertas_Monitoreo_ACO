using System;
using Services.DomainModel.Validacion;

namespace Services.DomainModel
{
    /// <summary>
    /// Usuario del sistema: única clase de usuario del dominio. La base Services guarda sus
    /// credenciales y su estado de acceso (política anti fuerza bruta, REQ-ARQ-006) y el idioma
    /// preferido (REQ-ARQ-001); la base OpenRIN_Negocio usa la misma clase como identidad de
    /// negocio, enlazada por NombreUsuario (teléfono y fecha de alta son columnas de la tabla
    /// Usuarios de Negocio).
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }

        /// <summary>Nombre de usuario (igual al registrado en el módulo de seguridad).</summary>
        [Requerido]
        [Unico]
        public string NombreUsuario { get; set; } = string.Empty;

        [Requerido]
        public string NombreCompleto { get; set; } = string.Empty;

        /// <summary>Hash de la contraseña (formato "sal.iteraciones.hash", PBKDF2-SHA256). Nunca se almacena texto plano.</summary>
        public string HashPassword { get; set; } = string.Empty;

        /// <summary>Perfil de acceso: administrativo, medico, paciente, familiar o sysadmin.</summary>
        [Requerido]
        public string Perfil { get; set; } = string.Empty;

        public string? Email { get; set; }

        /// <summary>Teléfono de contacto de la persona (columna de la tabla Usuarios de Negocio).</summary>
        public string? Telefono { get; set; }

        /// <summary>Pregunta de seguridad para la recuperación de contraseña.</summary>
        public string? PreguntaSeguridad { get; set; }

        /// <summary>Hash de la respuesta de seguridad (mismo formato que HashPassword).</summary>
        public string? RespuestaHash { get; set; }

        /// <summary>Idioma preferido del usuario (código de cultura, ej. "es", "en", "zh-CN").</summary>
        public string? Idioma { get; set; }

        public bool Activo { get; set; } = true;

        /// <summary>Intentos fallidos consecutivos desde el último acceso exitoso.</summary>
        public int IntentosFallidos { get; set; }

        /// <summary>Si tiene valor futuro, la cuenta está bloqueada temporalmente hasta esa fecha.</summary>
        public DateTime? BloqueadoHasta { get; set; }

        /// <summary>Fecha de alta de la identidad de negocio (columna de la tabla Usuarios de Negocio).</summary>
        public DateTime FechaAlta { get; set; } = DateTime.Now;
    }
}
