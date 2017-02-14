using IFBusTicketSystem.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.DAL;

namespace IFBusTicketSystem.BL.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void CreateUser(UserBaseQuery query)
        {
            if (query.User != null)
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.Users.Create(query.User);
                _unitOfWork.Commit();
            }
        }

        public void DeleteUser(EntityBaseQuery query)
        {
            if(query.Id > 0)
            {               
                var user = _unitOfWork.Users.GetById(query.Id);
                if (user != null)
                {
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.Users.Delete(query.Id);
                    _unitOfWork.Commit();
                }                             
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _unitOfWork.Users.GetAll().ToList();
            return users;

        }

        public User GetUserById(EntityBaseQuery query)
        {
            var user = _unitOfWork.Users.GetById(query.Id);
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
                var user = _unitOfWork.Users.GetById(query.Id);
                if (user != null)
                {
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.Users.Update(query.User);
                    _unitOfWork.Commit();
                }             
            }
        }
    }
}
