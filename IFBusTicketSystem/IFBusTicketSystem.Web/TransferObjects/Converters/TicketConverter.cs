using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class TicketConverter
    {
        public static TicketDTO ToDto(this Ticket ticket)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Ticket, TicketDTO>()
                        .ForMember(dto => dto.Passenger,
                            map => map.UseValue(new UserDTO()))
                        .ForMember(dto => dto.Seat,
                            map => map.UseValue(new SeatDTO()));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Ticket, TicketDTO>(ticket);
        }

        public static ShortTicketDTO ToDto(this ShortTicket ticket)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortTicket, ShortTicketDTO>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortTicket, ShortTicketDTO>(ticket);
        }

        public static Ticket FromDto(this TicketDTO ticketDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TicketDTO, Ticket>()
                        .ForMember(dto => dto.Passenger,
                            map => map.UseValue(new User()))
                        .ForMember(dto => dto.Seat,
                            map => map.UseValue(new Seat())); ;
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<TicketDTO, Ticket>(ticketDto);
        }

        public static ShortTicket FromDto(this ShortTicketDTO ticketDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShortTicketDTO, ShortTicket>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ShortTicketDTO, ShortTicket>(ticketDto);
        }
    }
}