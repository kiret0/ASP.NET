namespace Prodavalnik.Models.ViewModels.Ads
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Web.Mvc;

    public class AdsViewModel
    {
        public IEnumerable<PreviewAdViewModel> previewAdViewModels { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}