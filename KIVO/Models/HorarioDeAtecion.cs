using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    // Enumeración que representa los días de la semana
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
        public int Id { get; set; } // Identificador único para el horario de atención.
        
        // Días de la semana
        public DiasDeLaSemanaAtencion Dia { get; set; } // Día de la semana para el horario de atención.

        // Horario de apertura y cierre
        public TimeSpan HoraApertura { get; set; } // Hora de apertura del centro médico.
        public TimeSpan HoraCierre { get; set; } // Hora de cierre del centro médico.

        // Relación con el centro médico
        public CentroMedico? CentroMedico { get; set; } // Centro médico asociado a este horario de atención.
        public int CentroMedicoId { get; set; } // Identificador del centro médico.
    }
}