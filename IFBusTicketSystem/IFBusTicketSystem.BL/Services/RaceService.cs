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
    public class RaceService : IRaceService
    {
        [Dependency]
        public IRaceRepository Races { get; set; }
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
