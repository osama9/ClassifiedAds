using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassifiedApp.Startup))]
namespace ClassifiedApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
