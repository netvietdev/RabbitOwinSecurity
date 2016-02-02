using System.Security.Claims;

namespace Rabbit.Security.Impl
{
    public class GoogleClaimsParser : IExternalLoginDataParser
    {
        public void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
            loginData.Profile = identity.GetFirstOrDefault("urn:google:profile");
        }
    }
}