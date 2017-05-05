namespace Prodavalnik.Services.Contracts
{
    using System.Collections.Generic;
    using Models.BindingModels.Ads;
    using Models.EntityModels;

    public interface IAdsService
    {
        IEnumerable<Ad> FindingAdsWithFilters(string query, string category, bool? FWDescription, bool? fwPicture, decimal? priceFrom, decimal? priceTo);
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        ApplicationUser GetUserById(string userId);
        void AddAdToDatabase(Category category, ApplicationUser user, HashSet<Image> imgs, AddAdsBindingModel bind);
        Ad GetAdByName(string adName);
        void AddMessage(Ad ad, ApplicationUser sender, ApplicationUser recipient, string messageContent);
        ApplicationUser GetUserByEmail(string recipientEmail);
        void ReportAd(Ad adEntity, ReportAdBindingModel bind);
        void DeteleAd(Ad ad);
        void EditAd(Ad ad, EditAdBindingModel bind);
    }
}