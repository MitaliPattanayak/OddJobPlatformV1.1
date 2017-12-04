using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OddJobPlatformV1._1.Startup))]
namespace OddJobPlatformV1._1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
