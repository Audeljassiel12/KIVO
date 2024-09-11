using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{public class Medicamento
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Concentracion { get; set; }
    

    public ICollection<Receta>? Recetas { get; set; }
}


}