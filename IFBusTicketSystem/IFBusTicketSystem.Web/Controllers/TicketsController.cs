using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using IFBusTicketSystem.Web.TransferObjects;
using IFBusTicketSystem.Web.TransferObjects.Mapping;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Web.Http;
using IFBusTicketSystem.Web.Filters;

namespace IFBusTicketSystem.Web.Controllers
{
    [CheckException]
    public class TicketsController : ApiController
    {
        [Dependency]
        public ITicketService TicketService { get; set; }

        public IHttpActionResult GetAll()
        {
            var tickets = TicketService.GetAllTickets();
            return tickets != null ? Ok(MappingProfile.Mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets)) 
                : (IHttpActionResult)NotFound();
        }

        [Route("tickets/{id:int:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            var query = new EntityBaseQuery(id);
            var ticket = TicketService.GetTicketById(query);
            return ticket != null ? Ok(MappingProfile.Mapper.Map<Ticket, TicketDTO>(ticket)) 
                : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]TicketDTO ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            var query = new TicketBaseQuery(MappingProfile.Mapper.Map<TicketDTO, Ticket>(ticket));
            TicketService.CreateTicket(query);
            return Ok();
        }

        [HttpPut]
        [Route("tickets/{id:int:min(1)}")]
        public IHttpActionResult Update(int id, [FromBody]TicketDTO ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            var query = new TicketBaseQuery(id, MappingProfile.Mapper.Map<TicketDTO, Ticket>(ticket));
            TicketService.UpdateTicket(query);
            return Ok();
        }

        [Route("tickets/{id:int:min(1)}")]
        public IHttpActionResult Delete(int id)
        {
            var query = new EntityBaseQuery(id);
            TicketService.DeleteTicket(query);
            return Ok();
        }
    }
}
