using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface ITicketService
    {
        Ticket GetTicketById(EntityBaseQuery query);
        IEnumerable<Ticket> GetAllTickets();
        void CreateTicket(TicketBaseQuery query);
        void UpdateTicket(TicketBaseQuery query);
        void DeleteTicket(EntityBaseQuery query);
    }
}
