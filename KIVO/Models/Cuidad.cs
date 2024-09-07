using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
     public class Cuidad
    {
        public int Id { get; set; } // Primary Key
        public string Nombre { get; set; } = null!;

        // anclas
        
        public List<CentroMedico>? CentroMedicos { get; set; }
    
    }
}