using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class HistoriaObstetricaGinecologica
    {
        public int Id { get; set; } // Identificador único de la historia obstétrica y ginecológica.

        public string PacienteId { get; set; } // Identificador del paciente.
        public Paciente? Paciente { get; set; } // Relación con el modelo Paciente.

        // Fechas y características de la menstruación
        public DateTime? PrimeraCitaMenstruacion { get; set; }  // Primera cita de la menstruación.
        public DateTime? UltimaFechaMenstruacion { get; set; }  // Última fecha de menstruación.
        public string? CaracteristicasMenstruacion { get; set; }  // Características de la menstruación.

        // Opciones booleanas y detalles
        public bool? Embarazos { get; set; } // Indica si ha tenido embarazos.
        public string? DetallesEmbarazos { get; set; } // Detalles sobre los embarazos.

        public bool? CancerCuelloUterino { get; set; } // Indica si hay diagnóstico de cáncer de cuello uterino.
        public string? DetallesCancerCuelloUterino { get; set; } // Detalles sobre el cáncer de cuello uterino.

        public bool? CancerUtero { get; set; } // Indica si hay diagnóstico de cáncer de útero.
        public string? DetallesCancerUtero { get; set; } // Detalles sobre el cáncer de útero.

        public bool? CancerMama { get; set; } // Indica si hay diagnóstico de cáncer de mama.
        public string? DetallesCancerMama { get; set; } // Detalles sobre el cáncer de mama.

        public bool? ActividadSexual { get; set; } // Indica si hay actividad sexual.
        public string? DetallesActividadSexual { get; set; } // Detalles sobre la actividad sexual.

        // Métodos de control natal utilizados
        public string? MetodosControlNatalidad { get; set; } // Métodos de control de natalidad utilizados.

        // Terapia de reemplazo hormonal
        public bool? TerapiaReemplazoHormonal { get; set; } // Indica si recibe terapia de reemplazo hormonal.
        public string? DetallesTerapiaReemplazoHormonal { get; set; } // Detalles sobre la terapia de reemplazo hormonal.

        // Última prueba de Papanicolaou
        public DateTime? UltimaPruebaPapanicolaou { get; set; } // Fecha de la última prueba de Papanicolaou.

        // Última mastografía
        public DateTime? UltimaMastografia { get; set; } // Fecha de la última mastografía.

        // Otro
        public bool? Otro { get; set; } // Indica si hay otra condición relevante.
        public string? DetallesOtro { get; set; } // Detalles sobre otra condición.
    }
}