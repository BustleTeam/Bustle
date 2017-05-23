using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;

namespace IFBusTicketSystem.Foundation.Types
{
    public class RegisterExternalUserResult
    {
        public IdentityResult IdentityResult { get; set; }
        public JObject LocalAccessToken { get; set; }
    }
}
