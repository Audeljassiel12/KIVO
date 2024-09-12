using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{public class Medicamento
{
    public int Id { get; set; } 
        [StringLength(maximumLength:60,MinimumLength = 30,ErrorMessage = "El {0} de el medicamento no cumple con los limites de caracteres establecidos.")]
    public string? Nombre { get; set; }
    [StringLength(maximumLength: 200, MinimumLength = 100, ErrorMessage = "Los detalles no cumplen por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public string? Concentracion { get; set; }
    

    public ICollection<Receta>? Recetas { get; set; }
}


}