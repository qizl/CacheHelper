using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CacheHelper.WebClient.Startup))]
namespace CacheHelper.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
