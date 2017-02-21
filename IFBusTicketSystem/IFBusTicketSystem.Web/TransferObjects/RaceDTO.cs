﻿using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects
{
    public class RaceDTO
    {
        public int Id { get; set; }
        public RouteDTO Route { get; set; }
        public IEnumerable<StopDTO> Stops { get; set; } = new List<StopDTO>();
        public IEnumerable<SeatDTO> Seats { get; set; } = new List<SeatDTO>();
    }
}