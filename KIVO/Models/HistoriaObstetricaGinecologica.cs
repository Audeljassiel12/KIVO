using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class HistoriaObstetricaGinecologica
{
    public int HistoriaObstetricaGinecologicaId { get; set; }

    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Fechas y características de la menstruación
    public DateTime? PrimeraCitaMenstruacion { get; set; }  // Primera cita de la menstruación
    public DateTime? UltimaFechaMenstruacion { get; set; }  // Última fecha de menstruación
    public string?   CaracteristicasMenstruacion { get; set; }  // Características de la menstruación

    // Opciones booleanas y detalles
    public bool? Embarazos { get; set; }
     public string? DetallesEmbarazos { get; set; }

    public bool? CancerCuelloUterino { get; set; }
    public string? DetallesCancerCuelloUterino { get; set; }

    public bool? CancerUtero { get; set; }
    public string? DetallesCancerUtero { get; set; }

    public bool? CancerMama { get; set; }
    public string? DetallesCancerMama { get; set; }

    public bool? ActividadSexual { get; set; }
    public string? DetallesActividadSexual { get; set; }

    // Métodos de control natal utilizados
    public string? MetodosControlNatalidad { get; set; }

    // Terapia de reemplazo hormonal
    public bool? TerapiaReemplazoHormonal { get; set; }
  public string? DetallesTerapiaReemplazoHormonal { get; set; }

    // Última prueba de Papanicolaou
    public DateTime? UltimaPruebaPapanicolaou { get; set; }

    // Última mastografía
    public DateTime? UltimaMastografia { get; set; }

    // Otro
    public bool? Otro { get; set; }
   public string? DetallesOtro { get; set; }
}

}