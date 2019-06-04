using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JohnsBlog.Startup))]
namespace JohnsBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
