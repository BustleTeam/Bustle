using System.Threading.Tasks;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.AspNet.Identity;

namespace IFBusTicketSystem.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IdentityResult> Register(User user);
        Task<User> FindUser(string userName, string password);
    }
}
