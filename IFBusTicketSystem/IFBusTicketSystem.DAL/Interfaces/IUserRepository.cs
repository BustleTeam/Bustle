using System.Threading.Tasks;
using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.AspNet.Identity;

namespace IFBusTicketSystem.DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserInfo>
    {
        Task<IdentityResult> Register(UserInfo user, string password);
        Task<IdentityResult> RegisterAsync(UserInfo user);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo loginInfo);

        Task<UserInfo> FindUser(string userName, string password);
        Task<UserInfo> FindUserAsync(UserLoginInfo loginInfo);

        UserDataWithOrders GetUserDataWithOrders(string userId);
    }
}
