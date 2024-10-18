using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class Medicamento
    {
        public int Id { get; set; } // Clave primaria para identificar de manera única cada medicamento.
        
        public string? Nombre { get; set; } // Nombre del medicamento.
        
        public string? Concentracion { get; set; } // Concentración del medicamento (por ejemplo, mg, g).
        
        // Relación con las recetas donde se utiliza el medicamento.
        public ICollection<Receta>? Recetas { get; set; } // Colección de recetas que incluyen este medicamento.
    }
}