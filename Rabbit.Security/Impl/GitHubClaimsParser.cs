using System.Security.Claims;

namespace Rabbit.Owin.Security.Impl
{
    public class GitHubClaimsParser : IExternalLoginDataParser
    {
        public void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
            loginData.Profile = identity.GetFirstOrDefault("urn:github:url");
            loginData.UserName = identity.GetFirstOrDefault(ClaimTypes.Name);
            loginData.Name = identity.GetFirstOrDefault("urn:github:name");
        }
    }
}