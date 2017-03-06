using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using IFBusTicketSystem.Web.TransferObjects;
using IFBusTicketSystem.Web.TransferObjects.Mapping;
using Microsoft.Practices.Unity;
using System.Web.Http;
using IFBusTicketSystem.Web.Filters;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.Controllers
{
    [CheckException]
    public class UsersController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        public IHttpActionResult GetAll()
        {
            var users = UserService.GetAllUsers();
            return users != null ? Ok(MappingProfile.Mapper.Map<IEnumerable<UserInfo>, IEnumerable<UserDTO>>(users)) 
                : (IHttpActionResult)NotFound();
        }

        [Route("users/{id:int:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            var query = new EntityBaseQuery(id);
            var user = UserService.GetUserById(query);
            return user != null ? Ok(MappingProfile.Mapper.Map<UserInfo, UserDTO>(user)) 
                : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        [Route("")]
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
    }
}
