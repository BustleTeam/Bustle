using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class RaceDTO : IEntityDTO
    {
        public int Id { get; set; }
        public RouteDTO Route { get; set; }
        public IEnumerable<StopDTO> Stops { get; set; } = new List<StopDTO>();
    }
}