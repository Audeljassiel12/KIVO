using System.ComponentModel.DataAnnotations;

namespace KIVO.Models.Dto
{
    public class InputModelLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recuerdame??")]
        public bool RememberMe { get; set; }
    }
}
