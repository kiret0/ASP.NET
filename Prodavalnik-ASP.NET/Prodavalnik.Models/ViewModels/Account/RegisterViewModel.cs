using System.ComponentModel.DataAnnotations;

namespace Prodavalnik.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Въведете правилен имейл адрес.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Паролата трябва да е минимум 6 символа и да събържа букви и цифри", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Паролата не съвпада с ")]
        public string ConfirmPassword { get; set; }
    }
}
