using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyDashAPI.Startup))]

namespace MyDashAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if false
            ConfigureAuth(app);
#endif
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}
