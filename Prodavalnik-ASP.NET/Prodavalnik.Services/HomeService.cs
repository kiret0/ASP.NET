namespace Prodavalnik.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;

    public class HomeService :Service, IHomeService
    {
        public HomeService(IProdavalnikData data) : base(data)
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categoriesFromDb = this.data.Categories.GetAll();
            return categoriesFromDb;
        }

        public Category FindCategoryByName(string categoryName)
        {
            var category = data.Categories.FindByPredicate(cat => cat.Name == categoryName);

            return category;
        }

        public IEnumerable<Ad> GetLastThirtyAds()
        {
            var ads = this.data.Ads.GetAll().OrderByDescending(ad => ad.PublishOn).Take(30);

            return ads;
        }
    }
}