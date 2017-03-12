using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface IUserService
    {
        UserInfo GetUserById(EntityBaseQuery query);
        IEnumerable<UserInfo> GetAllUsers();
        void CreateUser(UserBaseQuery query);
        void UpdateUser(UserBaseQuery query);
        void DeleteUser(EntityBaseQuery query);

        UserDataWithOrders GetUserData(GetUserDataQuery query);
    }
}
