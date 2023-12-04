using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DziennikUcznia.Startup))]
namespace DziennikUcznia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
