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
    public class RoutesController : ApiController
    {
        [Dependency]
        public IRouteService RouteService { get; set; }

        public IHttpActionResult GetAll()
        {
            var routes = RouteService.GetAllRoutes();
            return routes != null ? Ok(MappingProfile.Mapper.Map<IEnumerable<Route>, IEnumerable<RouteDTO>>(routes)) 
                : (IHttpActionResult)NotFound();
        }

        [Route("routes/{id:int:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            var query = new EntityBaseQuery(id);
            var route = RouteService.GetRouteById(query);
            return route != null ? Ok(MappingProfile.Mapper.Map<Route, RouteDTO>(route)) 
                : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]RouteDTO route)
        {
            if (route == null)
            {
                return BadRequest();
            }
            var query = new RouteBaseQuery(MappingProfile.Mapper.Map<RouteDTO, Route>(route));
            RouteService.CreateRoute(query);
            return Ok();
        }

        [HttpPut]
        [Route("routes/{id:int:min(1)}")]
        public IHttpActionResult Update(int id, [FromBody]RouteDTO route)
        {
            if (route == null)
            {
                return BadRequest();
            }
            var query = new RouteBaseQuery(id, MappingProfile.Mapper.Map<RouteDTO, Route>(route));
            RouteService.UpdateRoute(query);
            return Ok();
        }

        [Route("routes/{id:int:min(1)}")]
        public IHttpActionResult Delete(int id)
        {
            var query = new EntityBaseQuery(id);
            RouteService.DeleteRoute(query);
            return Ok();
        }
    }
}
