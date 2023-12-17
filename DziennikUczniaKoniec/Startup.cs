using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DziennikUczniaKoniec.Startup))]
namespace DziennikUczniaKoniec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
