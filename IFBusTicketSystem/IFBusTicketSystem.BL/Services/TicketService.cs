using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.DAL;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;
using System.Linq;

namespace IFBusTicketSystem.BL.Services
{
    class TicketService : ITicketService
    {
        private readonly UnitOfWork _unitOfWork;

        public TicketService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void CreateTicket(TicketBaseQuery query)
        {
            if (query.Ticket != null)
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.Tickets.Create(query.Ticket);
                _unitOfWork.Commit();
            }
        }

        public void DeleteTicket(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var ticket = _unitOfWork.Tickets.GetById(query.Id);
                if (ticket != null)
                {
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.Tickets.Delete(query.Id);
                    _unitOfWork.Commit();
                }
            }
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            var tickets = _unitOfWork.Tickets.GetAll().ToList();
            return tickets;

        }

        public Ticket GetTicketById(EntityBaseQuery query)
        {
            var ticket = _unitOfWork.Tickets.GetById(query.Id);
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
                var ticket = _unitOfWork.Tickets.GetById(query.Id);
                if (ticket != null)
                {
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.Tickets.Update(query.Ticket);
                    _unitOfWork.Commit();
                }
            }
        }
    }
}
