using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
 public class Producto
{
    public int Id { get; set; }            // Identificador único del producto
    [StringLength(maximumLength: 100, MinimumLength = 50, ErrorMessage = "El {0} no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public string? Nombre { get; set; }      // Nombre del producto o consulta
    [StringLength(maximumLength: 20, MinimumLength = 10, ErrorMessage = "El {0} no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public string? SKU { get; set; }         // Código SKU para identificación
    [StringLength(maximumLength: 100, MinimumLength = 50, ErrorMessage = "El {0} no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public int Stock { get; set; }          // Cantidad de productos disponibles (puede ser -1 si no aplica stock)
    [StringLength(maximumLength: 60, MinimumLength = 30, ErrorMessage = "El {0} no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]
    public decimal Precio { get; set; }     // Precio del producto o consulta
    public bool Activo { get; set; }        // Indica si el producto está activo

    // Relación con el centro médico u otras entidades
    public int CentroMedicoId { get; set; }
    public CentroMedico ?CentroMedico { get; set; }

    // Relación con la categoría de producto o tipo de consulta
 
}

}