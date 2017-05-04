using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Prodavalnik.Web
{
    using System.Linq;
    using AutoMapper;
    using Models.BindingModels;
    using Models.BindingModels.Admin;
    using Models.EntityModels;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Ads;
    using Models.ViewModels.Categories;
    using Models.ViewModels.Home;
    using Models.ViewModels.User;

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
                cfg.CreateMap<Category, CategoryWithAdsViewModel>()
                    .ForMember(c => c.Ads, opts => opts.MapFrom(c => c.Ads.OrderByDescending(ad => ad.PublishOn)));

                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Ad, AdViewModel>()
                    .ForMember(ad => ad.CategoryName, opts => opts.MapFrom(ad => ad.Category.Name)); 

                cfg.CreateMap<Ad, AdCategoryViewModel>()
                    .ForMember(ad => ad.CategoryName, opts => opts.MapFrom(ad => ad.Category.Name));

                cfg.CreateMap<AddCategoryBindingModel, Category>();
                cfg.CreateMap<Ad, PreviewAdViewModel>()
                    .ForMember(ad => ad.CategoryName, opts => opts.MapFrom(ad => ad.Category.Name));

                cfg.CreateMap<Ad, HomeAdViewModel>();
                cfg.CreateMap<Ad, MyAdViewModel>();
                cfg.CreateMap<Message, MessageViewModel>()
                .ForMember(m => m.Sender, opts => opts.MapFrom(m => m.Sender));
                cfg.CreateMap<Ad, AdMessageDetailsViewModel>();
                cfg.CreateMap<Message, MessageDetailsViewModel>();
                cfg.CreateMap<Report, ReportViewModel>();
                cfg.CreateMap<Ad, EditAdViewModel>()
                    .ForMember(ad => ad.CategoryName, opts => opts.MapFrom(ad => ad.Category.Name));
            });
        }
    }
}
