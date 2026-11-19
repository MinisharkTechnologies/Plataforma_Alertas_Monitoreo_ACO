using System;
using Services.DomainModel.Exceptions;

namespace Negocio.BLL.Exceptions
{
    /// <summary>
    /// Base de las excepciones de reglas de negocio de la capa BLL de Negocio.
    /// Deriva de <see cref="ReglaNegocioException"/> (la raíz de excepciones controladas del
    /// sistema) y agrega el código estable propio de cada regla.
    /// Todas las excepciones de esta carpeta siguen el mismo criterio: una clase por archivo,
    /// mensaje pensado para el usuario y código para la bitácora.
    /// </summary>
    public abstract class NegocioBusinessException : ReglaNegocioException
    {
        protected NegocioBusinessException(string mensaje, string codigo, Exception? innerException = null)
            : base(mensaje, innerException, codigo)
        {
        }
    }
}