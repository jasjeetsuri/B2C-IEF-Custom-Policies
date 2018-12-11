using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace B2CPolicyManager
{
    class AuthenticationHelper
    {
        public static string[] Scopes = { "User.Read" };

        public static PublicClientApplication IdentityClientApp = new PublicClientApplication(Properties.Settings.Default.V2AppId);
        public static string TokenForUser = null;
        public static DateTimeOffset Expiration;

        /// <summary>
        /// Get Token for User.
        /// </summary>
        /// <returns>Token for user.</returns>
        public static async Task<string> GetTokenForUserAsync()
        {
            AuthenticationResult authResult;
            try
            {
                authResult = await IdentityClientApp.AcquireTokenSilentAsync(Scopes, IdentityClientApp.Users.First());
                TokenForUser = authResult.AccessToken;
            }

            catch (Exception)
            {
                if (TokenForUser == null || Expiration <= DateTimeOffset.UtcNow.AddMinutes(5))
                {
                    try
                    {
                        authResult = await IdentityClientApp.AcquireTokenAsync(Scopes);

                        TokenForUser = authResult.AccessToken;
                        Expiration = authResult.ExpiresOn;
                    }
                    catch
                    {
                        return TokenForUser;
                    }
                }
            }

            return TokenForUser;
        }

        public static void AddHeaders(HttpRequestMessage requestMessage)
        {
            if (TokenForUser == null)
            {
                Debug.WriteLine("Call GetAuthenticatedClientForUser first");
            }

            try
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", TokenForUser);
                requestMessage.Headers.Add("SampleID", "console-csharp-trustframeworkpolicy");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not add headers to HttpRequestMessage: " + ex.Message);
            }
        }

    }
}
