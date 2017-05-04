using System.ComponentModel.DataAnnotations;

namespace Prodavalnik.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Имейлът е задължителен.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
