using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Duiklogboek.Startup))]
namespace Duiklogboek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
