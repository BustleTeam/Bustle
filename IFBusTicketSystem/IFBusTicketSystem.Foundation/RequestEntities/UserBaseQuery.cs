using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class UserBaseQuery : EntityBaseQuery
    {
        public User User { get; set; }

        public UserBaseQuery(int id, User user) : base(id)
        {
            User = user;
        }

        public UserBaseQuery(User user)
        {
            User = user;
        }
    }
}
