using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;

namespace IFBusTicketSystem.BL.Services
{
    public class TicketService : ITicketService
    {
        [Dependency]
        public ITicketRepository Tickets { get; set; }

        public void CreateTicket(TicketBaseQuery query)
        {
            if (query.Ticket != null)
            {
                Tickets.Create(query.Ticket);
            }
        }

        public void DeleteTicket(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var ticket = Tickets.GetById(query.Id);
                if (ticket != null)
                {
                    Tickets.Delete(query.Id);
                }
            }
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return Tickets.GetAll().ToList();
        }

        public Ticket GetTicketById(EntityBaseQuery query)
        {
            return Tickets.GetById(query.Id);
        }

        public void UpdateTicket(TicketBaseQuery query)
        {
            if (query.Ticket != null)
            {
                var ticket = Tickets.GetById(query.Id);
                if (ticket != null)
                {
                    Tickets.Update(query.Ticket);
                }
            }
        }
    }
}
