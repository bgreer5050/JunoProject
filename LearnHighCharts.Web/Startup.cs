using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnHighCharts.Web.Startup))]
namespace LearnHighCharts.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
