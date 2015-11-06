using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
//using Microsoft.Owin.Security.ActiveDirectory;
using System.Configuration;

namespace MyDashAPI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
#if false
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
                    },
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"]
                });
#endif
        }

    }
}
