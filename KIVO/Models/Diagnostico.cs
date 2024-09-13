using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models
{
   public class Diagnostico
{
    public int Id { get; set; }
    public string CodigoCIE10 { get; set; }  = null!;  // Código de la enfermedad según CIE-10
    [StringLength(maximumLength: 100, MinimumLength = 20, ErrorMessage = "no cumple por el límite de caracteres establecidos (entre {1} y {2} caracteres).")]

    public string Descripcion { get; set; }   = null!; // Descripción del diagnóstico
     public bool EsGlobal { get; set; }  // Si es un diagnóstico global o personalizado
   
    public int CitaId { get; set; }          // Relación con la cita
    public Cita? Cita { get; set; }           // Relación con la entidad Cita

    
}

}