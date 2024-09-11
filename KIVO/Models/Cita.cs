using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
     public  enum EstadoDeCita
    {
       
        Programada=1,
        Proceso=2,
        Finalizada = 3,
        Cancelada = 4


    }
  
    public class Cita
    {
        public int Id { get; set; }
    
        public int CentroMedicoID { get; set; }
        public DateTime FechaCita { get; set; }
        public string Motivo { get; set; } = null!;
        public EstadoDeCita EstadoDeCita  { get; set; } // FK a EstadoCita
        
        // Anclas Relacion 
         public  SignosVitales? SignosVitales { get; set; }
          public int SignosVitalesId {get; set; } // Fk a SignosVitales  
          public Paciente? Paciente { get; set; }
          public int PacienteId {get; set; } // Fk a Paciente
          public Medico? Medico { get; set; }
          public int MedicoId {get; set; } // Fk a Doctor
          public CentroMedico? CentroMedico { get; set; } 
          public int CentroMedicoId {get; set; } // Fk a CentroMedico


        // Relacion de RecetaMedica
        public Receta? Receta { get; set; }
        public int? RecetaId { get; set; } // Fk a Receta

        
        // Relacion de ExploracionTopografica
        public ExploracionTopografica? ExploracionTopografica { get; set; }
        public int? ExploracionTopograficaId { get; set; } // Fk a ExploracionTopografica

        // Relacion de ResultadoLaboratorio
        public ResultadoLaboratorio? ResultadoLaboratorio { get; set; }
        public int? ResultadoLaboratorioId { get; set; } // Fk a ResultadoLaboratorio

        // Relacion de Nutricion
        public Nutricion? Nutricion { get; set; }
        public int? NutricionId { get; set; } // Fk a Nutricion

        // Relacion de ExamenFisico

        public List<NotaDeEncuentro>? NotaDeEncuentros { get;}   
        



          


 
       
    }
}