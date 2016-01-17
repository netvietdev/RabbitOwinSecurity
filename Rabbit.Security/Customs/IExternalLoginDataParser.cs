using System.Security.Claims;

namespace Rabbit.Security.Customs
{
    public interface IExternalLoginDataParser
    {
        void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData);
    }
}