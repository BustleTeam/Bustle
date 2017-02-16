using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class RaceConverter
    {
        public static RaceDTO ToDto(this Race race)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Race, RaceDTO>()
                        .ForMember(dto => dto.Route,
                            map => map.UseValue(new RouteDTO()))
                        .ForMember(dto => dto.Stops,
                            map => map.UseValue(new List<StopDTO>()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Race, RaceDTO>(race);
        }

        public static ShortRaceDTO ToDto(this ShortRace race)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortRace, ShortRaceDTO>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortRace, ShortRaceDTO>(race);
        }

        public static Race FromDto(this RaceDTO raceDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RaceDTO, Race>()
                        .ForMember(dto => dto.Route,
                            map => map.UseValue(new Route()))
                        .ForMember(dto => dto.Stops,
                            map => map.UseValue(new List<Stop>()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<RaceDTO, Race>(raceDto);
        }

        public static ShortRace FromDto(this ShortRaceDTO raceDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortRaceDTO, ShortRace>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortRaceDTO, ShortRace>(raceDto);
        }
    }
}
