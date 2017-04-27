namespace Prodavalnik.Models.ViewModels.Categories
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ads;

    public class CategoryWithAdsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<AdCategoryViewModel> Ads { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}