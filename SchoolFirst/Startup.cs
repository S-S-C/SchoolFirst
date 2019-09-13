using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolFirst.Startup))]
namespace SchoolFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
