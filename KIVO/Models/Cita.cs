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
         public int CentroMedicoId {get; set; }  // Fk a cntroMedio
       

        // Anclas Relacion 

         public CentroMedico? centroMedico{ get; set; }
 
       
    }
}