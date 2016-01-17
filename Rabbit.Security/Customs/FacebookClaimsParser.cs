using System.Security.Claims;

namespace Rabbit.Security.Customs
{
    public class FacebookClaimsParser : IExternalLoginDataParser
    {
        public void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
            loginData.Profile = "https://www.facebook.com/" + loginData.ProviderKey;
            loginData.Properties.Add(Claims.ExternalExpiresIn, identity.FindFirst(Claims.ExternalExpiresIn).Value);
        }
    }
}