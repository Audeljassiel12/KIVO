using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class Nutricion
    {
        public int Id { get; set; }  // Identificador único de la nutrición

        public int CitaId { get; set; }  // Relación con la Cita
        public Cita? Cita { get; set; }  // Objeto Cita relacionado

        // Campos de nutrición y seguimiento
        public decimal? PerdidaPeso { get; set; }  // Pérdida de peso en kg
        public decimal? Agua { get; set; }  // Consumo de agua en litros
        public decimal? PorcentajeGrasaCorporal { get; set; }  // Porcentaje de grasa corporal
        public decimal? MasaMuscular { get; set; }  // Masa muscular en kg
        public decimal? Cintura { get; set; }  // Medida de la cintura en cm
        public decimal? Abdomen { get; set; }  // Medida del abdomen en cm
    }
}
