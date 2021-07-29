using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Log4netDemo.Startup))]
namespace Log4netDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
