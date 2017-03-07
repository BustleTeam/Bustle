using System;
using System.Threading.Tasks;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class UserRepository : Repository<UserInfo>, IUserRepository
        //, IDisposable
    {
        //private readonly UserManager<UserInfo> _userManager;

        //public UserRepository()
        //{
        //    _userManager = new UserManager<UserInfo>(new UserStore<UserInfo>(Session));
        //}

        //public async Task<IdentityResult> Register(UserInfo user, string password)
        //{
        //    return await _userManager.CreateAsync(user, password);
        //}

        //public async Task<UserInfo> FindUser(string userName, string password)
        //{
        //    var user = await _userManager.FindAsync(userName, password);

        //    return user;
        //}

        //public void Dispose()
        //{
        //    _userManager.Dispose();
        //}
    }
}
