using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppWebVideoJuego.Startup))]
namespace AppWebVideoJuego
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
