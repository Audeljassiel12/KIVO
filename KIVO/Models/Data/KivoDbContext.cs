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
        public DbSet<CargoPorConsulta> cargoPorConsultas {get; set; }
        public DbSet<CentroMedico> CentroMedicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Cuidad> Ciudades { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Dieta> Dietas { get; set; }
        public DbSet<EnfermedadesHereditarias> EnfermedadesHereditarias { get; set; }
        public DbSet<EspecialidadMedica> EspecialidadMedicas { get; set; }
        public DbSet<ExploracionTopografica> ExploracionTopograficas { get; set; }
        public DbSet<HistoriaPostnatal> historiaPostnatalsopost { get; set; }
        public DbSet<HistoriaObstetricaGinecologica> HistoriaObstetricaGinecologicas { get; set; }
        public DbSet<HistoriaPsiquiatrica> HistoriaPsiquiatricas { get; set; }
        public DbSet<HorarioAtencion> HorarioAtencions { get; set; }
        public DbSet<InvitacionDoctor> InvitacionDoctors { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<NotaDeEncuentro> NotaDeEncuentros { get; set; }
        public DbSet<Nutricion> Nutricions {get;set;}
        public DbSet<Paciente> Pacientes {get;set;}
        public DbSet<PlanSuscripcion> PlanSuscripcions {get;set;}
        public DbSet<Producto> Productos {get;set;}
        public DbSet<Receta> Recetas {get;set;}
        public DbSet<RecetaMedicamento>  RecetaMedicamentos {get; set; }    
        public DbSet<ResultadoLaboratorio> ResultadoLaboratorios{get;set;}
        public DbSet<SignosVitales> SignosVitales {get;set;}
        public DbSet<Suscripcion> Suscripcions{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cita>()
       .HasOne(c => c.Medico)
       .WithMany(a=>a.Citas)
       .HasForeignKey(c => c.MedicoId).
       OnDelete(DeleteBehavior.Restrict);

       modelBuilder.Entity<Cita>()
        .HasOne(c => c.CentroMedico)
        .WithMany(a=>a.Citas)
        .HasForeignKey(c => c.CentroMedicoId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(a=>a.Cita)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict)
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
    .WithMany(a=>a.Pacientes)
    .HasForeignKey(p => p.DepartamentoId)
    .OnDelete(DeleteBehavior.Restrict); // Cambiado de Cascade a Restrict




            modelBuilder.Entity<EspecialidadMedica>().HasData(
    // Especialidades Médicas
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
    new EspecialidadMedica { Id = 19, Nombre = "Cirugía General" },
    new EspecialidadMedica { Id = 20, Nombre = "Cirugía Plástica" },
    new EspecialidadMedica { Id = 21, Nombre = "Medicina Interna" },
    new EspecialidadMedica { Id = 22, Nombre = "Medicina Familiar" },
    new EspecialidadMedica { Id = 23, Nombre = "Medicina del Deporte" },
    new EspecialidadMedica { Id = 24, Nombre = "Geriatría" },
    new EspecialidadMedica { Id = 25, Nombre = "Traumatología" },
    new EspecialidadMedica { Id = 26, Nombre = "Neurocirugía" },
    new EspecialidadMedica { Id = 27, Nombre = "Anestesiología" },
    new EspecialidadMedica { Id = 28, Nombre = "Radiología" },
    new EspecialidadMedica { Id = 29, Nombre = "Patología" },
    new EspecialidadMedica { Id = 30, Nombre = "Neonatología" },
    new EspecialidadMedica { Id = 31, Nombre = "Allergología" },
    new EspecialidadMedica { Id = 32, Nombre = "Medicina Nuclear" },
    new EspecialidadMedica { Id = 33, Nombre = "Toxicología" },
    new EspecialidadMedica { Id = 34, Nombre = "Fisiatría" },
    new EspecialidadMedica { Id = 35, Nombre = "Cuidados Paliativos" },

    // Servicios Médicos y Roles en el Centro Médico
    new EspecialidadMedica { Id = 36, Nombre = "Enfermería" },
    new EspecialidadMedica { Id = 37, Nombre = "Radiología" },
    new EspecialidadMedica { Id = 38, Nombre = "Técnico de Laboratorio" },
    new EspecialidadMedica { Id = 39, Nombre = "Farmacia" },
    new EspecialidadMedica { Id = 40, Nombre = "Fisioterapia" },
    new EspecialidadMedica { Id = 41, Nombre = "Nutrición" },
    new EspecialidadMedica { Id = 42, Nombre = "Psicología" },
    new EspecialidadMedica { Id = 43, Nombre = "Trabajador Social" },
    new EspecialidadMedica { Id = 44, Nombre = "Administración de Salud" },
    new EspecialidadMedica { Id = 45, Nombre = "Odontología" },
    new EspecialidadMedica { Id = 46, Nombre = "Terapia Ocupacional" },
    new EspecialidadMedica { Id = 47, Nombre = "Logopedia" },
    new EspecialidadMedica { Id = 48, Nombre = "Alumnos/Internos" },
    new EspecialidadMedica { Id = 49, Nombre = "Urgencias Médicas" },
    new EspecialidadMedica { Id = 50, Nombre = "Paramédicos" },
    new EspecialidadMedica { Id = 51, Nombre = "Gestión Administrativa" }
);
  modelBuilder.Entity<PlanSuscripcion>().HasData(
            new PlanSuscripcion
            {
                Id = 1,
                Nombre = "Plan Básico",
                Precio = 0, // Gratuito
                Descripcion = "Este es un plan gratuito con acceso limitado.",
                DuracionEnDias = 30, // 1 mes
                IsFree = true
            },
            new PlanSuscripcion
            {
                Id = 2,
                Nombre = "Plan Estándar",
                Precio = 29.99m,
                Descripcion = "Acceso a todas las funcionalidades por 1 mes.",
                DuracionEnDias = 30, // 1 mes
                IsFree = false
            },
            new PlanSuscripcion
            {
                Id = 3,
                Nombre = "Plan Premium",
                Precio = 99.99m,
                Descripcion = "Acceso ilimitado por 3 meses.",
                DuracionEnDias = 90, // 3 meses
                IsFree = false
            }
        );
        }



    }
}