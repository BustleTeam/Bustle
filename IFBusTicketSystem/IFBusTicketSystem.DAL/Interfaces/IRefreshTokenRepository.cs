using System.Threading.Tasks;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.DAL.Interfaces
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        bool AddRefreshToken(RefreshToken token);
    }
}
