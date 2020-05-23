using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(RemoteWebApp.Startup))]

namespace RemoteWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = ConfigurationManager.AppSettings.Get("tenantName"),
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        SaveSigninToken = true,
                        ValidAudience = ConfigurationManager.AppSettings.Get("resourceServer")
                    }
                });
        }
    }
}
