using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using System.Linq;
using IFBusTicketSystem.Foundation.Types.Entities;
using Microsoft.Practices.Unity;
using IFBusTicketSystem.DAL.Interfaces;

namespace IFBusTicketSystem.BL.Services
{
    public class RaceService : IRaceService
    {
        [Dependency]
        public IRaceRepository Races { get; set; }

        public void CreateRace(RaceBaseQuery query)
        {
            if (query.Race != null)
            {
                Races.Create(query.Race);
            }
        }

        public void DeleteRace(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var race = Races.GetById(query.Id);
                if (race != null)
                {
                    Races.Delete(query.Id);
                }
            }
        }

        public IEnumerable<Race> GetAllRaces()
        {        
            return Races.GetAll().ToList();
        }

        public Race GetRaceById(EntityBaseQuery query)
        {
            return Races.GetById(query.Id);
        }

        public void UpdateRace(RaceBaseQuery query)
        {
            if (query.Race != null)
            {
                var race = Races.GetById(query.Id);
                if (race != null)
                {
                    Races.Update(query.Race);
                }
            }
        }
    }
}
