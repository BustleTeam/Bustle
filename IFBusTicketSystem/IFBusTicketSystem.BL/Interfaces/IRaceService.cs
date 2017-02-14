using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;
using System.Collections.Generic;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface IRaceService
    {
        Race GetRaceById(EntityBaseQuery query);
        IEnumerable<Race> GetAllRaces();
        void CreateRace(RaceBaseQuery query);
        void UpdateRace(RaceBaseQuery query);
        void DeleteRace(EntityBaseQuery query);
    }
}
