using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using IFBusTicketSystem.Web.TransferObjects;
using IFBusTicketSystem.Web.TransferObjects.Converters;
using Microsoft.Practices.Unity;
using System.Web.Http;
using IFBusTicketSystem.Web.Filters;

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
            return routes != null ? Ok(routes.ToDto<Route, RouteDTO>()) : (IHttpActionResult)NotFound();
        }

        public IHttpActionResult GetById(int id)
        {
            var query = new EntityBaseQuery(id);
            var route = RouteService.GetRouteById(query);
            return route != null ? Ok(route.ToDto<Route, RouteDTO>()) : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]RouteDTO route)
        {
            if (route == null)
            {
                return BadRequest();
            }
            var query = new RouteBaseQuery(route.FromDto<RouteDTO, Route>());
            RouteService.CreateRoute(query);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]RouteDTO route)
        {
            if (id <= 0 || route == null)
            {
                return BadRequest();
            }
            var query = new RouteBaseQuery(id, route.FromDto<RouteDTO, Route>());
            RouteService.UpdateRoute(query);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var query = new EntityBaseQuery(id);
            RouteService.DeleteRoute(query);
            return Ok();
        }
    }
}
