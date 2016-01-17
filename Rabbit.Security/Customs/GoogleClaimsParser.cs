using System.Security.Claims;

namespace Rabbit.Security.Customs
{
    public class GoogleClaimsParser : IExternalLoginDataParser
    {
        public void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
            loginData.Profile = identity.GetFirstOrDefault("urn:google:profile");
        }
    }
}