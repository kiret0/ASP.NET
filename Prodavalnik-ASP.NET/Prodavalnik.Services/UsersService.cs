namespace Prodavalnik.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;

    public class UsersService : Service
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
    }
}