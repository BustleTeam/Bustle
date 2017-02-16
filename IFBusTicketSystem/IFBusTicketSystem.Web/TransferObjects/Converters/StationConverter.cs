using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class StationConverter
    {
        public static StationDTO ToDto(this Station station)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Station, StationDTO>()
                        .ForMember(dto => dto.Routes,
                            map => map.UseValue(new List<RouteDTO>()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Station, StationDTO>(station);
        }

        public static ShortStationDTO ToDto(this ShortStation station)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortStation, ShortStationDTO>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortStation, ShortStationDTO>(station);
        }

        public static Station FromDto(this StationDTO stationDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StationDTO, Station>()
                        .ForMember(dto => dto.Routes,
                            map => map.UseValue(new List<Route>()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<StationDTO, Station>(stationDto);
        }

        public static ShortStation FromDto(this ShortStationDTO stationDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortStationDTO, ShortStation>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortStationDTO, ShortStation>(stationDto);
        }
    }
}