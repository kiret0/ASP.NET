namespace Prodavalnik.Models.BindingModels.Ads
{
    using System.ComponentModel.DataAnnotations;

    public class EditAdBindingModel
    {
        public string EditAdName { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(40, ErrorMessage = "Заглавието е твърде дълго.")]
        [MinLength(4, ErrorMessage = "Заглватието е твърде кратко.")]
        public string Title { get; set; }
        
        public decimal Price { get; set; }


        public string State { get; set; }

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(1000, ErrorMessage = "Описанието е твърде дълго.")]
        [MinLength(25, ErrorMessage = "Описанието е твърде кратко.")]
        public string Description { get; set; }
    }
}