using System.Security.Claims;

namespace Rabbit.Security.Customs
{
    public class LinkedInClaimsParser : IExternalLoginDataParser
    {
        public void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
            loginData.Profile = identity.GetFirstOrDefault("urn:linkedin:url");
            loginData.Name = identity.GetFirstOrDefault("urn:linkedin:name");
        }
    }
}