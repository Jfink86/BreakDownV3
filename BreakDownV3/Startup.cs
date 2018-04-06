using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BreakDownV3.Startup))]
namespace BreakDownV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
