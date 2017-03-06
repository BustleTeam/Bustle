using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class UserBaseQuery : EntityBaseQuery
    {
        public UserInfo User { get; set; }

        public UserBaseQuery(int id, UserInfo user) : base(id)
        {
            User = user;
        }

        public UserBaseQuery(UserInfo user)
        {
            User = user;
        }
    }
}
