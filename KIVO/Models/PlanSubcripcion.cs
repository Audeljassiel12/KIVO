using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class PlanSuscripcion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Descripcion { get; set; } = null!;
        public int DuracionEnMeses { get; set; } // Duración en meses

        // Relación con Suscripciones
        public ICollection<Suscripcion>? Suscripciones { get; set; }
    }
}