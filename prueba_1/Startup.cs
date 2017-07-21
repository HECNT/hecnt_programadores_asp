using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prueba_1.Startup))]
namespace prueba_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
