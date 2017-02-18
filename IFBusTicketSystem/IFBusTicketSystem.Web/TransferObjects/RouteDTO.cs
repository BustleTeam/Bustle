using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class RouteDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<StationDTO> Stations { get; set; } = new List<StationDTO>();
    }
}