using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.DAL;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace IFBusTicketSystem.BL.Services
{
    public class RaceService : IRaceService
    {
        [Dependency]
        public UnitOfWork UnitOfWork { get; set; }

        public void CreateRace(RaceBaseQuery query)
        {
            if (query.Race != null)
            {
                UnitOfWork.BeginTransaction();
                UnitOfWork.Races.Create(query.Race);
                UnitOfWork.Commit();
            }
        }

        public void DeleteRace(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var race = UnitOfWork.Races.GetById(query.Id);
                if (race != null)
                {
                    UnitOfWork.BeginTransaction();
                    UnitOfWork.Races.Delete(query.Id);
                    UnitOfWork.Commit();
                }
            }
        }

        public IEnumerable<Race> GetAllRaces()
        {
            var races = UnitOfWork.Races.GetAll().ToList();
            return races;

        }

        public Race GetRaceById(EntityBaseQuery query)
        {
            var race = UnitOfWork.Races.GetById(query.Id);
            if (race != null)
            {
                return race;
            }
            return null;
        }

        public void UpdateRace(RaceBaseQuery query)
        {
            if (query.Race != null)
            {
                var race = UnitOfWork.Races.GetById(query.Id);
                if (race != null)
                {
                    UnitOfWork.BeginTransaction();
                    UnitOfWork.Races.Update(query.Race);
                    UnitOfWork.Commit();
                }
            }
        }
    }
}
