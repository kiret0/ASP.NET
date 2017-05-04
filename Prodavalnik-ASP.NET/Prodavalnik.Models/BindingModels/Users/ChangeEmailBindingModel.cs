namespace Prodavalnik.Models.BindingModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class ChangeEmailBindingModel
    {
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Грешна парола.")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Въведете правилен имейл адрес.")]
        public string Email { get; set; }
    }
}