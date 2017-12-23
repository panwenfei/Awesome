using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AWE.PWF.WEB.Startup))]
namespace AWE.PWF.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
