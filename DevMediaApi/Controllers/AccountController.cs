using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DevMediaApi.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Create()
        {
            HttpResponseMessage response;

            try
            {
                var usuario = new IdentityUser
                {
                    UserName = "ffonseca"
                };

                var userManager = Request.GetOwinContext().GetUserManager<AppUserManager>();

                IdentityResult result = await userManager.CreateAsync(usuario, "123Tr0car@@");

                string resultado;

                if (result.Succeeded)
                {
                    resultado = "Usuario Criado com sucesso";
                }
                else
                {
                    resultado = string.Join(",", result.Errors);
                }

                response = Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return await Task.FromResult(response);
        }
    }
}
