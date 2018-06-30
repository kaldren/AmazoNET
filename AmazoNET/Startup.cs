using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmazoNET.Startup))]
namespace AmazoNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
