using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace DevMediaApi
{
    public class DeviMediaAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //var userManager = context.OwinContext.GetUserManager<AppUserManager>();

            //var usuario = await userManager.FindAsync(context.UserName, context.Password);

            if (context.UserName != "gsonego" || context.Password != "abc@123")
            {
                context.SetError("invalid_grant", "Usuario ou senha inválidos");
                return;
            }

            //ClaimsIdentity identity = await userManager.CreateIdentityAsync(usuario, context.Options.AuthenticationType);

            //identity.AddClaim(new Claim(ClaimTypes.Country, "Brasil"));
            //identity.AddClaim(new Claim(ClaimTypes.Role, "Administrador"));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Country, "Brasil"),
                new Claim(ClaimTypes.Role, "Administrador")
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, context.Options.AuthenticationType);

            var tichet = new AuthenticationTicket(identity, GetProperties(identity.Claims));

            context.Validated(tichet);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            return Task.FromResult<object>(null);
        }

        private static AuthenticationProperties GetProperties(IEnumerable<Claim> claims)
        {
            IDictionary<string, string> data = new Dictionary<string, string>();
            data.Add(new KeyValuePair<string, string>("claims", string.Join(",", claims)));

            return new AuthenticationProperties(data);
        }
    }
}