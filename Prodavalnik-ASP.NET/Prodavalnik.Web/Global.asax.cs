using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Prodavalnik.Web
{
    using System.Linq;
    using AutoMapper;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.Ads;
    using Models.ViewModels.Categories;
    using Models.ViewModels.Home;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoadMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void LoadMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryWithAdsViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Ad, AdViewModel>();
                cfg.CreateMap<AddCategoryBindingModel, Category>();
                cfg.CreateMap<Ad, PreviewAdViewModel>()
                    .ForMember(ad => ad.CategoryId, opts => opts.MapFrom(ad => ad.Category.Id))
                    .ForMember(ad => ad.CategoryName, opts => opts.MapFrom(ad => ad.Category.Name));
                cfg.CreateMap<Ad, HomeAdViewModel>();
            });
        }
    }
}
