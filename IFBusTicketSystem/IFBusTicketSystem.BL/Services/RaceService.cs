using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.BL.Validators;
using System;

namespace IFBusTicketSystem.BL.Services
{
    public class RaceService : IRaceService
    {
        [Dependency]
        public IRaceRepository Races { get; set; }
        [Dependency]
        public IStopRepository Stops { get; set; }
        [Dependency]
        public IValidationService ValidationService { get; set; }

        public void CreateRace(RaceBaseQuery query)
        {
            ValidationService.Validate(query, new RaceBaseQueryValidator());
            Races.Create(query.Race);
        }

        public void DeleteRace(EntityBaseQuery query)
        {
            ValidationService.Validate(query, new EntityBaseQueryValidator());
            var race = Races.GetById(query.Id);
            if (race != null)
            {
                Races.Delete(query.Id);
            }
        }

        public IEnumerable<Race> GetAllRaces()
        {        
            return Races.GetAll().ToList();
        }

        public Race GetRaceById(EntityBaseQuery query)
        {
            ValidationService.Validate(query, new EntityBaseQueryValidator());
            return Races.GetById(query.Id);
        }

        public IEnumerable<Race> GetRacesByDate(GetRacesByDateQuery query)
        {
            ValidationService.Validate(query, new GetRacesByDateQueryValidator());
            return Races.FindBy(r => r.Departure.Date == query.Date.Date && r.Departure >= query.Date);
        }

        public IEnumerable<Race> GetRacesByDestination(GetRacesByDestinationQuery query)
        {
            ValidationService.Validate(query, new GetRacesByDestinationQueryValidator());
            IEnumerable<Stop> stops = Stops.FindBy(s => s.Station.Name == query.Destination);
            return stops.Select(s => s.Race).AsEnumerable();
        }

        public void UpdateRace(RaceBaseQuery query)
        {
            ValidationService.Validate(query, new RaceBaseQueryValidator());
            var race = Races.GetById(query.Id);
            if (race != null)
            {
                Races.Update(query.Race);
            }
        }
    }
}
