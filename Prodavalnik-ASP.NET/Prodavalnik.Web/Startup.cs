using Microsoft.Owin;
using Owin;
using Prodavalnik.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace Prodavalnik.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
