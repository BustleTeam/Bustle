using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IFBusTicketSystem.Auth.Helpers;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Constants;
using IFBusTicketSystem.Foundation.Types;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;

namespace IFBusTicketSystem.Auth
{
  public static class AuthUtility
  {
          public static string ValidateClientAndRedirectUri(IEnumerable<KeyValuePair<string, string>> queryStrings, IClientRepository clientRepository, ref string redirectUriOutput)
          {
              Uri redirectUri;

              var redirectUriString = GetQueryString("redirect_uri", queryStrings);

              if (string.IsNullOrWhiteSpace(redirectUriString))
                  return "redirect_uri is required";

              var validUri = Uri.TryCreate(redirectUriString, UriKind.Absolute, out redirectUri);

              if (!validUri)
                  return "redirect_uri is invalid";

              var clientId = GetQueryString("client_id", queryStrings);

              if (string.IsNullOrWhiteSpace(clientId))
                  return "client_Id is required";

              var client = clientRepository.GetSingle(_=>_.Id==clientId);

              if (client == null)
                  return $"Client_id '{clientId}' is not registered in the system.";

              if (!string.Equals(client.AllowedOrigin, redirectUri.GetLeftPart(UriPartial.Authority), StringComparison.OrdinalIgnoreCase))
                  return $"The given URL is not allowed by Client_id '{clientId}' configuration.";

              redirectUriOutput = redirectUri.AbsoluteUri;

              return string.Empty;
          }

         public static async Task<ParsedExternalAccessToken> VerifyExternalAccessToken(string provider, string accessToken)
         {   
              ParsedExternalAccessToken parsedToken = null;

              string verifyTokenEndPoint;

              //if (provider == "Facebook")
              //{
              //    //You can get it from here: https://developers.facebook.com/tools/accesstoken/
              //    //More about debug_tokn here: http://stackoverflow.com/questions/16641083/how-does-one-get-the-app-access-token-for-debug-token-inspection-on-facebook

              //    var appToken = "xxxxx";
              //    verifyTokenEndPoint = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token={1}", accessToken, appToken);
              //}

              if (provider == ExternalProviders.Google)
                  verifyTokenEndPoint = $"https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={accessToken}";
              else
                  return null;

              var client = new HttpClient();
              var uri = new Uri(verifyTokenEndPoint);
              var response = await client.GetAsync(uri);

              if (response.IsSuccessStatusCode)
              {
                  var content = await response.Content.ReadAsStringAsync();

                  dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                  parsedToken = new ParsedExternalAccessToken();

                  //if (provider == "Facebook")
                  //{
                  //    parsedToken.user_id = jObj["data"]["user_id"];
                  //    parsedToken.app_id = jObj["data"]["app_id"];

                  //    if (!string.Equals(Startup.facebookAuthOptions.AppId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                  //    {
                  //        return null;
                  //    }
                  //}

                  if (provider == ExternalProviders.Google)
                  {
                      parsedToken.UserId = jObj["user_id"];
                      parsedToken.AppId = jObj["audience"];

                      if (!string.Equals(OAuthHelper.GetGoogleOAuthOptions().ClientId, parsedToken.AppId, StringComparison.OrdinalIgnoreCase))
                          return null;
                  }
              }

              return parsedToken;
        }     

        public static JObject GenerateLocalAccessTokenResponse(string userName)
        {     
              var tokenExpiration = TimeSpan.FromDays(1);

              var identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

              identity.AddClaim(new Claim(ClaimTypes.Name, userName));
              identity.AddClaim(new Claim("role", "user"));

              var props = new AuthenticationProperties
              {
                  IssuedUtc = DateTime.UtcNow,
                  ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
              };

              var ticket = new AuthenticationTicket(identity, props);

              var accessToken = OAuthHelper.GetOAuthServerOptions().AccessTokenFormat.Protect(ticket);

              var tokenResponse = new JObject(
                  new JProperty("userName", userName),
                  new JProperty("access_token", accessToken),
                  new JProperty("token_type", "bearer"),
                  new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString(CultureInfo.InvariantCulture)),
                  new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                  new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
              );

              return tokenResponse;
        }

        private static string GetQueryString(string key, IEnumerable<KeyValuePair<string, string>> queryStrings)
        {
              if (queryStrings == null) return null;

              var match = queryStrings.FirstOrDefault(keyValue => string.Compare(keyValue.Key, key, StringComparison.OrdinalIgnoreCase) == 0);

              return string.IsNullOrEmpty(match.Value) ? null : match.Value;
        }
    }
}
