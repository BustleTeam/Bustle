using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class SeatConverter
    {
        public static SeatDTO ToDto(this Seat seat)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Seat, SeatDTO>()
                        .ForMember(dto => dto.Race,
                            map => map.UseValue(new RaceDTO()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Seat, SeatDTO>(seat);
        }

        public static ShortSeatDTO ToDto(this ShortSeat seat)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortSeat, ShortSeatDTO>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortSeat, ShortSeatDTO>(seat);
        }

        public static Seat FromDto(this SeatDTO seatDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SeatDTO, Seat>()
                        .ForMember(dto => dto.Race,
                            map => map.UseValue(new Race()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<SeatDTO, Seat>(seatDto);
        }

        public static ShortSeat FromDto(this ShortSeatDTO seatDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortSeatDTO, ShortSeat>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortSeatDTO, ShortSeat>(seatDto);
        }
    }
}