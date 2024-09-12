using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
     public class Cuidad
    {
        public int Id { get; set; } // Primary Key
        [Required(ErrorMessage ="El {0} de la ciudad es requerido")] 
        [StringLength(maximumLength:50,MinimumLength = 25,ErrorMessage = "El nombre de su {0} no cumple con los limites de caracteres establecidos.")]
        public string Nombre { get; set; } = null!;

        // anclas
        
        public List<CentroMedico>? CentroMedicos { get; set; }
    
       public List<Paciente>? Pacientes { get; set; }
       public Departamento? Departamento { get; set; }
       public int DepartamentoId { get; set; }
    }
}