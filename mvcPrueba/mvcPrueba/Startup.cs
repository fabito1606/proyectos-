using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcPrueba.Startup))]
namespace mvcPrueba
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
