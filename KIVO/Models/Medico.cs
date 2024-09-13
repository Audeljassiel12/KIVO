using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
       public class Medico
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Sus dos {0} son requeridos")] 
        [StringLength(maximumLength:30,MinimumLength = 7,ErrorMessage = "Sus dos {0} no cumplen por el limite de caracteres establecidos.")]
        public string Nombres { get; set; } = null!;
        [Required(ErrorMessage ="Sus dos {0} son requeridos")] 
        [StringLength(maximumLength:30,MinimumLength = 7,ErrorMessage = "Sus dos {0} no cumplen por el limite de caracteres establecidos.")]

        public string Apellidos { get; set; } = null!; 
        [Required(ErrorMessage ="Su numero de {0} es requerido")] 
        [StringLength(maximumLength:8,MinimumLength = 8,ErrorMessage = "El numero de {0} no cumple con los limites de caracteres establecidos.")]

        public string Telefono { get; set; } = null!; 
        [StringLength(maximumLength:70,MinimumLength = 10,ErrorMessage = "El centro medico no cumpe con los caracteres estimados.")]

        public CentroMedico? CentroMedico { get; set; }
        public int CentroMedicoId {get; set; } 
      
    
     

    }

}