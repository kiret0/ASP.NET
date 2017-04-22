namespace Prodavalnik.Models.ViewModels.Categories
{
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<CategoryViewModel> SubCategories { get; set; }
    }
}