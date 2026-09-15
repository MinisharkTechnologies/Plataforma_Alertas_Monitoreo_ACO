using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Negocio.DomainModel;
using Negocio.DomainModel.Enums;

namespace Negocio.DAL.Context
{
    /// <summary>
    /// Contexto de Entity Framework Core del módulo Negocio: mapea las entidades del dominio
    /// sobre la base OpenRIN_Negocio, con índices de unicidad (incluido el filtrado de DNI
    /// entre pacientes activos), conversiones de enums a texto y datos semilla de catálogos.
    /// Integra la firma de integridad (DVH por fila / DVV por tabla) en un único punto:
    /// cada SaveChanges firma automáticamente las filas escritas y recalcula los dígitos
    /// verticales de las tablas afectadas.
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
        public DbSet<DigitosVerificadores> DigitosVerificadores => Set<DigitosVerificadores>();

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

        /// <summary>
        /// Guarda los cambios firmando primero cada fila (DVH) y actualizando después los
        /// dígitos verticales (DVV) de las tablas afectadas. La recalculación de DVV post-save
        /// usa SaveChanges base para no re-entrar en esta lógica.
        /// </summary>
        public override int SaveChanges()
        {
            PrepararDigitosHorizontales();

            var tablasTocadas = new HashSet<string>(StringComparer.Ordinal);
            foreach (var entrada in ChangeTracker.Entries())
            {
                if (entrada.State == EntityState.Unchanged || entrada.State == EntityState.Detached)
                {
                    continue;
                }
                if (entrada.Entity is DigitosVerificadores)
                {
                    continue;
                }
                string? tabla = entrada.Metadata.GetTableName();
                if (tabla != null && entrada.Metadata.FindProperty("DVH") != null)
                {
                    tablasTocadas.Add(tabla);
                }
            }

            int resultado = base.SaveChanges();

            foreach (string tabla in tablasTocadas)
            {
                ActualizarDigitoVertical(tabla);
            }
            return resultado;
        }

        /// <summary>Calcula y asigna el DVH de cada fila agregada o modificada antes de persistir.</summary>
        private void PrepararDigitosHorizontales()
        {
            foreach (var entrada in ChangeTracker.Entries())
            {
                if (entrada.State != EntityState.Added && entrada.State != EntityState.Modified)
                {
                    continue;
                }
                if (entrada.Entity is DigitosVerificadores || entrada.Metadata.FindProperty("DVH") == null)
                {
                    continue;
                }
                entrada.Property("DVH").CurrentValue = DigitoVerificador.CalcularDVH(entrada.Entity);
            }
        }

        /// <summary>Recalcula el DVV de una tabla a partir de los DVH vigentes y lo persiste si cambió.</summary>
        private void ActualizarDigitoVertical(string tabla)
        {
            List<(int Id, string? Dvh)> filas = LeerFilasDVH(tabla);
            string nuevo = DigitoVerificador.CalcularDVV(tabla, filas);

            DigitosVerificadores? registro = DigitosVerificadores.FirstOrDefault(d => d.NombreTabla == tabla);
            if (registro == null)
            {
                DigitosVerificadores.Add(new DigitosVerificadores
                {
                    NombreTabla = tabla,
                    DVV = nuevo,
                    FechaCalculo = DateTime.Now
                });
            }
            else if (!string.Equals(registro.DVV, nuevo, StringComparison.Ordinal))
            {
                registro.DVV = nuevo;
                registro.FechaCalculo = DateTime.Now;
            }

            if (ChangeTracker.HasChanges())
            {
                base.SaveChanges();
            }
        }

        /// <summary>Lectura tipada de (Id, DVH) por tabla, para el cálculo de los dígitos verticales.</summary>
        private List<(int Id, string? Dvh)> LeerFilasDVH(string tabla) => tabla switch
        {
            "Pacientes" => Pacientes.AsNoTracking().Select(p => new { p.Id, D = EF.Property<string>(p, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "ObrasSociales" => ObrasSociales.AsNoTracking().Select(o => new { o.Id, D = EF.Property<string>(o, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "Diagnosticos" => Diagnosticos.AsNoTracking().Select(d => new { d.Id, D = EF.Property<string>(d, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "HistoriasClinicas" => HistoriasClinicas.AsNoTracking().Select(h => new { h.Id, D = EF.Property<string>(h, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "EventosAdversos" => EventosAdversos.AsNoTracking().Select(e => new { e.Id, D = EF.Property<string>(e, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "MedicionesRIN" => MedicionesRIN.AsNoTracking().Select(m => new { m.Id, D = EF.Property<string>(m, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "Alertas" => Alertas.AsNoTracking().Select(a => new { a.Id, D = EF.Property<string>(a, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "Turnos" => Turnos.AsNoTracking().Select(t => new { t.Id, D = EF.Property<string>(t, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "Seguimientos" => Seguimientos.AsNoTracking().Select(s => new { s.Id, D = EF.Property<string>(s, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "Usuarios" => Usuarios.AsNoTracking().Select(u => new { u.Id, D = EF.Property<string>(u, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            "ReportesEstadisticos" => ReportesEstadisticos.AsNoTracking().Select(r => new { r.Id, D = EF.Property<string>(r, "DVH") })
                .ToList().Select(x => (x.Id, (string?)x.D)).ToList(),
            _ => new List<(int, string?)>()
        };

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------- ObraSocial ----------
            modelBuilder.Entity<ObraSocial>(entidad =>
            {
                entidad.ToTable("ObrasSociales");
                entidad.Property(o => o.Nombre).HasMaxLength(150).IsRequired();
                entidad.HasIndex(o => o.Nombre).IsUnique();
                entidad.Property<string>("DVH").HasMaxLength(128);
            });

            // ---------- Diagnostico ----------
            modelBuilder.Entity<Diagnostico>(entidad =>
            {
                entidad.ToTable("Diagnosticos");
                entidad.Property(d => d.Nombre).HasMaxLength(200).IsRequired();
                entidad.Property(d => d.Descripcion).HasMaxLength(1000);
                entidad.HasIndex(d => d.Nombre).IsUnique();
                entidad.Property<string>("DVH").HasMaxLength(128);
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
                entidad.Property<string>("DVH").HasMaxLength(128);
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
                entidad.Property<string>("DVH").HasMaxLength(128);

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
                entidad.Property<string>("DVH").HasMaxLength(128);

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
                entidad.Property<string>("DVH").HasMaxLength(128);

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
                entidad.Property<string>("DVH").HasMaxLength(128);

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
                entidad.Property<string>("DVH").HasMaxLength(128);

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
                entidad.Property<string>("DVH").HasMaxLength(128);

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
                entidad.Property<string>("DVH").HasMaxLength(128);

                entidad.HasOne(s => s.Paciente).WithMany().HasForeignKey(s => s.IdPaciente)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- ReporteEstadistico ----------
            modelBuilder.Entity<ReporteEstadistico>(entidad =>
            {
                entidad.ToTable("ReportesEstadisticos");
                entidad.Property(r => r.IndicadorGlobalEficacia).HasPrecision(5, 2);
                entidad.Property<string>("DVH").HasMaxLength(128);
            });

            // ---------- DigitosVerificadores (DVV por tabla) ----------
            modelBuilder.Entity<DigitosVerificadores>(entidad =>
            {
                entidad.ToTable("DigitosVerificadores");
                entidad.Property(d => d.NombreTabla).HasMaxLength(100).IsRequired();
                entidad.HasIndex(d => d.NombreTabla).IsUnique();
                entidad.Property(d => d.DVV).HasMaxLength(128).IsRequired();
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
