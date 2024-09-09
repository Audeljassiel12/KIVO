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
          public Doctor? Doctor { get; set; }
          public int DoctorId {get; set; } // Fk a Doctor
          public CentroMedico? CentroMedico { get; set; } 
          public int CentroMedicoId {get; set; } // Fk a CentroMedico


 
       
    }
}