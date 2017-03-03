using System;
using System.Threading.Tasks;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository, IDisposable
    {
        private readonly UserManager<User> _userManager;

        public UserRepository()
        {
            _userManager = new UserManager<User>(new UserStore<User>(Session));
        }

        public async Task<IdentityResult> Register(User user)
        {
            return await _userManager.CreateAsync(user, string.Empty);
        }

        public async Task<User> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}
