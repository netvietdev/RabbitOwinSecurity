using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Twitter;
using Owin;
using Owin.Security.Providers.GitHub;
using Owin.Security.Providers.LinkedIn;
using Owin.Security.Providers.Yahoo;
using Rabbit.Foundation.Data;
using System.Collections.Generic;

namespace Rabbit.Owin.Security
{
    public static class OAuthRegistrationExtensions
    {
        /// <summary>
        /// Register all oauth providers
        /// </summary>
        /// <param name="appBuilder"></param>
        /// <param name="appSettings">Key = Provider, Value = ClientId/ClientSecret</param>
        public static void RegisterOAuthProviders(this IAppBuilder appBuilder, IList<DataItem> appSettings)
        {
            foreach (var oauthProvider in appSettings)
            {
                var keysInfo = oauthProvider.Value.Split('/');

                if (oauthProvider.Key.EndsWith(OAuthProviders.LinkedIn))
                {
                    appBuilder.UseLinkedInAuthentication(new LinkedInAuthenticationOptions()
                    {
                        ClientId = keysInfo[0],
                        ClientSecret = keysInfo[1]
                    });
                }
                else if (oauthProvider.Key.EndsWith(OAuthProviders.GitHub))
                {
                    appBuilder.UseGitHubAuthentication(new GitHubAuthenticationOptions()
                    {
                        ClientId = keysInfo[0],
                        ClientSecret = keysInfo[1],
                    });
                }
                else if (oauthProvider.Key.EndsWith(OAuthProviders.Google))
                {
                    appBuilder.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
                    {
                        ClientId = keysInfo[0],
                        ClientSecret = keysInfo[1],
                    });
                }
                else if (oauthProvider.Key.EndsWith(OAuthProviders.Yahoo))
                {
                    appBuilder.UseYahooAuthentication(new YahooAuthenticationOptions()
                    {
                        ConsumerKey = keysInfo[0],
                        ConsumerSecret = keysInfo[1]
                    });
                }
                else if (oauthProvider.Key.EndsWith(OAuthProviders.Facebook))
                {
                    appBuilder.UseFacebookAuthentication(new FacebookAuthenticationOptions()
                    {
                        AppId = keysInfo[0],
                        AppSecret = keysInfo[1]
                    });
                }
                else if (oauthProvider.Key.EndsWith(OAuthProviders.Twitter))
                {
                    appBuilder.UseTwitterAuthentication(new TwitterAuthenticationOptions()
                    {
                        ConsumerKey = keysInfo[0],
                        ConsumerSecret = keysInfo[1],
                        BackchannelCertificateValidator = new CertificateSubjectKeyIdentifierValidator(new string[]
                        {
                            "A5EF0B11CEC04103A34A659048B21CE0572D7D47", // VeriSign Class 3 Secure Server CA - G2
                            "0D445C165344C1827E1D20AB25F40163D8BE79A5", // VeriSign Class 3 Secure Server CA - G3
                            "7FD365A7C2DDECBBF03009F34339FA02AF333133", // VeriSign Class 3 Public Primary Certification Authority - G5
                            "39A55D933676616E73A761DFA16A7E59CDE66FAD", // Symantec Class 3 Secure Server CA - G4
                            "‎add53f6680fe66e383cbac3e60922e3b4c412bed", // Symantec Class 3 EV SSL CA - G3
                            "4eb6d578499b1ccf5f581ead56be3d9b6744a5e5", // VeriSign Class 3 Primary CA - G5
                            "5168FF90AF0207753CCCD9656462A212B859723B", // DigiCert SHA2 High Assurance Server C‎A 
                            "B13EC36903F8BF4701D498261A0802EF63642BC3" // DigiCert High Assurance EV Root CA
                        })
                    });
                }
            }
        }
    }
}