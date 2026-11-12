using Services.BLL.Infrastructure;

namespace Services.Facade
{
    /// <summary>
    /// Fachada pública del módulo de criptografía (REQ-ARQ-002).
    /// Punto de entrada único para cifrado, hashing y verificación de contraseñas.
    /// </summary>
    public static class CryptographyService
    {
        /// <summary>Encripta un texto plano con AES-256. Devuelve el texto cifrado en Base64.</summary>
        public static string Encriptar(string textoPlano) => CryptographyLogic.Encriptar(textoPlano);

        /// <summary>Desencripta un texto cifrado previamente con <see cref="Encriptar"/>.</summary>
        public static string Desencriptar(string textoCifrado) => CryptographyLogic.Desencriptar(textoCifrado);

        /// <summary>Encripta con AES-256 determinístico (mismo contexto + plaintext ⇒ mismo
        /// ciphertext). Para campos con DVH: la firma es estable.
        /// <param name="contexto">Identificador estable del campo (entidad:propiedad).</param></summary>
        public static string EncriptarDeterminista(string contexto, string textoPlano)
            => CryptographyLogic.EncriptarDeterminista(contexto, textoPlano);

        /// <summary>Desencripta un texto cifrado con <see cref="EncriptarDeterminista"/>; sin el
        /// marcador AES1$ devuelve el valor tal cual (legacy).</summary>
        public static string DesencriptarDeterminista(string contexto, string textoCifrado)
            => CryptographyLogic.DesencriptarDeterminista(contexto, textoCifrado);

        /// <summary>Hashea un texto (PBKDF2-SHA256 + sal). Irreversible: uso principal en contraseñas.</summary>
        public static string Hashear(string texto) => CryptographyLogic.Hashear(texto);

        /// <summary>Compara un texto plano contra un hash almacenado.</summary>
        public static bool VerificarHash(string texto, string hashAlmacenado) => CryptographyLogic.VerificarHash(texto, hashAlmacenado);
    }
}
