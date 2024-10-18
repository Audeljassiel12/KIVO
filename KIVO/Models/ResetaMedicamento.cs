using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class RecetaMedicamento
    {
        public int Id { get; set; }  // Identificador único de la relación Receta-Medicamento.

        [Required]
        public Receta? Receta { get; set; }  // Relación con la receta, obligatoria.
        
        [Required]
        public int MedicamentoId { get; set; }  // Identificador del medicamento, obligatorio.
        
        public Medicamento? Medicamento { get; set; }  // Relación con el medicamento.
        
        [Required]
        [StringLength(100, ErrorMessage = "La dosis no puede exceder los 100 caracteres.")]
        public string? Dosis { get; set; }  // Dosis del medicamento, con validación.
        
        [Required]
        [StringLength(100, ErrorMessage = "La frecuencia no puede exceder los 100 caracteres.")]
        public string? Frecuencia { get; set; }  // Frecuencia de administración del medicamento.
        
        [StringLength(50, ErrorMessage = "La duración no puede exceder los 50 caracteres.")]
        public string? Duracion { get; set; }  // Duración del tratamiento.
    }
}
