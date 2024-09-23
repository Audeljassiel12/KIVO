using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
       public class Medico
    {
        public string Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!; 
       
        public string Telefono { get; set; } = null!; 
        public CentroMedico? CentroMedico { get; set; }
        public int CentroMedicoId {get; set; } 
        public List<Cita> Citas { get; set; }
        public EspecialidadMedica? EspecialidadMedico { get;set; }
        public int EspecialidadMedicoId {get;set; }
      
    
     

    }

}