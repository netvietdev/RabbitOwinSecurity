using System.Security.Claims;

namespace Rabbit.Owin.Security
{
    public interface IExternalLoginDataParser
    {
        void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData);
    }
}