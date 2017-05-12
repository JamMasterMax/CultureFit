using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZipHackathon.Startup))]
namespace ZipHackathon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
