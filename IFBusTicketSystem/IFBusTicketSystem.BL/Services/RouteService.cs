using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.BL.Validators;

namespace IFBusTicketSystem.BL.Services
{
    public class RouteService : IRouteService
    {
        [Dependency]
        public IRouteRepository Routes { get; set; }
        [Dependency]
        public IValidationService ValidationService { get; set; }

        public void CreateRoute(RouteBaseQuery query)
        {
            ValidationService.Validate(query, new RouteBaseQueryValidator());
            Routes.Create(query.Route);
        }

        public void DeleteRoute(EntityBaseQuery query)
        {
            ValidationService.Validate(query, new EntityBaseQueryValidator());
            var route = Routes.GetById(query.Id);
            if (route != null)
            {
                Routes.Delete(query.Id);
            }
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return Routes.GetAll().ToList();
        }

        public Route GetRouteById(EntityBaseQuery query)
        {
            ValidationService.Validate(query, new EntityBaseQueryValidator());
            return Routes.GetById(query.Id);
        }

        public void UpdateRoute(RouteBaseQuery query)
        {
            ValidationService.Validate(query, new RouteBaseQueryValidator());
            var route = Routes.GetById(query.Id);
            if (route != null)
            {
                Routes.Update(query.Route);
            }
        }
    }
}
