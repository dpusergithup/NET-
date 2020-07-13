using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCUI显示层.Startup))]
namespace MVCUI显示层
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
