using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{ public class Suscripcion
    {
        public int Id { get; set; }
        public int CentroMedicoId { get; set; } // FK de CentroMedico
        public int PlanSuscripcionId { get; set; } // FK a PlanSuscripcion
        public DateTime FechaInicio { get; set; } 
        public DateTime FechaFin { get; set; } 
        public bool Activa { get; set; } // Determina si la suscripción está activa

        // Anclas 
        
        // ancla a centromedico
        public CentroMedico? CentroMedico { get; set; }
        // ancla a planSuscripcion
        public PlanSuscripcion? PlanSuscripcion { get; set; }
        
       

      
    }

}