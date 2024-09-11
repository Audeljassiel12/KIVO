using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
 public class Producto
{
    public int Id { get; set; }            // Identificador único del producto
    public string? Nombre { get; set; }      // Nombre del producto o consulta
    public string? SKU { get; set; }         // Código SKU para identificación
    public int Stock { get; set; }          // Cantidad de productos disponibles (puede ser -1 si no aplica stock)
    public decimal Precio { get; set; }     // Precio del producto o consulta
    public bool Activo { get; set; }        // Indica si el producto está activo

    // Relación con el centro médico u otras entidades
    public int CentroMedicoId { get; set; }
    public CentroMedico ?CentroMedico { get; set; }

    // Relación con la categoría de producto o tipo de consulta
 
}

}