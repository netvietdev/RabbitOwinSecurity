namespace Rabbit.Owin.Security.Impl
{
    class ExternalLoginDataParserFactory
    {
        public IExternalLoginDataParser Create(string providerName)
        {
            switch (providerName)
            {
                case OAuthProviders.Facebook:
                    return new FacebookClaimsParser();
                case OAuthProviders.Google:
                    return new GoogleClaimsParser();
                case OAuthProviders.LinkedIn:
                    return new LinkedInClaimsParser();
                case OAuthProviders.GitHub:
                    return new GitHubClaimsParser();
                case OAuthProviders.Twitter:
                    return new TwitterClaimsParser();
            }

            return new DefaultParser();
        }
    }
}
