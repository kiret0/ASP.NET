namespace Prodavalnik.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Contracts;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.BindingModels.Users;
    using Models.EntityModels;

    public class UsersService : Service, IUsersService
    {
        public UsersService(IProdavalnikData data) : base(data)
        {
        }


        public IEnumerable<Ad> GetMyAdsFromDb(string userId)
        {
            var ads = this.data.Ads.Find(ad => ad.Author.Id == userId);
            return ads;
        }

        public IEnumerable<Message> GetMessagesFromDb(string userId)
        {
            var messages = this.data.Messages.Find(message => message.Recipient.Id == userId);
            return messages;
        }

        public IEnumerable<Message> GetSendMessagesFromDb(string userId)
        {
                var messages = this.data.Messages.Find(message => message.Sender.Id == userId);
                return messages;
        }

        public Message GetMessage(int messageId)
        {
            var message = this.data.Messages.GetById(messageId);
            return message;
        }

        public Ad GetAdByName(string adName)
        {
            adName = WebUtility.UrlDecode(adName);
            var adEntity = this.data.Ads.FindByPredicate(ad => ad.Title == adName);
            return adEntity;
        }

        public ApplicationUser GetUserById(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(data.Context.DbContext));
            var user = userManager.FindById(userId);

            return user;
        }

        public void AddMessage(Ad ad, ApplicationUser sender, ApplicationUser recipient, string messageContent)
        {
            var message = new Message()
            {
                Content = messageContent,
                Sender = sender,
                Recipient = recipient,
                Ad = ad,
                DateOfSent = DateTime.Now
            };
            this.data.Messages.InsertOrUpdate(message);
            this.data.SaveChanges();
        }

        public void EditProfile(ApplicationUser currentUser, EditProfileBindingModel bind)
        {
            currentUser.Name = bind.Name;
            currentUser.PhoneNumber = bind.PhoneNumber;
            this.data.SaveChanges();
        }

        public void DeleteProfile(ApplicationUser user)
        {
            this.data.Users.Delete(user);
            this.data.SaveChanges();
        }

        public void RemoveAds(ApplicationUser user)
        {
            var ads = this.data.Ads.Find(ad => ad.Author.Id == user.Id);
            
            user.Ads.Clear();
            foreach (var ad in ads)
            {
                var images = new List<Image>();
                images.AddRange(ad.Images);
                foreach (var image in images)
                {
                    this.data.Images.Delete(image);
                }
                this.data.Ads.Delete(ad);
            }
            this.data.SaveChanges();
        }

        public void RemoveMessages(ApplicationUser user)
        {
            var messages = this.data.Messages.Find(m => m.Recipient.Id == user.Id || m.Sender.Id == user.Id);
            foreach (var message in messages)
            {
                this.data.Messages.Delete(message);
            }
            this.data.SaveChanges();
        }

        public void DeleteAd(Ad ad)
        {
            var images = new List<Image>();
            images.AddRange(ad.Images);
            foreach (var image in images)
            {
                this.data.Images.Delete(image);
            }

            this.data.Ads.Delete(ad);
            this.data.SaveChanges();
        }

        public Ad GetAdById(int adId)
        {
            var ad = this.data.Ads.GetById(adId);
            return ad;
        }
    }
}