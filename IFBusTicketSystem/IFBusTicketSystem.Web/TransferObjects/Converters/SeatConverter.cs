using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class SeatConverter
    {
        public static SeatDTO ToDto(this Seat seat)
        {
            return MappingProfile.Mapper.Map<Seat, SeatDTO>(seat);
        }

        public static ShortSeatDTO ToDto(this ShortSeat seat)
        {
            return MappingProfile.Mapper.Map<ShortSeat, ShortSeatDTO>(seat);
        }

        public static Seat FromDto(this SeatDTO seatDto)
        {
            return MappingProfile.Mapper.Map<SeatDTO, Seat>(seatDto);
        }

        public static ShortSeat FromDto(this ShortSeatDTO seatDto)
        {
            return MappingProfile.Mapper.Map<ShortSeatDTO, ShortSeat>(seatDto);
        }
    }
}