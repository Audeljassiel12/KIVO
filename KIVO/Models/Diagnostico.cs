using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class Diagnostico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El código CIE-10 es obligatorio.")]
        [StringLength(10, ErrorMessage = "El código CIE-10 no puede exceder los 10 caracteres.")]
        public string CodigoCIE10 { get; set; } = null!;  // Código de la enfermedad según CIE-10

        [Required(ErrorMessage = "La descripción del diagnóstico es obligatoria.")]
        [StringLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres.")]
        public string Descripcion { get; set; } = null!; // Descripción del diagnóstico

        public bool EsGlobal { get; set; }  // Si es un diagnóstico global o personalizado

        [Required(ErrorMessage = "El ID de la cita es obligatorio.")]
        public int CitaId { get; set; }          // Relación con la cita

        [ForeignKey("CitaId")]
        public Cita? Cita { get; set; }           // Relación con la entidad Cita
    }
}