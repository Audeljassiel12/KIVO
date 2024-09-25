using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KIVO.Models.ViewModels
{
    public class EntidadCentroMedicoViewModel
    {
        [Required(ErrorMessage = "OBLIGATORIO")]
        [Display(Name = "Nombre de la clínica o centro médico")]
        public string NombreEntidad { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "OBLIGATORIO")]
        public int MunicipioId { get; set; } // ID del municipio

        [Required(ErrorMessage = "OBLIGATORIO")]
        public int DepartamentoId { get; set; } // ID del departamento

        // Listas para los municipios y departamentos
        public List<SelectListItem> Departamentos { get; set; } = new List<SelectListItem>();
    }
}
