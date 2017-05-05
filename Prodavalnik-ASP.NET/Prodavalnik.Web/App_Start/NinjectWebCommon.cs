[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Prodavalnik.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Prodavalnik.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Prodavalnik.Web.App_Start
{
    using System;
    using System.Web;
    using Data;
    using Data.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Services;
    using Services.Contracts;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProdavalnikData>().To<ProdavalnikData>();
            kernel.Bind<IProdavalnikContext>().To<ProdavalnikContext>();
            kernel.Bind<IAdminService>().To<AdminService>();
            kernel.Bind<IAdsService>().To<AdsService>();
            kernel.Bind<ICategoriesService>().To<CategoriesService>();
            kernel.Bind<IHomeService>().To<HomeService>();
            kernel.Bind<IUsersService>().To<UsersService>();
        }        
    }
}
