using System.Security.Claims;
using IFBusTicketSystem.Foundation.Types;
using Microsoft.AspNet.Identity;

namespace IFBusTicketSystem.Foundation.Helpers
{
    public static class TypesConverter
    {
        public static ExternalLoginData ToExternalLoginData(this ClaimsIdentity identity)
        {
            var providerKeyClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(providerKeyClaim?.Issuer) || string.IsNullOrEmpty(providerKeyClaim.Value))
                return null;

            if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                return null;

            return new ExternalLoginData
            {
                LoginProvider = providerKeyClaim.Issuer,
                ProviderKey = providerKeyClaim.Value,
                UserName = identity.FindFirstValue(ClaimTypes.Name),
                ExternalAccessToken = identity.FindFirstValue("ExternalAccessToken")
            };
        }
    }
}
