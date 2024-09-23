using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KIVO.Models.ViewModels
{
    public class EntidadMedicaViewModel
    {
        [Required(ErrorMessage = "El nombre de la clínica o centro médico es obligatorio.")]
        [Display(Name = "Nombre de la clínica o centro médico")]
        public string NombreEntidad { get; set; }

        [Display(Name = "Especialidad (si aplica)")]
        public int EspecialidadId { get; set; }
        public List<SelectListItem>? Especialidades { get; set; }
    }

}
