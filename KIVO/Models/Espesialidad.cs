using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class EspecialidadMedica
{
    public int Id { get; set; }
    public string? Nombre { get; set; }  // Nombre de la especialidad (ej. Cardiología, Pediatría)
 
    // Relación con otros modelos
    public ICollection<Medico>? Medicos { get; set; }  // Doctores que tienen esta especialidad
   
}

}