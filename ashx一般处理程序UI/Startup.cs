using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ashx一般处理程序UI.Startup))]
namespace ashx一般处理程序UI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
