using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proj1.Startup))]
namespace proj1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
