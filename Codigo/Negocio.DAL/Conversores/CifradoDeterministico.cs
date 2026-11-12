using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.Facade;

namespace Negocio.DAL.Conversores
{
    /// <summary>
    /// Conversor de almacenamiento con cifrado AES-256 determinístico: la columna guarda
    /// ciphertext ("AES1$" + Base64) y el dominio sigue viendo plaintext. El IV se deriva
    /// del contexto (entidad:propiedad) con HMAC, por lo que el mismo plaintext siempre da el
    /// mismo ciphertext y las firmas DVH — calculadas sobre plaintext — se mantienen estables
    /// (REQ-ARQ-002 + Cátedra: un campo cifrado simétrico).
    /// Descripción del formato en <c>CryptographyLogic.EncriptarDeterminista</c>.
    /// </summary>
    public static class CifradoDeterministico
    {
        /// <summary>Instancia de conversor para un campo dado. Los valores legacy sin prefijo
        /// "AES1$" se leen tal cual y se re-cifran en el próximo guardado.</summary>
        public static ValueConverter<string, string> Para(string contexto)
            => new ValueConverter<string, string>(
                v => CryptographyService.EncriptarDeterminista(contexto, v),
                v => CryptographyService.DesencriptarDeterminista(contexto, v));

        /// <summary>Variante para propiedades nulables: el null pasa intacto (no se cifra).</summary>
        public static ValueConverter<string?, string?> ParaNulable(string contexto)
            => new ValueConverter<string?, string?>(
                v => v == null ? null : CryptographyService.EncriptarDeterminista(contexto, v),
                v => v == null ? null : CryptographyService.DesencriptarDeterminista(contexto, v));
    }
}
