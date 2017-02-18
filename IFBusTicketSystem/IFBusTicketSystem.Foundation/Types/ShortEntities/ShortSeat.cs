using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class ShortSeat : IEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int RaceId { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public bool IsAvailable { get; set; }
    }
}