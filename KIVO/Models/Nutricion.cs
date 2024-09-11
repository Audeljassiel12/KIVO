using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class Nutricion
{
    public int Id { get; set; }
    public int CitaId { get; set; }
    public Cita? Cita { get; set; }

    // Campos de nutrición y seguimiento
    public decimal? PerdidaPeso { get; set; }
    public decimal? Agua { get; set; }
    public decimal? PorcentajeGrasaCorporal { get; set; }
    public decimal? MasaMuscular { get; set; }
    public decimal? Cintura { get; set; }
    public decimal? Abdomen { get; set; }
}
}