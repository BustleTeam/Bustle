using System;
using System.Linq;
using System.Threading.Tasks;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class UserRepository : Repository<UserInfo>, IUserRepository
    {
        private readonly UserManager<UserInfo> _userManager;

        public UserRepository(UserManager<UserInfo> userManager)
        {
            _userManager = userManager;
                //new UserManager<UserInfo>(new UserStore<UserInfo>(Session));
        }

        public async Task<IdentityResult> Register(UserInfo user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<UserInfo> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public UserDataWithOrders GetUserDataWithOrders(string userId)
        {
            var user = _userManager.FindById(userId);
            var orders = Session.QueryOver<Ticket>().Where(_ => _.Passenger.Id == userId).List();

            return new UserDataWithOrders
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Sex = user.Sex,
                //Orders = orders.ToList()
            };
        }
    }
}
