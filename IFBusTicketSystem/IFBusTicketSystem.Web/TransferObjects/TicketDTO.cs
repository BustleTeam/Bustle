﻿namespace IFBusTicketSystem.Web.TransferObjects
{
    public class TicketDTO : IEntityDTO
    {
        public int Id { get; set; }
        public UserDTO Passenger { get; set; }
        public SeatDTO Seat { get; set; }
    }
}