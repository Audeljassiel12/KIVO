using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KIVO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KIVO.Config
{
    public class CitaConfig
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>().HasOne(a=>a.ExploracionTopografica)
            .WithOne(a=>a.Cita).HasForeignKey<ExploracionTopografica>(a=>a.CitaId);

            modelBuilder.Entity<Cita>().HasOne(a=>a.Nutricion).WithOne(a=>a.Cita)
            .HasForeignKey<Nutricion>(a=>a.CitaId);

            modelBuilder.Entity<Cita>().HasOne(a=>a.Receta).WithOne(a=>a.Cita)
            .HasForeignKey<Receta>(a=>a.CitaId);

             modelBuilder.Entity<Cita>().HasOne(a=>a.ResultadoLaboratorio).WithOne(a=>a.Cita)
            .HasForeignKey<ResultadoLaboratorio>(a=>a.CitaId);


            modelBuilder.Entity<Cita>().HasOne(a => a.SignosVitales).WithOne(a => a.Cita)
           .HasForeignKey<SignosVitales>(a => a.CitaId);




        }
    }
}