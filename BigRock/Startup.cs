using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigRock.Startup))]
namespace BigRock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
