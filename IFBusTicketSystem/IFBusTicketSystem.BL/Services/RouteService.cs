using IFBusTicketSystem.DAL;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;
using System.Linq;

namespace IFBusTicketSystem.BL.Services
{
    class RouteService
    {
        private readonly UnitOfWork _unitOfWork;

        public RouteService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void CreateRoute(RouteBaseQuery query)
        {
            if (query.Route != null)
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.Routes.Create(query.Route);
                _unitOfWork.Commit();
            }
        }

        public void DeleteRoute(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var route = _unitOfWork.Routes.GetById(query.Id);
                if (route != null)
                {
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.Routes.Delete(query.Id);
                    _unitOfWork.Commit();
                }
            }
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            var routes = _unitOfWork.Routes.GetAll().ToList();
            return routes;

        }

        public Route GetRouteById(EntityBaseQuery query)
        {
            var route = _unitOfWork.Routes.GetById(query.Id);
            if (route != null)
            {
                return route;
            }
            return null;
        }

        public void UpdateRoute(RouteBaseQuery query)
        {
            if (query.Route != null)
            {
                var route = _unitOfWork.Routes.GetById(query.Id);
                if (route != null)
                {
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.Routes.Update(query.Route);
                    _unitOfWork.Commit();
                }
            }
        }
    }
}
