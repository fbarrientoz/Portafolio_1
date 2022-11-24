using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Portafolio_1.Startup))]
namespace Portafolio_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
