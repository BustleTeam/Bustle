﻿using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using IFBusTicketSystem.Web.TransferObjects;
using IFBusTicketSystem.Web.TransferObjects.Converters;
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
            return users != null ? Ok(MappingProfile.Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users)) 
                : (IHttpActionResult)NotFound();
        }

        public IHttpActionResult GetById(int id)
        {
            var query = new EntityBaseQuery(id);
            var user = UserService.GetUserById(query);
            return user != null ? Ok(MappingProfile.Mapper.Map<User, UserDTO>(user)) 
                : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]UserDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var query = new UserBaseQuery(MappingProfile.Mapper.Map<UserDTO, User>(user));
            UserService.CreateUser(query);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]UserDTO user)
        {
            if (id <= 0 || user == null)
            {
                return BadRequest();
            }
            var query = new UserBaseQuery(id, MappingProfile.Mapper.Map<UserDTO, User>(user));
            UserService.UpdateUser(query);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var query = new EntityBaseQuery(id);
            UserService.DeleteUser(query);
            return Ok();
        }
    }
}
