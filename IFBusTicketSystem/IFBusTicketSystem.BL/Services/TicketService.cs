using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.BL.Validators;

namespace IFBusTicketSystem.BL.Services
{
    public class TicketService : ITicketService
    {
        [Dependency]
        public ITicketRepository Tickets { get; set; }
        [Dependency]
        public IValidationService ValidationService { get; set; }

        public void CreateTicket(TicketBaseQuery query)
        {
            ValidationService.Validate(query, new TicketBaseQueryValidator());
            Tickets.Create(query.Ticket);
        }

        public void DeleteTicket(EntityBaseQuery query)
        {
            ValidationService.Validate(query, new EntityBaseQueryValidator());
            var ticket = Tickets.GetById(query.Id);
            if (ticket != null)
            {
                Tickets.Delete(query.Id);
            }
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return Tickets.GetAll().ToList();
        }

        public Ticket GetTicketById(EntityBaseQuery query)
        {
            ValidationService.Validate(query, new EntityBaseQueryValidator());
            return Tickets.GetById(query.Id);
        }

        public void UpdateTicket(TicketBaseQuery query)
        {
            ValidationService.Validate(query, new TicketBaseQueryValidator());
            var ticket = Tickets.GetById(query.Id);
            if (ticket != null)
            {
                Tickets.Update(query.Ticket);
            }
        }
    }
}
