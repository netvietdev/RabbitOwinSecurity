using System;

namespace Rabbit.Security.Customs
{
    public class ExternalLoginDataParserFactory
    {
        public IExternalLoginDataParser Create(string providerName)
        {
            Providers provider;

            if (!Enum.TryParse(providerName, out provider))
            {
                throw new InvalidOperationException("Invalid provider: " + provider);
            }

            switch (provider)
            {
                case Providers.Facebook:
                    return new FacebookClaimsParser();
                case Providers.Google:
                    return new GoogleClaimsParser();
                case Providers.LinkedIn:
                    return new LinkedInClaimsParser();
                case Providers.GitHub:
                    return new GitHubClaimsParser();
                case Providers.Twitter:
                    return new TwitterClaimsParser();
            }

            throw new NotImplementedException("Not implemented for provider: " + provider);
        }
    }
}
