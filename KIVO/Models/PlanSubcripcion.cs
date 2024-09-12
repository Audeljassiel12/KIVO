using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class PlanSuscripcion
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 50, ErrorMessage = "El {0} no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
        public string Nombre { get; set; } = null!;
        [StringLength(maximumLength: 50, MinimumLength = 25, ErrorMessage = "El {0} no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
        public decimal Precio { get; set; }
        [StringLength(maximumLength: 400, MinimumLength = 200, ErrorMessage = "La {0} no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
        public string Descripcion { get; set; } = null!;
        [StringLength(maximumLength: 50, MinimumLength = 25, ErrorMessage = "La duracion no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
        public int DuracionEnMeses { get; set; } // Duración en meses

        // Relación con Suscripciones
        public ICollection<Suscripcion>? Suscripciones { get; set; }
    }
}