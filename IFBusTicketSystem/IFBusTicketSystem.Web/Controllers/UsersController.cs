using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using IFBusTicketSystem.Web.TransferObjects;
using IFBusTicketSystem.Web.TransferObjects.Mapping;
using Microsoft.Practices.Unity;
using System.Web.Http;
using IFBusTicketSystem.Web.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IFBusTicketSystem.Foundation.Types;
using Microsoft.AspNet.Identity;

namespace IFBusTicketSystem.Web.Controllers
{
    [CheckException]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> RegisterAsync([FromBody] RegisterUserDTO registerUserDto)
        {
          var command = MappingProfile.Mapper.Map<RegisterUserDTO, RegisterUserCommand>(registerUserDto);

          await UserService.RegisterUserAsync(command);

          return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternalAsync(RegisterExternalBindingDTO dto)
        {

            var result = await UserService.RegisterExternalUserAsync(new RegisterExternalUserCommand
            {
                AccessToken = dto.ExternalAccessToken,
                Provider = dto.Provider,
                UserName = dto.UserName
            });

            if (!result.IdentityResult.Succeeded)
              return GetErrorResult(result.IdentityResult);
            
            return Ok(result.LocalAccessToken);
        }

        public IHttpActionResult GetAll()
        {
            var users = UserService.GetAllUsers();
            return users != null ? Ok(MappingProfile.Mapper.Map<IEnumerable<UserInfo>, IEnumerable<UserDTO>>(users)) 
                : (IHttpActionResult)NotFound();
        }

        [Authorize]
        [HttpGet]
        [Route("UserData")]
        public IHttpActionResult GetUserInfo()
        {
            var identity = User.Identity as ClaimsIdentity;

            if (identity == null)
                return InternalServerError();

            var userId = identity.Claims.First(_ => _.Type == "userId").Value;

            var userData = UserService.GetUserData(new GetUserDataQuery{ UserId = userId });

            return Ok(MappingProfile.Mapper.Map<UserDataWithOrders, UserDataDTO>(userData));
        }

        [Route("{id:int:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            var query = new EntityBaseQuery(id);
            var user = UserService.GetUserById(query);
            return user != null ? Ok(MappingProfile.Mapper.Map<UserInfo, UserDTO>(user)) 
                : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]UserDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var query = new UserBaseQuery(MappingProfile.Mapper.Map<UserDTO, UserInfo>(user));
            UserService.CreateUser(query);
            return Ok();
        }

        [HttpPut]
        [Route("users/{id:int:min(1)}")]
        public IHttpActionResult Update(int id, [FromBody]UserDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var query = new UserBaseQuery(id, MappingProfile.Mapper.Map<UserDTO, UserInfo>(user));
            UserService.UpdateUser(query);
            return Ok();
        }

        [Route("users/{id:int:min(1)}")]
        public IHttpActionResult Delete(int id)
        {
            var query = new EntityBaseQuery(id);
            UserService.DeleteUser(query);
            return Ok();
        }

      private IHttpActionResult GetErrorResult(IdentityResult result)
      {
        if (result == null)
        {
          return InternalServerError();
        }

        if (!result.Succeeded)
        {
          if (result.Errors != null)
          {
            foreach (var error in result.Errors)
            {
              ModelState.AddModelError("", error);
            }
          }

          if (ModelState.IsValid)
          {
            // No ModelState errors are available to send, so just return an empty BadRequest.
            return BadRequest();
          }

          return BadRequest(ModelState);
        }

        return null;
      }
  }
}
