using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PictulrMVC.Startup))]
namespace PictulrMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
