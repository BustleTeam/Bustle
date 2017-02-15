using IFBusTicketSystem.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.DAL;
using Microsoft.Practices.Unity;

namespace IFBusTicketSystem.BL.Services
{
    public class UserService : IUserService
    {
        [Dependency]
        public UnitOfWork UnitOfWork { get; set; }

        public void CreateUser(UserBaseQuery query)
        {
            if (query.User != null)
            {
                UnitOfWork.BeginTransaction();
                UnitOfWork.Users.Create(query.User);
                UnitOfWork.Commit();
            }
        }

        public void DeleteUser(EntityBaseQuery query)
        {
            if(query.Id > 0)
            {               
                var user = UnitOfWork.Users.GetById(query.Id);
                if (user != null)
                {
                    UnitOfWork.BeginTransaction();
                    UnitOfWork.Users.Delete(query.Id);
                    UnitOfWork.Commit();
                }                             
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = UnitOfWork.Users.GetAll().ToList();
            return users;

        }

        public User GetUserById(EntityBaseQuery query)
        {
            var user = UnitOfWork.Users.GetById(query.Id);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public void UpdateUser(UserBaseQuery query)
        {
            if(query.User != null)
            {               
                var user = UnitOfWork.Users.GetById(query.Id);
                if (user != null)
                {
                    UnitOfWork.BeginTransaction();
                    UnitOfWork.Users.Update(query.User);
                    UnitOfWork.Commit();
                }             
            }
        }
    }
}
