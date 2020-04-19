using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MotelManagement.Startup))]
namespace MotelManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
