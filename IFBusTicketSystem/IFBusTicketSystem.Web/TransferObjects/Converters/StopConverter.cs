using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class StopConverter
    {
        public static StopDTO ToDto(this Stop stop)
        {
            return MappingProfile.Mapper.Map<Stop, StopDTO>(stop);
        }

        public static ShortStopDTO ToDto(this ShortStop stop)
        {
            return MappingProfile.Mapper.Map<ShortStop, ShortStopDTO>(stop);
        }

        public static Stop FromDto(this StopDTO stopDto)
        {
            return MappingProfile.Mapper.Map<StopDTO, Stop>(stopDto);
        }

        public static ShortStop FromDto(this ShortStopDTO stopDto)
        {
            return MappingProfile.Mapper.Map<ShortStopDTO, ShortStop>(stopDto);
        }
    }
}