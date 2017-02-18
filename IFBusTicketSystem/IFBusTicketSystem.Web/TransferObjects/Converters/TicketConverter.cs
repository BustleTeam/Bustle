using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class TicketConverter
    {
        public static TicketDTO ToDto(this Ticket ticket)
        {
            return MappingProfile.Mapper.Map<Ticket, TicketDTO>(ticket);
        }

        public static ShortTicketDTO ToDto(this ShortTicket ticket)
        {
            return MappingProfile.Mapper.Map<ShortTicket, ShortTicketDTO>(ticket);
        }

        public static Ticket FromDto(this TicketDTO ticketDto)
        {
            return MappingProfile.Mapper.Map<TicketDTO, Ticket>(ticketDto);
        }

        public static ShortTicket FromDto(this ShortTicketDTO ticketDto)
        {
            return MappingProfile.Mapper.Map<ShortTicketDTO, ShortTicket>(ticketDto);
        }
    }
}