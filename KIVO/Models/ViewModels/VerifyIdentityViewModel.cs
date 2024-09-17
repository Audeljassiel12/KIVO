using System.ComponentModel.DataAnnotations;

namespace KIVO.Models.ViewModels
{
    public class VerifyIdentityViewModel
    {
     

      

        [Required(ErrorMessage = "The phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The verification code is required.")]
        public string VerificationCode { get; set; }
        public bool IsGoogleLogin { get; set; }

    }

}
