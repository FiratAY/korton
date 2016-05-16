using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kort.Startup))]
namespace kort
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
