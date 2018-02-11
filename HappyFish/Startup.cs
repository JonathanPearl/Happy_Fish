using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HappyFish.Startup))]
namespace HappyFish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
