using System.Security.Claims;

namespace Rabbit.Owin.Security.Impl
{
    /// <summary>
    /// This parser does nothing, just to handle the un-supported providers
    /// </summary>
    internal sealed class DefaultParser : IExternalLoginDataParser
    {
        public void Parse(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
        }
    }
}