using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KIVO.Models.Dto
{
    public class MedicoDo
    {
        [Display(Name = "Cédula de Identidad")]
        [Required(ErrorMessage = "OBLIGATORIO")]
        [StringLength(20, ErrorMessage = "La cédula no puede exceder los 20 caracteres.")]
        public string Cedula { get; set; } = string.Empty;  // Inicia como cadena vacía

        [Display(Name = "Especialidad (si aplica)")]
        [Required(ErrorMessage = "OBLIGATORIO")]
        public int EspecialidadId { get; set; }
        public List<SelectListItem>? Especialidades { get; set; }
    }
}
