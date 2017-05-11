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
    public class RacesController : ApiController
    {
        [Dependency]
        public IRaceService RaceService { get; set; }

        public IHttpActionResult GetAll()
        {
            var races = RaceService.GetAllRaces();
            return races != null ? Ok(MappingProfile.Mapper.Map<IEnumerable<Race>, IEnumerable<ShortRaceDTO>>(races)) 
                : (IHttpActionResult)NotFound();
        }

        [Route("races/{id:int:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            var query = new EntityBaseQuery(id);
            var race = RaceService.GetRaceById(query);
            return race != null ? Ok(MappingProfile.Mapper.Map<Race, RaceDTO>(race)) 
                : (IHttpActionResult)NotFound();
        }

        [Route("races/byDate")]
        public IHttpActionResult GetByDate([FromBody]string date)
        {
            var query = new GetRacesByDateQuery(date);
            var races = RaceService.GetRacesByDate(query);
            return races != null ? Ok(MappingProfile.Mapper.Map<IEnumerable<Race>, IEnumerable<ShortRaceDTO>>(races))
                : (IHttpActionResult)NotFound();
        }

        [Route("races/byDestination")]
        public IHttpActionResult GetByDestination([FromBody]string destination)
        {
            var query = new GetRacesByDestinationQuery(destination);
            var races = RaceService.GetRacesByDestination(query);
            return races != null ? Ok(MappingProfile.Mapper.Map<IEnumerable<Race>, IEnumerable<ShortRaceDTO>>(races))
                : (IHttpActionResult)NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]RaceDTO race)
        {
            if (race == null)
            {
                return BadRequest();
            }
            var query = new RaceBaseQuery(MappingProfile.Mapper.Map<RaceDTO, Race>(race));
            RaceService.CreateRace(query);
            return Ok();
        }

        [HttpPut]
        [Route("races/{id:int:min(1)}")]
        public IHttpActionResult Update(int id, [FromBody]RaceDTO race)
        {
            if (race == null)
            {
                return BadRequest();
            }
            var query = new RaceBaseQuery(id, MappingProfile.Mapper.Map<RaceDTO, Race>(race));
            RaceService.UpdateRace(query);
            return Ok();
        }

        [Route("races/{id:int:min(1)}")]
        public IHttpActionResult Delete(int id)
        {
            var query = new EntityBaseQuery(id);
            RaceService.DeleteRace(query);
            return Ok();
        }
    }
}
