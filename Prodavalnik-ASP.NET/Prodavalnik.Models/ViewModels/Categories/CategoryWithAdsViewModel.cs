namespace Prodavalnik.Models.ViewModels.Categories
{
    using System.Collections.Generic;
    using Ads;

    public class CategoryWithAdsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<AdViewModel> Ads { get; set; }
    }
}