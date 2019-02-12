using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EdmxPractiseApplication.Startup))]
namespace EdmxPractiseApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
