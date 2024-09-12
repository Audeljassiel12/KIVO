using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{public class Medicamento
{
    public int Id { get; set; }
        [Required(ErrorMessage ="el {0} del medicamento es requerido")] 
        [StringLength(maximumLength:60,MinimumLength = 30,ErrorMessage = "El {0} de el medicamento no cumple con los limites de caracteres establecidos.")]
    public string? Nombre { get; set; }
    public string? Concentracion { get; set; }
    

    public ICollection<Receta>? Recetas { get; set; }
}


}