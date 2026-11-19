using Microsoft.EntityFrameworkCore;
using Negocio.DAL.Context;

using Negocio.DAL.Interfaces;

namespace Negocio.DAL.Implementaciones
{
    /// <summary>
    /// Implementación genérica de repositorio sobre EF Core: cada operación de escritura
    /// persiste de inmediato (SaveChanges). Los repositorios específicos heredan de esta
    /// clase y agregan consultas propias del dominio.
    /// </summary>
    internal class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        protected readonly NegocioDbContext Contexto;

        public RepositorioGenerico(NegocioDbContext contexto)
        {
            Contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public T? ObtenerPorId(int id)
        {
            try
            {
                return Contexto.Set<T>().Find(id);
            }
            catch (Negocio.DAL.Exceptions.AccesoADatosNegocioException)
            {
                throw;
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("RepositorioGenerico.ObtenerPorId", ex);
            }
        }

        public List<T> ObtenerTodos()
        {
            try
            {
                return Contexto.Set<T>().AsNoTracking().ToList();
            }
            catch (Negocio.DAL.Exceptions.AccesoADatosNegocioException)
            {
                throw;
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("RepositorioGenerico.ObtenerTodos", ex);
            }
        }

        public void Agregar(T entidad)
        {
            try
            {
                Contexto.Set<T>().Add(entidad);
                Contexto.SaveChanges();
            }
            catch (Negocio.DAL.Exceptions.AccesoADatosNegocioException)
            {
                throw;
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("RepositorioGenerico.Agregar", ex);
            }
        }

        public void Modificar(T entidad)
        {
            try
            {
                Contexto.Set<T>().Update(entidad);
                Contexto.SaveChanges();
            }
            catch (Negocio.DAL.Exceptions.AccesoADatosNegocioException)
            {
                throw;
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("RepositorioGenerico.Modificar", ex);
            }
        }

        public void Eliminar(T entidad)
        {
            try
            {
                Contexto.Set<T>().Remove(entidad);
                Contexto.SaveChanges();
            }
            catch (Negocio.DAL.Exceptions.AccesoADatosNegocioException)
            {
                throw;
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("RepositorioGenerico.Eliminar", ex);
            }
        }

        public bool Existe(int id)
        {
            try
            {
                return Contexto.Set<T>().Find(id) != null;
            }
            catch (Negocio.DAL.Exceptions.AccesoADatosNegocioException)
            {
                throw;
            }
            catch (Services.DomainModel.Exceptions.ReglaNegocioException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("RepositorioGenerico.Existe", ex);
            }
        }
    }
}
