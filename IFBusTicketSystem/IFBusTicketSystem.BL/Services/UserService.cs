using System;
using IFBusTicketSystem.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFBusTicketSystem.Auth;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.BL.Validators;
using IFBusTicketSystem.Foundation.Constants;
using IFBusTicketSystem.Foundation.Exceptions;
using IFBusTicketSystem.Foundation.Types;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using NLog;

namespace IFBusTicketSystem.BL.Services
{
    public class UserService : IUserService
    {
        private readonly Logger _logger;

        [Dependency]
        public IUserRepository Users { get; set; }
        [Dependency]
        public IValidationService ValidationService { get; set; }

        public UserService()
        {
            _logger = LogManager.GetLogger(LogHelper.LoggerName);
        }

        public async Task<bool> RegisterUserAsync(RegisterUserCommand command)
        {
            ValidationService.Validate(command, new RegisterUserCommandValidator()); 
            
            var user = new UserInfo
            {
                UserName = command.Login,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Sex = command.Sex
            };
            
            var userCreated = Users.Register(user, command.Password);

            var result = await userCreated;

            if (!result.Succeeded)
            {
                _logger.Error(result.Errors);

                throw new ApplicationException("Error happened during registration. Try one more time.");
            }

            _logger.Info($"User '{command.Login}' has just registered");

            return true;
        }

        public async Task<RegisterExternalUserResult> RegisterExternalUserAsync(RegisterExternalUserCommand command)
        {
            ValidationService.Validate(command, new RegisterExternalUserCommandValidator());

            var verifiedAccessToken = await AuthUtility.VerifyExternalAccessToken(command.Provider, command.AccessToken);

            var loginInfo = new UserLoginInfo(command.Provider, verifiedAccessToken.UserId);

            if (await Users.FindUserAsync(loginInfo) != null)
                throw new BadRequestException("External user is already registered");

            var user = new UserInfo
            {
                UserName = command.UserName
            };

            Users.Create(user);

            return new RegisterExternalUserResult
            {
                IdentityResult = await Users.AddLoginAsync(user.Id, loginInfo),
                LocalAccessToken = AuthUtility.GenerateLocalAccessTokenResponse(command.UserName)
            };
        }

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

        public UserDataWithOrders GetUserData(GetUserDataQuery query)
        {
            ValidationService.Validate(query, new GetUserDataQueryValidator());

            var userData = Users.GetUserDataWithOrders(query.UserId);

            ValidationService.Validate(userData, new UserDataWithOrdersValidator());

            return userData;
        }
    }
}
