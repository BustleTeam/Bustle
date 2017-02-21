using IFBusTicketSystem.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;

namespace IFBusTicketSystem.BL.Services
{
    public class UserService : IUserService
    {
        [Dependency]
        public IUserRepository Users { get; set; }

        public void CreateUser(UserBaseQuery query)
        {
            if (query.User != null)
            {
                Users.Create(query.User);
            }
        }

        public void DeleteUser(EntityBaseQuery query)
        {
            if(query.Id > 0)
            {               
                var user = Users.GetById(query.Id);
                if (user != null)
                {
                    Users.Delete(query.Id);
                }                             
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Users.GetAll().ToList();
        }

        public User GetUserById(EntityBaseQuery query)
        {
            return Users.GetById(query.Id);
        }

        public void UpdateUser(UserBaseQuery query)
        {
            if(query.User != null)
            {               
                var user = Users.GetById(query.Id);
                if (user != null)
                {
                    Users.Update(query.User);
                }             
            }
        }
    }
}
