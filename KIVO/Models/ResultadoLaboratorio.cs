using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class ResultadoLaboratorio
    {
        public int Id { get; set; }  // Identificador único del resultado de laboratorio.

        [Required]
        public int CitaId { get; set; }  // Identificador de la cita, obligatorio.
        
        public Cita? Cita { get; set; }  // Relación con la cita.
        
        [Required]
        [StringLength(100, ErrorMessage = "El tipo de prueba no puede exceder los 100 caracteres.")]
        public string? TipoPrueba { get; set; }  // Tipo de prueba realizada.
        
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de la prueba")]
        public DateTime? FechaPrueba { get; set; }  // Fecha de la prueba de laboratorio.
        
        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder los 500 caracteres.")]
        public string? Observaciones { get; set; }  // Observaciones sobre el resultado.
        
        [Url(ErrorMessage = "La URL del archivo no es válida.")]
        public string? ArchivoUrl { get; set; }  // Ruta o URL del archivo almacenado.
    }
}
