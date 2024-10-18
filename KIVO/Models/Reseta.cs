using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class Receta
    {
        public int Id { get; set; }  // Identificador único de la receta.
        
        public DateTime Fecha { get; set; }  // Fecha en que se emitió la receta.
        
        public string? Instrucciones { get; set; }  // Instrucciones del médico respecto a la receta.
        
        public List<RecetaMedicamento>? RecetaMedicamentos { get; set; }  // Relación con los medicamentos recetados.
        
        public Cita? Cita { get; set; }  // Relación con la cita en la que se generó la receta.
        
        public int CitaId { get; set; }  // Identificador de la cita relacionada.
    }
}
