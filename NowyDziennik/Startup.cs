using Microsoft.Owin;
using Owin;
using System.Globalization;

[assembly: OwinStartupAttribute(typeof(NowyDziennik.Startup))]
namespace NowyDziennik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            ConfigureAuth(app);
        }
    }
}
