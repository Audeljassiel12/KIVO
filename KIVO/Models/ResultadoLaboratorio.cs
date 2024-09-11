using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class ResultadoLaboratorio
{
    public int Id { get; set; }
    public int CitaId { get; set; }
    public Cita? Cita { get; set; }
    public string? TipoPrueba { get; set; }
    public DateTime? FechaPrueba { get; set; }
    public string? Observaciones { get; set; }
    public string? ArchivoUrl { get; set; }  // Ruta o URL del archivo almacenado
}

}