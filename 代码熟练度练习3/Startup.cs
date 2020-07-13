using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(代码熟练度练习3.Startup))]
namespace 代码熟练度练习3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
