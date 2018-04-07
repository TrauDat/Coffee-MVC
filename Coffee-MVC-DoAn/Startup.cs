using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Coffee_MVC_DoAn.Startup))]
namespace Coffee_MVC_DoAn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
