using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Logging;
using System;

namespace Data
{
    public class AcademiaContext : DbContext
    {
        private static string DefaultConnectionString = "Server=localhost,1433;Database=Universidad;User Id=sa;Password=TuContraseñaFuerte123;TrustServerCertificate=True";

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<ModulosUsuarios> ModulosUsuarios { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<AlumnoCurso> AlumnoCursos { get; set; }
        public DbSet<DocenteCurso> DocenteCursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = DefaultConnectionString;

                try
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();

                    connectionString = configuration.GetConnectionString("DefaultConnection") ?? DefaultConnectionString;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading configuration: {ex.Message}. Using default connection string.");
                }

                optionsBuilder.UseSqlServer(connectionString);
                
                #if DEBUG
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
                optionsBuilder.EnableSensitiveDataLogging();
                #endif
            }
        }

        public AcademiaContext()
        {
        }

        public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(50);

                entity.HasData(
                    new { Id = 1, Descripcion = "Artes" },
                    new { Id = 2, Descripcion = "Humanidades" },
                    new { Id = 3, Descripcion = "Tecnico Electronico" }
                );
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).ValueGeneratedOnAdd();
                entity.Ignore(u => u.Nombre); // Propiedad calculada desde Persona
                entity.Ignore(u => u.Apellido); // Propiedad calculada desde Persona
                entity.Property(u => u.UsuarioNombre).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Salt).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Habilitado).IsRequired().HasDefaultValue(true);

                entity.HasOne(u => u.Persona)
                      .WithMany(p => p.Usuarios)
                      .HasForeignKey(u => u.PersonaId)
                      .OnDelete(DeleteBehavior.SetNull)
                      .IsRequired(false);

                entity.HasIndex(u => u.UsuarioNombre).IsUnique();
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Descripcion).IsRequired().HasMaxLength(50);
                entity.Property(p => p.EspecialidadId).IsRequired();
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("Materias");
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Id).ValueGeneratedOnAdd();
                entity.Property(m => m.Descripcion).IsRequired().HasMaxLength(100);
                entity.Property(m => m.HorasSemanales).IsRequired();
                entity.Property(m => m.HorasTotales).IsRequired();
                entity.Property(m => m.IdPlan).IsRequired();
            });

            modelBuilder.Entity<Comision>(entity =>
            {
                entity.HasKey(c => c.IdComision);
                entity.Property(c => c.IdComision).ValueGeneratedOnAdd();
                entity.Property(c => c.DescComision).IsRequired().HasMaxLength(50);
                entity.Property(c => c.AnioEspecialidad).IsRequired();
                entity.Property(c => c.IdPlan).IsRequired();
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
                entity.Property(p => p.TipoPersona).HasConversion<string>();
                entity.HasIndex(p => p.Email).IsUnique();
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(c => c.IdCurso);
                entity.Property(c => c.IdCurso).ValueGeneratedOnAdd();
                entity.Property(c => c.IdMateria).IsRequired(false);
                entity.Property(c => c.IdComision).IsRequired();
                entity.Property(c => c.AnioCalendario).IsRequired();
                entity.Property(c => c.Cupo).IsRequired();
            });

            modelBuilder.Entity<AlumnoCurso>(entity =>
            {
                entity.HasKey(ac => ac.IdInscripcion);
                entity.Property(ac => ac.IdInscripcion).ValueGeneratedOnAdd();
                entity.Property(ac => ac.IdAlumno).IsRequired();
                entity.Property(ac => ac.IdCurso).IsRequired();
                entity.Property(ac => ac.Condicion).HasConversion<string>();
                entity.Property(ac => ac.Nota).IsRequired(false);
                
                entity.HasIndex(ac => new { ac.IdAlumno, ac.IdCurso }).IsUnique();
            });

            modelBuilder.Entity<DocenteCurso>(entity =>
            {
                entity.ToTable("docentes_cursos");
                entity.HasKey(dc => dc.IdDictado);
                entity.Property(dc => dc.IdDictado)
                    .HasColumnName("id_dictado")
                    .ValueGeneratedOnAdd();
                entity.Property(dc => dc.IdCurso)
                    .HasColumnName("id_curso")
                    .IsRequired();
                entity.Property(dc => dc.IdDocente)
                    .HasColumnName("id_docente")
                    .IsRequired();
                entity.Property(dc => dc.Cargo)
                    .HasColumnName("cargo")
                    .HasConversion<string>()
                    .IsRequired();

                entity.HasOne(dc => dc.Curso)
                    .WithMany()
                    .HasForeignKey(dc => dc.IdCurso)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(dc => dc.Docente)
                    .WithMany()
                    .HasForeignKey(dc => dc.IdDocente)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(dc => new { dc.IdCurso, dc.IdDocente, dc.Cargo }).IsUnique();
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("Modulos");
                entity.HasKey(m => m.Id_Modulo);
                entity.Property(m => m.Id_Modulo).ValueGeneratedOnAdd();
                entity.Property(m => m.Desc_Modulo).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Ejecuta).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<ModulosUsuarios>(entity =>
            {
                entity.ToTable("ModulosUsuarios");
                entity.HasKey(mu => mu.Id_ModuloUsuario);
                entity.Property(mu => mu.Id_ModuloUsuario).ValueGeneratedOnAdd();
                entity.Property(mu => mu.UsuarioId).IsRequired();
                entity.Property(mu => mu.ModuloId).IsRequired();
                entity.Property(mu => mu.alta).IsRequired().HasDefaultValue(false);
                entity.Property(mu => mu.baja).IsRequired().HasDefaultValue(false);
                entity.Property(mu => mu.modificacion).IsRequired().HasDefaultValue(false);
                entity.Property(mu => mu.consulta).IsRequired().HasDefaultValue(false);

                entity.HasOne(mu => mu.Usuario)
                    .WithMany(u => u.ModulosUsuarios)
                    .HasForeignKey(mu => mu.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mu => mu.Modulo)
                    .WithMany(m => m.ModulosUsuarios)
                    .HasForeignKey(mu => mu.ModuloId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(mu => new { mu.UsuarioId, mu.ModuloId }).IsUnique();
            });
        }
    }
}