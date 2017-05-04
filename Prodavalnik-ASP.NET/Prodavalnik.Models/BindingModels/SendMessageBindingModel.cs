namespace Prodavalnik.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class SendMessageBindingModel
    {
        [Required]
        [StringLength(1000, ErrorMessage = "Съобщението е твърде дълго.")]
        [MinLength(2, ErrorMessage = "Съобщението е твърде кратко.")]
        public string MessageContent { get; set; }

        public string RecipientId { get; set; }

        public string AdName { get; set; }
    }
}