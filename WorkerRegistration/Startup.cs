using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkerRegistration.Startup))]
namespace WorkerRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Common.Countries.Load();
            Resources.LoadLanguages();
        }
    }
}
