namespace Prodavalnik.Services.Contracts
{
    using System.Collections.Generic;
    using Models.EntityModels;

    public interface IHomeService
    {
        IEnumerable<Category> GetAllCategories();
        Category FindCategoryByName(string categoryName);
        IEnumerable<Ad> GetLastThirtyAds();
    }
}