using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NowyDziennik.Startup))]
namespace NowyDziennik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
