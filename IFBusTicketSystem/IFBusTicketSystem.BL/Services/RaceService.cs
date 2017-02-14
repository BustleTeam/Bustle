using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.DAL;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;
using System.Linq;

namespace IFBusTicketSystem.BL.Services
{
    class RaceService : IRaceService
    {
        private readonly UnitOfWork _unitOfWork;

        public RaceService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void CreateRace(RaceBaseQuery query)
        {
            if (query.Race != null)
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.Races.Create(query.Race);
                _unitOfWork.Commit();
            }
        }

        public void DeleteRace(EntityBaseQuery query)
        {
            if (query.Id > 0)
            {
                var race = _unitOfWork.Races.GetById(query.Id);
                if (race != null)
                {
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.Races.Delete(query.Id);
                    _unitOfWork.Commit();
                }
            }
        }

        public IEnumerable<Race> GetAllRaces()
        {
            var races = _unitOfWork.Races.GetAll().ToList();
            return races;

        }

        public Race GetRaceById(EntityBaseQuery query)
        {
            var race = _unitOfWork.Races.GetById(query.Id);
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
                var race = _unitOfWork.Races.GetById(query.Id);
                if (race != null)
                {
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.Races.Update(query.Race);
                    _unitOfWork.Commit();
                }
            }
        }
    }
}
