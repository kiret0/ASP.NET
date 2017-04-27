namespace Prodavalnik.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.ModelBinding;
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


        public IEnumerable<Ad> FindingAdsWithFilters(string query, string category, bool? FWDescription, bool? fwPicture, decimal? priceFrom, decimal? priceTo)
        {
            IEnumerable<Ad> ads = FilteringAndReturnAds(query, category, FWDescription, fwPicture, priceFrom, priceTo);

            
            return ads;
        }

        private IEnumerable<Ad> FilteringAndReturnAds(string query, string category, bool? FWDescription, bool? fwPicture, decimal? priceFrom, decimal? priceTo)
        {
            IEnumerable<Ad> allAds = this.data.Ads.GetAll().OrderByDescending(ad => ad.PublishOn);
            IEnumerable<Ad> filteringAds = null;
            
            if (string.IsNullOrEmpty(query))
            {
                filteringAds = allAds;
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == false &&
                fwPicture == false &&
                priceFrom == null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(ad => ad.Title.Contains(query));
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == false &&
                fwPicture == false &&
                priceFrom == null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(ad => ad.Title.Contains(query) && ad.Category.Id == int.Parse(category));
            }
            else if (!string.IsNullOrEmpty(query) &&
                (category == "0" || category == null) &&
                FWDescription == true &&
                (fwPicture == false || fwPicture == null) &&
                priceFrom == null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) ||
                        ad.Description.Contains(query));
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == false &&
                fwPicture == true &&
                priceFrom == null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) && ad.Images.Count != 0);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == false &&
                fwPicture == false &&
                priceFrom != null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) && ad.Price >= priceFrom);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == false &&
                fwPicture == false &&
                priceFrom == null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) && ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == true &&
                fwPicture == false &&
                priceFrom == null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Category.Id == int.Parse(category));
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == false &&
                fwPicture == true &&
                priceFrom == null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Images.Count != 0);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == false &&
                fwPicture == false &&
                priceFrom != null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Price >= priceFrom);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == false &&
                fwPicture == false &&
                priceFrom == null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom == null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Images.Count != 0);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == true &&
                fwPicture == false &&
                priceFrom != null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Price >= priceFrom);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == true &&
                fwPicture == false &&
                priceFrom == null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == false &&
                fwPicture == true &&
                priceFrom != null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Images.Count != 0 &&
                        ad.Price >= priceFrom);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == false &&
                fwPicture == true &&
                priceFrom == null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Images.Count != 0 &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == false &&
                fwPicture == false &&
                priceFrom != null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Price >= priceFrom &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == false &&
                fwPicture == false &&
                priceFrom != null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Price >= priceFrom &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == true &&
                fwPicture == false &&
                priceFrom != null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Price >= priceFrom &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == false &&
                fwPicture == true &&
                priceFrom != null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Images.Count != 0 &&
                        ad.Price >= priceFrom &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == true &&
                fwPicture == false &&
                priceFrom != null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query)||
                        ad.Description.Contains(query)) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Price >= priceFrom &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == false &&
                fwPicture == true &&
                priceFrom != null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Images.Count != 0 &&
                        ad.Price >= priceFrom &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom != null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Images.Count != 0 &&
                        ad.Price >= priceFrom &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == true &&
                fwPicture == false &&
                priceFrom != null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Price >= priceFrom);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == true &&
                fwPicture == false &&
                priceFrom == null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom != null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Images.Count != 0 &&
                        ad.Price >= priceFrom);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom == null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Images.Count != 0 &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == false &&
                fwPicture == true &&
                priceFrom != null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => ad.Title.Contains(query) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Images.Count != 0 &&
                        ad.Price >= priceFrom);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category == "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom == null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Images.Count != 0 &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom == null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Images.Count != 0);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom != null &&
                priceTo == null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Images.Count != 0 &&
                        ad.Price >= priceFrom);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom == null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Images.Count != 0 &&
                        ad.Price <= priceTo);
            }
            else if (!string.IsNullOrEmpty(query) &&
                category != "0" &&
                FWDescription == true &&
                fwPicture == true &&
                priceFrom != null &&
                priceTo != null)
            {
                filteringAds = allAds.Where(
                        ad => (ad.Title.Contains(query) ||
                        ad.Description.Contains(query)) &&
                        ad.Category.Id == int.Parse(category) &&
                        ad.Images.Count != 0 &&
                        ad.Price >= priceFrom &&
                        ad.Price <= priceTo);
            }
            return filteringAds;
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

        public Ad GetAdByName(string adName)
        {
            adName = WebUtility.UrlDecode(adName);
            var ad = this.data.Ads.FindByPredicate(a => a.Title == adName);
            return ad;
        }

        public void AddMessage(Ad ad, ApplicationUser sender, ApplicationUser recipient, string messageContent)
        {
            var message = new Message()
            {
                Content = messageContent,
                Sender = sender,
                Recipient = recipient,
                DateOfSent = DateTime.Now,
                Ad = ad
            };
            this.data.Messages.InsertOrUpdate(message);
            this.data.SaveChanges();
        }

        public ApplicationUser GetUserByEmail(string recipientEmail)
        {
            var user = this.data.Users.FindByPredicate(u => u.Email == recipientEmail);
            return user;
        }
    }
}