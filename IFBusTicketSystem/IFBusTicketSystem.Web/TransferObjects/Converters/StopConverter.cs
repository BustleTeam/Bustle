using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class StopConverter
    {
        public static StopDTO ToDto(this Stop stop)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Stop, StopDTO>()
                        .ForMember(dto => dto.Station,
                            map => map.UseValue(new StationDTO()))
                        .ForMember(dto => dto.Race,
                            map => map.UseValue(new RaceDTO()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Stop, StopDTO>(stop);
        }

        public static ShortStopDTO ToDto(this ShortStop stop)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortStop, ShortStopDTO>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortStop, ShortStopDTO>(stop);
        }

        public static Stop FromDto(this StopDTO stopDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StopDTO, Stop>()
                        .ForMember(dto => dto.Station,
                            map => map.UseValue(new Station()))
                        .ForMember(dto => dto.Race,
                            map => map.UseValue(new Race()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<StopDTO, Stop>(stopDto);
        }

        public static ShortStop FromDto(this ShortStopDTO stopDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortStopDTO, ShortStop>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortStopDTO, ShortStop>(stopDto);
        }
    }
}