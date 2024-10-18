using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class PlanSuscripcion
    {
        public int Id { get; set; }  // Identificador único del plan de suscripción.
        
        public string Nombre { get; set; } = null!;  // Nombre del plan (por ejemplo: "Básico", "Premium", etc.).
        
        public decimal Precio { get; set; }  // Precio del plan de suscripción.
        
        public string Descripcion { get; set; } = null!;  // Descripción del plan (características, beneficios, etc.).
        
        public int DuracionEnDias { get; set; }  // Duración del plan en días. Asegúrate de que refleje correctamente el tiempo (podrías querer usar meses).
        
        public bool IsFree { get; set; }  // Indica si es un plan gratuito o no.
        
        // Relación con Suscripciones
        public ICollection<Suscripcion>? Suscripciones { get; set; }  // Relación con las suscripciones asociadas a este plan.
    }
}
