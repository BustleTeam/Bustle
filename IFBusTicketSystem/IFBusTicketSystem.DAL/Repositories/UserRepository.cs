using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types;
using NHibernate;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ISession session)
            : base(session)
        {
        }
    }
}
