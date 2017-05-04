using System.ComponentModel.DataAnnotations;

namespace Prodavalnik.Models.ViewModels.Manage
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Старата парола е задължителна.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Новата парола е задължителна.")]
        [StringLength(100, ErrorMessage = "Паролата трябва да съдържа букви и цифри, и да е поне 6 симвиола.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Новата парола и паролата за потвърждение не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}