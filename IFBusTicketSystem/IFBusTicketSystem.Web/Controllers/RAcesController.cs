using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types.Entities;
using IFBusTicketSystem.Web.TransferObjects;
using IFBusTicketSystem.Web.TransferObjects.Converters;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IFBusTicketSystem.Web.Controllers
{
    public class RacesController : ApiController
    {
        [Dependency]
        public IRaceService RaceService { get; set; }

        public IHttpActionResult GetAll()
        {
            var races = RaceService.GetAllRaces();
            return races != null ? Ok(races.ToDto<Race, RaceDTO>()) : (IHttpActionResult)NotFound();
        }

        public IHttpActionResult GetById(int id)
        {
            var query = new EntityBaseQuery(id);
            var race = RaceService.GetRaceById(query);
            return race != null ? Ok(race.ToDto<Race, RaceDTO>()) : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]RaceDTO race)
        {
            if (race == null)
            {
                return BadRequest();
            }
            var query = new RaceBaseQuery(race.FromDto<RaceDTO, Race>());
            RaceService.CreateRace(query);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]RaceDTO race)
        {
            if (id <= 0 || race == null)
            {
                return BadRequest();
            }
            var query = new RaceBaseQuery(id, race.FromDto<RaceDTO, Race>());
            RaceService.UpdateRace(query);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var query = new EntityBaseQuery(id);
            RaceService.DeleteRace(query);
            return Ok();
        }
    }
}
