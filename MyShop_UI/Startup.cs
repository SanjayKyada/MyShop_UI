using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShop_UI.Startup))]
namespace MyShop_UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
