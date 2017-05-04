using System.ComponentModel.DataAnnotations;

namespace Prodavalnik.Models.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Имейлът е задължителен")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}
