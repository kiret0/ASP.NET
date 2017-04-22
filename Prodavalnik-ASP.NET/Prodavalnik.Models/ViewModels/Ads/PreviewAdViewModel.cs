namespace Prodavalnik.Models.ViewModels.Ads
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class PreviewAdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishOn { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }
        
    }
}