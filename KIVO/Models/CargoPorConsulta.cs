using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class CargoPorConsulta
{
    public int Id { get; set; }

    // Relación con la Cita o Paciente
    public int CitaId { get; set; }
    public Cita? Cita { get; set; }  // Relación con la consulta en la que se generan los cargos

    // Detalles de los cargos
    public decimal Descuento { get; set; }

    // Campos calculados
    public decimal TotalParcial {get; set; }
    public decimal Total => TotalParcial - Descuento;

    // Fecha de creación del cargo
    public DateTime FechaCreacion { get; set; }
}

}