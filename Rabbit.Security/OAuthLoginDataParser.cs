using System;
using System.Security.Claims;
using Rabbit.Security.Customs;

namespace Rabbit.Security
{
    public class OAuthLoginDataParser : ILoginDataParser
    {
        public ExternalLoginData Parse(ClaimsIdentity identity)
        {
            if (identity == null)
            {
                return null;
            }

            var nameClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            if (nameClaim == null || String.IsNullOrEmpty(nameClaim.Issuer) || String.IsNullOrEmpty(nameClaim.Value))
            {
                throw new ApplicationException("Cannot find a claim of ClaimTypes.NameIdentifier");
            }

            if (nameClaim.Issuer == ClaimsIdentity.DefaultIssuer)
            {
                return null;
            }

            var loginData = new ExternalLoginData
                {
                    ProviderName = nameClaim.Issuer,
                    ProviderKey = nameClaim.Value,
                    Name = identity.GetFirstOrDefault(ClaimTypes.Name),
                    Email = identity.GetFirstOrDefault(ClaimTypes.Email),
                };

            ParseDetailLoginData(identity, ref loginData);

            return loginData;
        }

        private void ParseDetailLoginData(ClaimsIdentity identity, ref ExternalLoginData loginData)
        {
            var detailParserFactory = new ExternalLoginDataParserFactory();
            var detailParser = detailParserFactory.Create(loginData.ProviderName);
            detailParser.Parse(identity, ref loginData);
        }
    }
}
