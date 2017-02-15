using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.DAL;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;

namespace IFBusTicketSystem.BL.Services
{
    public class TicketService : ITicketService
    {
        [Dependency]
        public UnitOfWork UnitOfWork { get; set; }

        public void CreateTicket(TicketBaseQuery query)
        {
            if (query.Ticket != null)
            {
                UnitOfWork.BeginTransaction();
                UnitOfWork.Tickets.Create(query.Ticket);
                UnitOfWork.Commit();
            }
        }

        public void DeleteTicket(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var ticket = UnitOfWork.Tickets.GetById(query.Id);
                if (ticket != null)
                {
                    UnitOfWork.BeginTransaction();
                    UnitOfWork.Tickets.Delete(query.Id);
                    UnitOfWork.Commit();
                }
            }
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            var tickets = UnitOfWork.Tickets.GetAll().ToList();
            return tickets;

        }

        public Ticket GetTicketById(EntityBaseQuery query)
        {
            var ticket = UnitOfWork.Tickets.GetById(query.Id);
            if (ticket != null)
            {
                return ticket;
            }
            return null;
        }

        public void UpdateTicket(TicketBaseQuery query)
        {
            if (query.Ticket != null)
            {
                var ticket = UnitOfWork.Tickets.GetById(query.Id);
                if (ticket != null)
                {
                    UnitOfWork.BeginTransaction();
                    UnitOfWork.Tickets.Update(query.Ticket);
                    UnitOfWork.Commit();
                }
            }
        }
    }
}
