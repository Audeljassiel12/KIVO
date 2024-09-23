using KIVO.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Models.Dto
{
    public class InputModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo no válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres y un máximo de {1} caracteres.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\W).+$", ErrorMessage = "La contraseña debe contener al menos una letra y un carácter especial.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirma la contraseña.")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Número de teléfono no válido.")]
        public string CellPhone { get; set; }
    }

}