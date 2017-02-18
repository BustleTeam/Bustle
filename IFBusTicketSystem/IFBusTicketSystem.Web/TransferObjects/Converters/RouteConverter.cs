using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class RouteConverter
    {
        public static RouteDTO ToDto(this Route route)
        {
            return MappingProfile.Mapper.Map<Route, RouteDTO>(route);
        }

        public static ShortRouteDTO ToDto(this ShortRoute route)
        {
            return MappingProfile.Mapper.Map<ShortRoute, ShortRouteDTO>(route);
        }

        public static Route FromDto(this RouteDTO routeDto)
        {
            return MappingProfile.Mapper.Map<RouteDTO, Route>(routeDto);
        }

        public static ShortRoute FromDto(this ShortRouteDTO routeDto)
        {
            return MappingProfile.Mapper.Map<ShortRouteDTO, ShortRoute>(routeDto);
        }
    }
}