namespace Prodavalnik.Models.BindingModels.Ads
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using EntityModels.Enums;

    public class AddAdsBindingModel
    {
        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(40, ErrorMessage = "Заглавието е твърде дълго.")]
        [MinLength(4, ErrorMessage = "Заглватието е твърде кратко.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Категорията е задължителна.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Избери категория.")]
        public int CategoryId { get; set; }
        
        public decimal Price { get; set; }

       
        public string State { get; set; }

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(1000, ErrorMessage = "Описанието е твърде дълго.")]
        [MinLength(25, ErrorMessage = "Описанието е твърде кратко.")]
        public string Description { get; set; }
    }
}