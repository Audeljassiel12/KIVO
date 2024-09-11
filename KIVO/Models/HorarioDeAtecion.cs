using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
     public enum DiasDeLaSemanaAtencion
    {
        Domingo = 0,
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        Sabado = 6
    }
 public class HorarioAtencion
{
    public int Id { get; set; }
    // Días de la semana
    public DiasDeLaSemanaAtencion Dia { get; set; }

    // Horario de apertura
    public TimeSpan HoraApertura { get; set; }
    
    // Horario de cierre
    public TimeSpan HoraCierre { get; set; }
    public CentroMedico? CentroMedico { get; set; }
    public int CentroMedicoId { get; set; }
}

}