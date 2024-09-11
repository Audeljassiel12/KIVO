using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
public class Receta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string? Instrucciones { get; set; }

    public List<RecetaMedicamento>? RecetaMedicamentos { get; set; }
    public Cita? Cita { get; set; }
    public int CitaId { get; set; } 

   
}


}