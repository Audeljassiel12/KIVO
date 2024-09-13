using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{  public enum DiasDeLaSemana
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
        public int Id { get; set; } // Clave primaria
        public int CentroMedicoID { get; set; } // Clave foránea a CentroMedico
        public DiasDeLaSemana DiaSemana { get; set; } // Día de la semana (Lunes, Martes, etc.)
        public TimeSpan HoraApertura { get; set; } // Hora de apertura
        public TimeSpan HoraCierre { get; set; } // Hora de cierre
        public bool EsDiaFestivo { get; set; } // Indica si el horario es para un día festivo o especial

        // Relación
        public CentroMedico CentroMedico { get; set; } // Relación con el centro médico
    }
}