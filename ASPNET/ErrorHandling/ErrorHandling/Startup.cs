using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ErrorHandling.Startup))]
namespace ErrorHandling
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
