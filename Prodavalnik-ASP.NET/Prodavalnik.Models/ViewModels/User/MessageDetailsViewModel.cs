namespace Prodavalnik.Models.ViewModels.User
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using EntityModels;

    public class MessageDetailsViewModel
    {
        [Required]
        [StringLength(1000, ErrorMessage = "Съобщението е твърде дълго.")]
        [MinLength(2, ErrorMessage = "Съобщението е твърде кратко.")]
        public string Content { get; set; }

        public Ad Ad { get; set; }

        public ApplicationUser Sender { get; set; }

        public DateTime DateOfSent { get; set; }
    }
}