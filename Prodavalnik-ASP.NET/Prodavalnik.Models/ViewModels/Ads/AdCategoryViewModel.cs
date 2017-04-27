namespace Prodavalnik.Models.ViewModels.Ads
{
    using System;
    using System.Collections.Generic;
    using EntityModels;

    public class AdCategoryViewModel
    {
        public string Title { get; set; }

        public string CategoryName { get; set; }

        public decimal Price { get; set; }
        
        public DateTime PublishOn { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}