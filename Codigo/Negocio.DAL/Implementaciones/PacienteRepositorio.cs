using Microsoft.EntityFrameworkCore;
using Negocio.DAL.Context;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;

using Negocio.DAL.Interfaces;

namespace Negocio.DAL.Implementaciones
{
    /// <summary>
    /// Repositorio de pacientes sobre EF Core (REQ-FUNC-001): altas, búsquedas por
    /// documento y verificación de unicidad entre pacientes activos.
    /// </summary>
    internal class PacienteRepositorio : RepositorioGenerico<Paciente>, IPacienteRepositorio
    {
        public PacienteRepositorio(NegocioDbContext contexto) : base(contexto)
        {
        }

        public List<Paciente> BuscarActivos()
        {
            try
            {
                return Contexto.Pacientes.AsNoTracking()
                    .Where(p => p.Estado == EstadoPaciente.Activo)
                    .OrderBy(p => p.NombreCompleto)
                    .ToList();
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
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("PacienteRepositorio.BuscarActivos", ex);
            }
        }

        public Paciente? BuscarPorDNI(string dni)
        {
            try
            {
                return Contexto.Pacientes.FirstOrDefault(p => p.DNI == dni);
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
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("PacienteRepositorio.BuscarPorDNI", ex);
            }
        }

        public bool ExisteDNIActivo(string dni, int? idExcluir = null)
        {
            try
            {
                return Contexto.Pacientes.Any(p =>
                    p.DNI == dni &&
                    p.Estado == EstadoPaciente.Activo &&
                    (idExcluir == null || p.Id != idExcluir));
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
                throw new Negocio.DAL.Exceptions.AccesoADatosNegocioException("PacienteRepositorio.ExisteDNIActivo", ex);
            }
        }
    }
}
