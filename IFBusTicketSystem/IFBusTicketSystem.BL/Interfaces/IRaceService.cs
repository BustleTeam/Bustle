using IFBusTicketSystem.Foundation.RequestEntities;
using System.Collections.Generic;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface IRaceService
    {
        Race GetRaceById(EntityBaseQuery query);
        IEnumerable<Race> GetRacesByDate(GetRacesByDateQuery query);
        IEnumerable<Race> GetRacesByDestination(GetRacesByDestinationQuery query);
        IEnumerable<Race> GetAllRaces();
        void CreateRace(RaceBaseQuery query);
        void UpdateRace(RaceBaseQuery query);
        void DeleteRace(EntityBaseQuery query);
    }
}
