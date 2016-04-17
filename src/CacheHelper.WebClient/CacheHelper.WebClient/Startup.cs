using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Com.EnjoyCodes.CacheHelper.WebClient.Startup))]
namespace Com.EnjoyCodes.CacheHelper.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
