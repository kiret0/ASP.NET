namespace Prodavalnik.Models.ViewModels.Ads
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using EntityModels;
    using EntityModels.Enums;

    public class EditAdViewModel
    {
        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(40, ErrorMessage = "Заглавието е твърде дълго.")]
        [MinLength(4, ErrorMessage = "Заглватието е твърде кратко.")]
        [DisplayName("Заглавие на обявата")]
        public string Title { get; set; }
        
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("Състояние")]
        public State State { get; set; }

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(1000, ErrorMessage = "Описанието е твърде дълго.")]
        [MinLength(25, ErrorMessage = "Описанието е твърде кратко.")]
        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Категория")]
        public string CategoryName { get; set; }
        
        public IEnumerable<Image> Images { get; set; }
    }
}