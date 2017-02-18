namespace IFBusTicketSystem.Web.TransferObjects
{
    public class SeatDTO : IEntityDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public RaceDTO Race { get; set; }
        public bool IsAvailable { get; set; }
    }
}