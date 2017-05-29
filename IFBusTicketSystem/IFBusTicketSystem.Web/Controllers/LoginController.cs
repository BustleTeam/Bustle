using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.Helpers;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Web.Filters;
using IFBusTicketSystem.Web.TransferObjects;
using IFBusTicketSystem.Web.TransferObjects.Results;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;

namespace IFBusTicketSystem.Web.Controllers
{
  [CheckException]
  [RoutePrefix("api/login")]
  public class LoginController : ApiController
  {
    [Dependency]
    public IAccountService AccountService { get; set; }

      [OverrideAuthentication]
      [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
      [AllowAnonymous]
      [HttpGet]
      [Route("ExternalLogin", Name = "ExternalLogin")]
      public async Task<IHttpActionResult> GetExternalLogin(string provider)
      {
          //if (getExternalLogin.Error != null)
          //  return BadRequest(Uri.EscapeDataString(getExternalLogin.Error));

          if (!User.Identity.IsAuthenticated)
            return new ChallengeResult(provider, this);

          var query = new GetRedirectUriQuery
          {
              QueryStrings = Request.GetQueryNameValuePairs().ToList(),
              Identity = User.Identity as ClaimsIdentity,
              Provider = provider
          };

          var redirectUriResult =  await AccountService.GetRedirectUriAsync(query);

          redirectUriResult.CheckIfNull();

          var redirectUriValidationResult = redirectUriResult.Item1;
          var redirectUriResultText = redirectUriResult.Item2;
        
          if (!redirectUriValidationResult)
              return BadRequest(redirectUriResultText);

          if (string.IsNullOrWhiteSpace(redirectUriResultText))
            return new ChallengeResult(provider, this);

          return Redirect(redirectUriResultText);
      }

      [AllowAnonymous]
      [HttpGet]
      [Route("ObtainLocalAccessToken")]
      public async Task<IHttpActionResult> ObtainLocalAccessToken(ObtainLocalAccessTokenDTO dto)
      {
          var command = new ObtainLocalAccessTokenCommand
          {
              Provider = dto.Provider,
              ExternalAccessToken = dto.ExternalAccessToken
          };

          var result = await AccountService.ObtainLocalAccessToken(command);

          if (result == null)
          {
              return InternalServerError();
          }

          return Ok(result);
      }

  }
}