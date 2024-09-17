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
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [Display(Name = "Nombres")]
            public string Nombres { get; set; }  = null!;
      
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [EmailAddress(ErrorMessage = "El campo {0} debe ser una dirección de correo electrónico válida.")]
            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = null!; 

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; } = null!; 


        [ValidarNumero(CodigoPais ="Ni")]
        public string CellPhone { get; set; } = null!;
        }
}