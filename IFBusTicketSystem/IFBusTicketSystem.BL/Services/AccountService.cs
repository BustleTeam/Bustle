using System;
using System.Threading.Tasks;
using IFBusTicketSystem.Auth;
using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.BL.Validators;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Helpers;
using IFBusTicketSystem.Foundation.RequestEntities;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;

namespace IFBusTicketSystem.BL.Services
{
  public class AccountService : IAccountService
  {
        [Dependency]
        public IClientRepository ClientRepository { get; set; }
        [Dependency]
        public IUserRepository UserRepository { get; set; }
        [Dependency]
        public IValidationService ValidationService { get; set; }
         
        public async Task<Tuple<bool, string>> GetRedirectUriAsync(GetRedirectUriQuery query)
        {
            ValidationService.Validate(query, new GetRedirectUriQueryValidator());

            var redirectUri = string.Empty;

            var redirectUriValidationResult =
                AuthUtility.ValidateClientAndRedirectUri(query.QueryStrings, ClientRepository, ref redirectUri);

            if (!string.IsNullOrWhiteSpace(redirectUriValidationResult))
                return new Tuple<bool, string>(false, redirectUriValidationResult);

            var externalLogin = query.Identity.ToExternalLoginData();

            externalLogin.CheckIfNull();

            if (externalLogin.LoginProvider != query.Provider)
                return new Tuple<bool, string>(true, null);

            var user = await UserRepository.FindUserAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

            var hasRegistered = user != null;

            return
                new Tuple<bool, string>(
                    true,
                    $"{redirectUri}#external_access_token={externalLogin.ExternalAccessToken}&provider={externalLogin.LoginProvider}&haslocalaccount={hasRegistered}&external_user_name={externalLogin.UserName}");
        }

        public async Task<JObject> ObtainLocalAccessToken(ObtainLocalAccessTokenCommand command)
        {
            ValidationService.Validate(command, new ObtainLocalAccessTokenCommandValidator());

            var verifiedAccessToken = await AuthUtility.VerifyExternalAccessToken(command.Provider, command.ExternalAccessToken);

            verifiedAccessToken.CheckIfNull("Invalid Provider or External Access Token");

            var user = await UserRepository.FindUserAsync(new UserLoginInfo(command.Provider, verifiedAccessToken.UserId));

            user.CheckIfNull("External user is not registered");

            //generate access token response
            var accessTokenResponse = AuthUtility.GenerateLocalAccessTokenResponse(user.UserName);

            return accessTokenResponse;
        }
    }   
}
