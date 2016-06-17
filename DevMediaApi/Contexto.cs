using Microsoft.AspNet.Identity.EntityFramework;

namespace DevMediaApi
{
    public class Contexto : IdentityDbContext<IdentityUser>
    {
        public Contexto()
            : base(@"Server=.\SQLExpress;Integrated Security=True; Initial Catalog=DeviMediaClaims; Connect Timeout=15;
                              Encrypt=False;TrustServerCertificate=False")
        { }

        public static Contexto Create()
        {
            return new Contexto();
        }
    }
}