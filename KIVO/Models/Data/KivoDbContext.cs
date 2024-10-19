using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using KIVO.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KIVO.Models.Data
{
    public class KivoDbContext : IdentityDbContext<User>
    {
        public KivoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AntecedentesFamiliaresPatologicos> AntecedentesFamiliaresPatologicos { get; set; }
        public DbSet<CargoPorConsulta> CargoPorConsultas { get; set; }
        public DbSet<CentroMedico> CentroMedicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Cuidad> Ciudades { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Dieta> Dietas { get; set; }
        public DbSet<EnfermedadesHereditarias> EnfermedadesHereditarias { get; set; }
        public DbSet<EspecialidadMedica> EspecialidadesMedicas { get; set; }
        public DbSet<ExploracionTopografica> ExploracionesTopograficas { get; set; }
        public DbSet<HistoriaPostnatal> HistoriasPostnatales { get; set; }
        public DbSet<HistoriaObstetricaGinecologica> HistoriasObstetricasGinecologicas { get; set; }
        public DbSet<HistoriaPsiquiatrica> HistoriasPsiquiatricas { get; set; }
        public DbSet<HorarioAtencion> HorariosAtencion { get; set; }
        public DbSet<InvitacionDoctor> InvitacionesDoctors { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<NotaDeEncuentro> NotasDeEncuentros { get; set; }
        public DbSet<Nutricion> Nutriciones { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PlanSuscripcion> PlanSuscripciones { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<RecetaMedicamento> RecetasMedicamentos { get; set; }
        public DbSet<ResultadoLaboratorio> ResultadosLaboratorios { get; set; }
        public DbSet<SignosVitales> SignosVitales { get; set; }
        public DbSet<Suscripcion> Suscripciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(a => a.Citas)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.CentroMedico)
                .WithMany(a => a.Citas)
                .HasForeignKey(c => c.CentroMedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(a => a.Cita)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            CitaConfig.Config(modelBuilder);

            modelBuilder.Entity<CargoPorConsulta>()
                .Property(c => c.Descuento)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CargoPorConsulta>()
                .Property(c => c.TotalParcial)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<HistoriaPostnatal>()
                .Property(h => h.PesoAlNacer)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Nutricion>()
                .Property(n => n.Abdomen)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Nutricion>()
                .Property(n => n.Agua)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Nutricion>()
                .Property(n => n.Cintura)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Nutricion>()
                .Property(n => n.MasaMuscular)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Nutricion>()
                .Property(n => n.PerdidaPeso)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Nutricion>()
                .Property(n => n.PorcentajeGrasaCorporal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PlanSuscripcion>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Departamento)
                .WithMany(a => a.Pacientes)
                .HasForeignKey(p => p.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CentroMedico>()
                 .HasOne(cm => cm.Departamento)
                 .WithMany(d => d.CentroMedicos)
                 .HasForeignKey(cm => cm.DepartamentoId).
                 OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CentroMedico>()
                .HasOne(cm => cm.Cuidad)
                .WithMany(c => c.CentroMedicos)
                .HasForeignKey(cm => cm.CuidadId)
                .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<EspecialidadMedica>().HasData(
                new EspecialidadMedica { Id = 1, Nombre = "Cardiología" },
                new EspecialidadMedica { Id = 2, Nombre = "Pediatría" },
                new EspecialidadMedica { Id = 3, Nombre = "Dermatología" },
                new EspecialidadMedica { Id = 4, Nombre = "Oftalmología" },
                new EspecialidadMedica { Id = 5, Nombre = "Neurología" },
                new EspecialidadMedica { Id = 6, Nombre = "Ginecología" },
                new EspecialidadMedica { Id = 7, Nombre = "Psiquiatría" },
                new EspecialidadMedica { Id = 8, Nombre = "Ortopedia" },
                new EspecialidadMedica { Id = 9, Nombre = "Neumología" },
                new EspecialidadMedica { Id = 10, Nombre = "Endocrinología" },
                new EspecialidadMedica { Id = 11, Nombre = "Gastroenterología" },
                new EspecialidadMedica { Id = 12, Nombre = "Oncología" },
                new EspecialidadMedica { Id = 13, Nombre = "Urología" },
                new EspecialidadMedica { Id = 14, Nombre = "Nefrología" },
                new EspecialidadMedica { Id = 15, Nombre = "Hematología" },
                new EspecialidadMedica { Id = 16, Nombre = "Infectología" },
                new EspecialidadMedica { Id = 17, Nombre = "Reumatología" },
                new EspecialidadMedica { Id = 18, Nombre = "Otorrinolaringología" },
                new EspecialidadMedica { Id = 19, Nombre = "Toxicología" }
            );

            modelBuilder.Entity<PlanSuscripcion>().HasData(
      new PlanSuscripcion { Id = 1, Nombre = "Básico", Precio = 0, Descripcion = "Plan básico sin costo." },
      new PlanSuscripcion { Id = 2, Nombre = "Estándar", Precio = 50, Descripcion = "Plan estándar con acceso a consultas." },
      new PlanSuscripcion { Id = 3, Nombre = "Premium", Precio = 100, Descripcion = "Plan premium con acceso completo a servicios." }
  );

            modelBuilder.Entity<Departamento>().HasData(
     new Departamento { Id = 1, Nombre = "Managua" },
     new Departamento { Id = 2, Nombre = "León" },
     new Departamento { Id = 3, Nombre = "Granada" },
     new Departamento { Id = 4, Nombre = "Masaya" },
     new Departamento { Id = 5, Nombre = "Chinandega" },
     new Departamento { Id = 6, Nombre = "Matagalpa" },
     new Departamento { Id = 7, Nombre = "Estelí" },
     new Departamento { Id = 8, Nombre = "Rivas" },
     new Departamento { Id = 9, Nombre = "Jinotega" },
     new Departamento { Id = 10, Nombre = "Carazo" },
     new Departamento { Id = 11, Nombre = "Boaco" },
     new Departamento { Id = 12, Nombre = "Chontales" },
     new Departamento { Id = 13, Nombre = "Río San Juan" },
     new Departamento { Id = 14, Nombre = "Nueva Segovia" },
     new Departamento { Id = 15, Nombre = "RAAN" },
     new Departamento { Id = 16, Nombre = "RAAS" }
 );

            modelBuilder.Entity<Cuidad>().HasData(
                // Managua
                new Cuidad { Id = 1, Nombre = "Managua", DepartamentoId = 1 },
                new Cuidad { Id = 2, Nombre = "Tipitapa", DepartamentoId = 1 },
                new Cuidad { Id = 3, Nombre = "Ciudad Sandino", DepartamentoId = 1 },
                // León
                new Cuidad { Id = 4, Nombre = "León", DepartamentoId = 2 },
                new Cuidad { Id = 5, Nombre = "El Sauce", DepartamentoId = 2 },
                new Cuidad { Id = 6, Nombre = "La Paz Centro", DepartamentoId = 2 },
                // Granada
                new Cuidad { Id = 7, Nombre = "Granada", DepartamentoId = 3 },
                new Cuidad { Id = 8, Nombre = "Nandaime", DepartamentoId = 3 },
                // Masaya
                new Cuidad { Id = 9, Nombre = "Masaya", DepartamentoId = 4 },
                new Cuidad { Id = 10, Nombre = "Nindirí", DepartamentoId = 4 },
                // Chinandega
                new Cuidad { Id = 11, Nombre = "Chinandega", DepartamentoId = 5 },
                new Cuidad { Id = 12, Nombre = "Corinto", DepartamentoId = 5 },
                // Matagalpa
                new Cuidad { Id = 13, Nombre = "Matagalpa", DepartamentoId = 6 },
                new Cuidad { Id = 14, Nombre = "Jinotega", DepartamentoId = 6 },
                // Estelí
                new Cuidad { Id = 15, Nombre = "Estelí", DepartamentoId = 7 },
                new Cuidad { Id = 16, Nombre = "Condega", DepartamentoId = 7 },
                // Rivas
                new Cuidad { Id = 17, Nombre = "Rivas", DepartamentoId = 8 },
                new Cuidad { Id = 18, Nombre = "San Juan del Sur", DepartamentoId = 8 },
                // Jinotega
                new Cuidad { Id = 19, Nombre = "Jinotega", DepartamentoId = 9 },
                new Cuidad { Id = 20, Nombre = "San Rafael del Norte", DepartamentoId = 9 },
                // Carazo
                new Cuidad { Id = 21, Nombre = "Diriamba", DepartamentoId = 10 },
                new Cuidad { Id = 22, Nombre = "Jinotepe", DepartamentoId = 10 },
                // Boaco
                new Cuidad { Id = 23, Nombre = "Boaco", DepartamentoId = 11 },
                new Cuidad { Id = 24, Nombre = "Camoapa", DepartamentoId = 11 },
                // Chontales
                new Cuidad { Id = 25, Nombre = "Juigalpa", DepartamentoId = 12 },
                new Cuidad { Id = 26, Nombre = "Acoyapa", DepartamentoId = 12 },
                // Río San Juan
                new Cuidad { Id = 27, Nombre = "San Carlos", DepartamentoId = 13 },
                new Cuidad { Id = 28, Nombre = "El Castillo", DepartamentoId = 13 },
                // Nueva Segovia
                new Cuidad { Id = 29, Nombre = "Ocotal", DepartamentoId = 14 },
                new Cuidad { Id = 30, Nombre = "Jalapa", DepartamentoId = 14 },
                // RAAN
                new Cuidad { Id = 31, Nombre = "Bilwi", DepartamentoId = 15 },
                new Cuidad { Id = 32, Nombre = "Waspam", DepartamentoId = 15 },
                // RAAS
                new Cuidad { Id = 33, Nombre = "Bluefields", DepartamentoId = 16 },
                new Cuidad { Id = 34, Nombre = "Laguna de Perlas", DepartamentoId = 16 }
            );

        }
    }
}
