using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DziennikUczniaN.Startup))]
namespace DziennikUczniaN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
