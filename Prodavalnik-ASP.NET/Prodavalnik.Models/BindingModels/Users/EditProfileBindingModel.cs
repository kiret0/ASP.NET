namespace Prodavalnik.Models.BindingModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class EditProfileBindingModel
    {
        [MinLength(3, ErrorMessage = "Името трябва да е поне три букви.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Телефоният номер е задължителен.")]
        [MinLength(10,ErrorMessage = "Телефоният номер трябва да е дълъг поне 10 цифри.")]
        public string PhoneNumber { get; set; }
    }
}