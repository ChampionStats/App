using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoL.Startup))]
namespace LoL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
