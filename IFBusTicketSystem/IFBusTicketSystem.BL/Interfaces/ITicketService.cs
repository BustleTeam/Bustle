using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using IFBusTicketSystem.Foundation.Types.Entities;
using System;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface ITicketService
    {
        Ticket GetTicketById(EntityBaseQuery query);
        IEnumerable<Ticket> GetAllTickets();
        void CreateTicket(TicketBaseQuery query);
        void UpdateTicket(TicketBaseQuery query);
        void DeleteTicket(EntityBaseQuery query);
        Guid BookTicket(BookTicketCommand query);
    }
}
