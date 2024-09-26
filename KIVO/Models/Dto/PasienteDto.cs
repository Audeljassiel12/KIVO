using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KIVO.Models.Dto
{

    public class PacienteDTO
    {
        public string Id { get; set; }
     

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre(s)")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Apellido(s)")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        [Display(Name = "Género")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

      
        [Phone(ErrorMessage = "Número de teléfono no válido")]
        [Display(Name = "Teléfono")]
        [PhoneNumber("NI",ErrorMessage ="El numero de telefono no es valido")]
        public string? Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        [Display(Name = "Ciudad")]
        public int? CiudadId { get; set; } = null;

        [Display(Name = "Estado")]
        public int? CuidadId { get; set; } = null; 

        [Display(Name = "Código Postal")]
        public string? CodigoPostal { get; set; }

        [Display(Name = "Notas Internas")]
        public string? NotasInternas { get; set; }

        [Display(Name = "Foto de Perfil")]
        public string? FotoPerfilUrl { get; set; }
        public List<SelectListItem> Departamentos { get; set; } = new List<SelectListItem>();

        public IFormFile? formFile { get; set; }
       
    }


}
