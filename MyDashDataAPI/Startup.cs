using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Security.Claims;
using System.Configuration;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens;
using Owin.Types;
using System.Linq;

[assembly: OwinStartup(typeof(MyDashDataAPI.Startup))]

namespace MyDashDataAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var claim = ((ClaimsIdentity)context.Request.User.Identity).FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier");
                if (claim == null)
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Forbidden: http://schemas.microsoft.com/identity/claims/objectidentifier claim is missing");
                    return;
                }
                else if (claim.Value != ConfigurationManager.AppSettings["AllowedClientPrincipalId"])
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Forbidden: calling app does not have access");
                    return;
                }
                await next.Invoke();
            });
        }
    }
}
