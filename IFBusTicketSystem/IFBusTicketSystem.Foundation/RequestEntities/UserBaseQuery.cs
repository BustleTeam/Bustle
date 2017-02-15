using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class UserBaseQuery : EntityBaseQuery
    {
        public User User { get; set; }
    }
}
