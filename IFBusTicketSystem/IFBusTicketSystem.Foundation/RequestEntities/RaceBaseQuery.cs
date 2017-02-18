using IFBusTicketSystem.Foundation.Types;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class RaceBaseQuery : EntityBaseQuery
    {
        public Race Race { get; set; }

        public RaceBaseQuery(int id, Race race) : base(id)
        {
            Race = race;
        }

        public RaceBaseQuery(Race race)
        {
            Race = race;
        }
    }
}
