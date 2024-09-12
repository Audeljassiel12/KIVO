using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class Departamento
    {
        public int Id { get; set; } // Primary Key
        [Required(ErrorMessage ="Su {0} es requerido")] 
        [StringLength(maximumLength:60,MinimumLength = 30,ErrorMessage = "El nombre de su {0} no cumple con los limites de caracteres establecidos.")]
        public string Nombre { get; set; } = null!;

        // anclas  
        public List<CentroMedico>? CentroMedicos{ get; set; }
        public List<Paciente>? Pacientes { get; set; }

        public List<Cuidad>? Ciudades { get; set; } 

       
    }
}