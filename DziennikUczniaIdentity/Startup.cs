using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DziennikUczniaIdentity.Startup))]
namespace DziennikUczniaIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
