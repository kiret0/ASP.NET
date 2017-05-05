namespace Prodavalnik.Services.Contracts
{
    using System.Collections.Generic;
    using Models.BindingModels.Users;
    using Models.EntityModels;

    public interface IUsersService
    {
        IEnumerable<Ad> GetMyAdsFromDb(string userId);
        IEnumerable<Message> GetMessagesFromDb(string userId);
        IEnumerable<Message> GetSendMessagesFromDb(string userId);
        Message GetMessage(int messageId);
        Ad GetAdByName(string adName);
        ApplicationUser GetUserById(string userId);
        void AddMessage(Ad ad, ApplicationUser sender, ApplicationUser recipient, string messageContent);
        void EditProfile(ApplicationUser currentUser, EditProfileBindingModel bind);
        void DeleteProfile(ApplicationUser user);
        void RemoveAds(ApplicationUser user);
        void RemoveMessages(ApplicationUser user);
        void DeleteAd(Ad ad);
        Ad GetAdById(int adId);
    }
}