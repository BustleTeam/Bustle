using System.Threading.Tasks;
using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.AspNet.Identity;

namespace IFBusTicketSystem.DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserInfo>
    {
        Task<IdentityResult> Register(UserInfo user, string password);
        Task<UserInfo> FindUser(string userName, string password);

        UserDataWithOrders GetUserDataWithOrders(string userId);
    }
}
