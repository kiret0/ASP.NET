namespace Prodavalnik.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.BindingModels.Ads;
    using Models.EntityModels;
    using Models.EntityModels.Enums;

    public class AdsService : Service
    {
        public AdsService(IProdavalnikData data) : base(data)
        {
        }


        public IEnumerable<Ad> FindingAdsByQuery(string query)
        {
            IEnumerable<Ad> ads;
            if (string.IsNullOrEmpty(query))
            {
                ads = this.data.Ads.GetAll().OrderByDescending(ad => ad.PublishOn);
            }
            else
            {
                ads = this.data.Ads.Find(ad => ad.Title.Contains(query) || ad.Description.Contains(query))
                    .OrderByDescending(ad => ad.PublishOn);
            }
            return ads;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = this.data.Categories.GetAll();
            return categories;
        }



        public Category GetCategoryById(int categoryId)
        {
            var category = this.data.Categories.GetById(categoryId);

            return category;
        }

        public ApplicationUser GetUserById(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(data.Context.DbContext));
            var user = userManager.FindById(userId);

            return user;
        }


        public void AddAdToDatabase(Category category, ApplicationUser user, HashSet<Image> imgs, AddAdsBindingModel bind)
        {
            var ad = new Ad
            {
                Title = bind.Title,
                Category = category,
                Price = bind.Price,
                Description = bind.Description,
                Author = user,
                PublishOn = DateTime.Now,
                State = (State)Enum.Parse(typeof(State), bind.State),
                Images = imgs
            };
            this.data.Ads.InsertOrUpdate(ad);
            this.data.SaveChanges();
        }
    }
}