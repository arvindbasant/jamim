using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Com.Jamim.UI.Startup))]
namespace Com.Jamim.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
