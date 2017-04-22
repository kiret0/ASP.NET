namespace Prodavalnik.Models.ViewModels.Ads
{
    using System;
    using System.Collections.Generic;
    using Categories;

    public class AdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public CategoryWithAdsViewModel Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime PublishOn { get; set; }

        public IEnumerable<string> Images { get; set; }
    }
}