namespace Prodavalnik.Web.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Base;
    using Data.Contracts;
    using System.Web.Mvc;
    using AutoMapper;
    using Models.EntityModels;
    using Models.ViewModels.Categories;
    using Models.ViewModels.Home;
    using Services;

    [RoutePrefix("home")]
    [Route("action=Index")]
    public class HomeController : BaseController
    {
        private HomeService service;
        public HomeController(IProdavalnikData data) : base(data)
        {
            this.service = new HomeService(data);
        }
        [Route("~/")]
        [Route("~/home")]
        [Route("~/home/index")]
        public ActionResult Index()
        {
            var getAdsFromDb = this.service.GetLastThirtyAds();
            IEnumerable<HomeAdViewModel> ads = Mapper.Map<IEnumerable<Ad>, IEnumerable<HomeAdViewModel>>(getAdsFromDb);


            var categoriesFromDb = this.service.GetAllCategories();
            var categories = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categoriesFromDb);
            var homeVm = new HomeViewModel()
            {
                CategoryViewModel = categories,
                AdsViewModel = ads
            };
            return View(homeVm);
        }
        [Route("~/category/{categoryName}")]
        public ActionResult Category(string categoryName)
        {
            var categories = this.service.GetAllCategories();
            var cats = new List<SelectListItem>();
            
            foreach (var category in categories)
            {
                var selectItem = new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                };
                if (category.Name == categoryName)
                {
                    selectItem.Selected = true;
                }
                cats.Add(selectItem);
            }

            var categoryFromDb = service.FindCategoryByName(categoryName);
            CategoryWithAdsViewModel categoryVm = Mapper.Map<Category, CategoryWithAdsViewModel>(categoryFromDb);
            categoryVm.Categories = cats;

            return View(categoryVm);
        }
    }
}