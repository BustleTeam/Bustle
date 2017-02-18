namespace IFBusTicketSystem.Web.TransferObjects
{
    public class ShortRaceDTO : IEntityDTO
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteDescription { get; set; }
    }
}