using System;
using System.Threading.Tasks;
using IFBusTicketSystem.Foundation.RequestEntities;
using Newtonsoft.Json.Linq;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface IAccountService
    {
        Task<Tuple<bool, string>> GetRedirectUriAsync(GetRedirectUriQuery query);

        Task<JObject> ObtainLocalAccessToken(ObtainLocalAccessTokenCommand command);
    }
}
