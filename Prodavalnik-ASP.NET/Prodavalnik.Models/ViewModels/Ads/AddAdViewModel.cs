namespace Prodavalnik.Models.ViewModels.Ads
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using EntityModels;
    using EntityModels.Enums;

    public class AddAdViewModel
    {
        [DisplayName("Заглавие на обявата")]
        public string Title { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("Състояние")]
        public State State { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
        
        public IEnumerable<SelectListItem> Categories { get; set; }

        [DisplayName("Категория")]
        public int CategoryId { get; set; }
    }
}