using System.Collections.Generic;
using System.Security.Claims;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
  public class GetRedirectUriQuery
  {
        public List<KeyValuePair<string, string>> QueryStrings { get; set; }
        public ClaimsIdentity Identity { get; set; }
        public string Provider { get; set; }
    }
}
