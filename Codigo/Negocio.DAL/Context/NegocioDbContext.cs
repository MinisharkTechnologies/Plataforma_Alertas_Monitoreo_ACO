using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;

namespace Negocio.DAL.Context
{
    /// <summary>
    /// Contexto de Entity Framework Core del módulo Negocio: mapea las 11 entidades del
    /// dominio sobre la base OpenRIN_Negocio, con índices de unicidad (incluido el filtrado
    /// de DNI entre pacientes activos), conversiones de enums a texto y datos semilla
    /// de catálogos (obras sociales y diagnósticos).
    /// </summary>
    public class NegocioDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<ObraSocial> ObrasSociales => Set<ObraSocial>();
        public DbSet<Diagnostico> Diagnosticos => Set<Diagnostico>();
        public DbSet<HistoriaClinica> HistoriasClinicas => Set<HistoriaClinica>();
        public DbSet<EventoAdverso> EventosAdversos => Set<EventoAdverso>();
        public DbSet<MedicionRIN> MedicionesRIN => Set<MedicionRIN>();
        public DbSet<Alerta> Alertas => Set<Alerta>();
        public DbSet<Turno> Turnos => Set<Turno>();
        public DbSet<Seguimiento> Seguimientos => Set<Seguimiento>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<ReporteEstadistico> ReportesEstadisticos => Set<ReporteEstadistico>();

        public NegocioDbContext()
        {
        }

        public NegocioDbContext(DbContextOptions<NegocioDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? cadena = ConfigurationManager.ConnectionStrings["NegocioDB"]?.ConnectionString;
                if (string.IsNullOrWhiteSpace(cadena))
                {
                    throw new InvalidOperationException(
                        "Falta la cadena de conexión 'NegocioDB' en la configuración de la aplicación.");
                }
                optionsBuilder.UseSqlServer(cadena);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------- ObraSocial ----------
            modelBuilder.Entity<ObraSocial>(entidad =>
            {
                entidad.ToTable("ObrasSociales");
                entidad.Property(o => o.Nombre).HasMaxLength(150).IsRequired();
                entidad.HasIndex(o => o.Nombre).IsUnique();
            });

            // ---------- Diagnostico ----------
            modelBuilder.Entity<Diagnostico>(entidad =>
            {
                entidad.ToTable("Diagnosticos");
                entidad.Property(d => d.Nombre).HasMaxLength(200).IsRequired();
                entidad.Property(d => d.Descripcion).HasMaxLength(1000);
                entidad.HasIndex(d => d.Nombre).IsUnique();
            });

            // ---------- Usuario ----------
            modelBuilder.Entity<Usuario>(entidad =>
            {
                entidad.ToTable("Usuarios");
                entidad.Property(u => u.NombreUsuario).HasMaxLength(50).IsRequired();
                entidad.HasIndex(u => u.NombreUsuario).IsUnique();
                entidad.Property(u => u.NombreCompleto).HasMaxLength(300).IsRequired();
                entidad.Property(u => u.Perfil).HasMaxLength(30).IsRequired();
                entidad.Property(u => u.Email).HasMaxLength(400);
                entidad.Property(u => u.Telefono).HasMaxLength(50);
            });

            // ---------- Paciente ----------
            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Pacientes");
                entidad.Property(p => p.NombreCompleto).HasMaxLength(300).IsRequired();
                entidad.Property(p => p.DNI).HasMaxLength(20).IsRequired();
                entidad.Property(p => p.Telefono).HasMaxLength(50).IsRequired();
                entidad.Property(p => p.Email).HasMaxLength(400).IsRequired();
                entidad.Property(p => p.NumeroAfiliado).HasMaxLength(50);
                entidad.Property(p => p.MotivoBaja).HasMaxLength(500);
                entidad.Property(p => p.Estado).HasConversion<string>().HasMaxLength(20).IsRequired();

                // Unicidad del documento SOLO entre pacientes activos: la baja lógica libera el DNI.
                entidad.HasIndex(p => p.DNI).IsUnique().HasFilter("[Estado] = N'Activo'");

                entidad.HasOne(p => p.ObraSocial).WithMany().HasForeignKey(p => p.IdObraSocial)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- HistoriaClinica ----------
            modelBuilder.Entity<HistoriaClinica>(entidad =>
            {
                entidad.ToTable("HistoriasClinicas");
                entidad.Property(h => h.LimiteInferiorRIN).HasPrecision(5, 2);
                entidad.Property(h => h.LimiteSuperiorRIN).HasPrecision(5, 2);
                entidad.Property(h => h.Medicamento).HasMaxLength(200).IsRequired();
                entidad.Property(h => h.Dosis).HasMaxLength(200).IsRequired();

                // Una única historia clínica por paciente.
                entidad.HasIndex(h => h.IdPaciente).IsUnique();

                entidad.HasOne(h => h.Paciente).WithMany().HasForeignKey(h => h.IdPaciente)
                    .OnDelete(DeleteBehavior.Restrict);
                entidad.HasOne(h => h.Diagnostico).WithMany().HasForeignKey(h => h.IdDiagnostico)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- EventoAdverso ----------
            modelBuilder.Entity<EventoAdverso>(entidad =>
            {
                entidad.ToTable("EventosAdversos");
                entidad.Property(e => e.Tipo).HasConversion<string>().HasMaxLength(30);
                entidad.Property(e => e.Gravedad).HasConversion<string>().HasMaxLength(30);
                entidad.Property(e => e.Descripcion).IsRequired();
                entidad.Property(e => e.AccionTomada).IsRequired();

                entidad.HasOne(e => e.Paciente).WithMany().HasForeignKey(e => e.IdPaciente)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- MedicionRIN ----------
            modelBuilder.Entity<MedicionRIN>(entidad =>
            {
                entidad.ToTable("MedicionesRIN");
                entidad.Property(m => m.ValorRIN).HasPrecision(5, 2);
                entidad.Property(m => m.Canal).HasConversion<string>().HasMaxLength(30);
                entidad.Property(m => m.NivelCriticidad).HasConversion<string>().HasMaxLength(30);

                entidad.HasOne(m => m.Paciente).WithMany().HasForeignKey(m => m.IdPaciente)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- Alerta ----------
            modelBuilder.Entity<Alerta>(entidad =>
            {
                entidad.ToTable("Alertas");
                entidad.Property(a => a.Tipo).HasConversion<string>().HasMaxLength(30);
                entidad.Property(a => a.NivelCriticidad).HasConversion<string>().HasMaxLength(30);
                entidad.Property(a => a.Estado).HasConversion<string>().HasMaxLength(30);
                entidad.Property(a => a.Descripcion).IsRequired();
                entidad.Property(a => a.AccionResolucion).HasMaxLength(1000);

                entidad.HasOne(a => a.Paciente).WithMany().HasForeignKey(a => a.IdPaciente)
                    .OnDelete(DeleteBehavior.Restrict);
                entidad.HasOne(a => a.Medicion).WithMany().HasForeignKey(a => a.IdMedicion)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- Turno ----------
            modelBuilder.Entity<Turno>(entidad =>
            {
                entidad.ToTable("Turnos");
                entidad.Property(t => t.Estado).HasConversion<string>().HasMaxLength(30);
                entidad.Property(t => t.Observaciones).HasMaxLength(1000);

                entidad.HasOne(t => t.Paciente).WithMany().HasForeignKey(t => t.IdPaciente)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- Seguimiento ----------
            modelBuilder.Entity<Seguimiento>(entidad =>
            {
                entidad.ToTable("Seguimientos");
                entidad.Property(s => s.TipoContacto).HasConversion<string>().HasMaxLength(30);
                entidad.Property(s => s.Resultado).HasConversion<string>().HasMaxLength(30);
                entidad.Property(s => s.DecisionClinica).HasConversion<string>().HasMaxLength(30);
                entidad.Property(s => s.Observaciones).HasMaxLength(1000);
                entidad.Property(s => s.DetalleDecision).HasMaxLength(1000);

                entidad.HasOne(s => s.Paciente).WithMany().HasForeignKey(s => s.IdPaciente)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- ReporteEstadistico ----------
            modelBuilder.Entity<ReporteEstadistico>(entidad =>
            {
                entidad.ToTable("ReportesEstadisticos");
                entidad.Property(r => r.IndicadorGlobalEficacia).HasPrecision(5, 2);
            });

            // ---------- Datos semilla ----------
            modelBuilder.Entity<ObraSocial>().HasData(
                new ObraSocial { Id = 1, Nombre = "OSDE", Activo = true },
                new ObraSocial { Id = 2, Nombre = "Swiss Medical", Activo = true },
                new ObraSocial { Id = 3, Nombre = "PAMI", Activo = true },
                new ObraSocial { Id = 4, Nombre = "IOMA", Activo = true },
                new ObraSocial { Id = 5, Nombre = "Sin obra social (particular)", Activo = true });

            modelBuilder.Entity<Diagnostico>().HasData(
                new Diagnostico { Id = 1, Nombre = "Fibrilación auricular", Descripcion = "Arritmia supraventricular; anticoagulación para prevención de ACV.", Activo = true },
                new Diagnostico { Id = 2, Nombre = "Trombosis venosa profunda", Descripcion = "Anticoagulación para tratamiento y prevención de recurrencias.", Activo = true },
                new Diagnostico { Id = 3, Nombre = "Tromboembolismo pulmonar", Descripcion = "Anticoagulación tras evento embólico pulmonar.", Activo = true },
                new Diagnostico { Id = 4, Nombre = "Prótesis valvular mecánica", Descripcion = "Anticoagulación permanente por válvula mecánica.", Activo = true },
                new Diagnostico { Id = 5, Nombre = "Síndrome antifosfolípido", Descripcion = "Trombofilia autoinmune con indicación de anticoagulación.", Activo = true });

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    NombreUsuario = "sysadmin",
                    NombreCompleto = "Administrador del sistema",
                    Perfil = "sysadmin",
                    Activo = true,
                    FechaAlta = new DateTime(2026, 9, 15)
                });
        }
    }
}
