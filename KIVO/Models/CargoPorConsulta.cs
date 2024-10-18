using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
    public class CargoPorConsulta
    {
        [Key]
        public int Id { get; set; }

        // Relación con la Cita o Paciente
        [Required(ErrorMessage = "El campo CitaId es obligatorio.")]
        public int CitaId { get; set; }

        [ForeignKey("CitaId")]
        public Cita? Cita { get; set; }  // Relación con la consulta en la que se generan los cargos

        // Detalles de los cargos
        [Range(0, double.MaxValue, ErrorMessage = "El descuento no puede ser negativo.")]
        [DataType(DataType.Currency, ErrorMessage = "El valor de Descuento debe ser un número válido.")]
        public decimal Descuento { get; set; }

        // Campos calculados
        [Range(0, double.MaxValue, ErrorMessage = "El total parcial no puede ser negativo.")]
        [DataType(DataType.Currency, ErrorMessage = "El valor de TotalParcial debe ser un número válido.")]
        public decimal TotalParcial { get; set; }

        [NotMapped]
        public decimal Total => TotalParcial - Descuento;

        // Fecha de creación del cargo
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; }
    }
}