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

        }

       

    }
}