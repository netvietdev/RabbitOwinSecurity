using System.Security.Claims;

namespace Rabbit.Owin.Security.Impl
{
    public class TwitterClaimsParser : IExternalLoginDataParser
    {
        public void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
            loginData.Profile = string.Format("https://twitter.com/{0}", loginData.UserName);
        }
    }
}