namespace Prodavalnik.Models.ViewModels.Home
{
    using System.Collections.Generic;
    using Categories;

    public class HomeViewModel
    {
        public IEnumerable<CategoryViewModel> CategoryViewModel { get; set; }

        public IEnumerable<HomeAdViewModel> AdsViewModel { get; set; }
    }
}