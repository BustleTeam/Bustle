﻿namespace IFBusTicketSystem.Web.TransferObjects
{
    public class ShortStationDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locality { get; set; }
        public string Description { get; set; }
    }
}