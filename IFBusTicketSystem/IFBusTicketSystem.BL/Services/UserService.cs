using IFBusTicketSystem.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.BL.Validators;

namespace IFBusTicketSystem.BL.Services
{
    public class UserService : IUserService
    {
        [Dependency]
        public IUserRepository Users { get; set; }
        [Dependency]
        public IValidationService ValidationService { get; set; }

        public void CreateUser(UserBaseQuery query)
        {
            ValidationService.Validate(query, new UserBaseQueryValidator());
            Users.Create(query.User);
        }

        public void DeleteUser(EntityBaseQuery query)
        {
            ValidationService.Validate(query, new EntityBaseQueryValidator());
            var user = Users.GetById(query.Id);
            if (user != null)
            {
                Users.Delete(query.Id);
            }
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return Users.GetAll().ToList();
        }

        public UserInfo GetUserById(EntityBaseQuery query)
        {
            ValidationService.Validate(query, new EntityBaseQueryValidator());
            return Users.GetById(query.Id);
        }

        public void UpdateUser(UserBaseQuery query)
        {
            ValidationService.Validate(query, new UserBaseQueryValidator());
            var user = Users.GetById(query.Id);
            if (user != null)
            {
                Users.Update(query.User);
            }
        }
    }
}
