using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team.Rule.Web.Startup))]
namespace Team.Rule.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
