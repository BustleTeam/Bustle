using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class RouteConverter
    {
        public static RouteDTO ToDto(this Route route)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Route, RouteDTO>()
                        .ForMember(dto => dto.Stations,
                            map => map.UseValue(new List<StationDTO>()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Route, RouteDTO>(route);
        }

        public static ShortRouteDTO ToDto(this ShortRoute route)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortRoute, ShortRouteDTO>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortRoute, ShortRouteDTO>(route);
        }

        public static Route FromDto(this RouteDTO routeDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RouteDTO, Route>()
                        .ForMember(dto => dto.Stations,
                            map => map.UseValue(new List<Station>()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<RouteDTO, Route>(routeDto);
        }

        public static ShortRoute FromDto(this ShortRouteDTO routeDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortRouteDTO, ShortRoute>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortRouteDTO, ShortRoute>(routeDto);
        }
    }
}