using System.Security.Claims;

namespace Rabbit.Security.Impl
{
    public class FacebookClaimsParser : IExternalLoginDataParser
    {
        public void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
            loginData.Profile = "https://www.facebook.com/" + loginData.ProviderKey;
        }
    }
}
