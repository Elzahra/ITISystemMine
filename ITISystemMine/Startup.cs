using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITISystemMine.Startup))]
namespace ITISystemMine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
