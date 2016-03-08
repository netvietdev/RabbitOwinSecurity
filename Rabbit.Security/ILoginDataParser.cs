using System.Security.Claims;

namespace Rabbit.Owin.Security
{
    public interface ILoginDataParser
    {
        ExternalLoginData Parse(ClaimsIdentity identity);
    }
}
