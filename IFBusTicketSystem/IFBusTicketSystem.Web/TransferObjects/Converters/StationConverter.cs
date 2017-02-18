using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class StationConverter
    {
        public static StationDTO ToDto(this Station station)
        {
            return MappingProfile.Mapper.Map<Station, StationDTO>(station);
        }

        public static ShortStationDTO ToDto(this ShortStation station)
        {
            return MappingProfile.Mapper.Map<ShortStation, ShortStationDTO>(station);
        }

        public static Station FromDto(this StationDTO stationDto)
        {
            return MappingProfile.Mapper.Map<StationDTO, Station>(stationDto);
        }

        public static ShortStation FromDto(this ShortStationDTO stationDto)
        {
            return MappingProfile.Mapper.Map<ShortStationDTO, ShortStation>(stationDto);
        }
    }
}