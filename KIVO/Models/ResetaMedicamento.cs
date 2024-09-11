using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
       
       
   public class RecetaMedicamento
{
    public int Id { get; set; }
    public Receta? Receta { get; set; }

    public int MedicamentoId { get; set; }
    public Medicamento? Medicamento { get; set; }

    public string? Dosis { get; set; }
    public string? Frecuencia { get; set; }
    public string? Duracion { get; set; }
}

}