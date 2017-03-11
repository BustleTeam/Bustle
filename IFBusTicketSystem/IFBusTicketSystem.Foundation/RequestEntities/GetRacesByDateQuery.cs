using System;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class GetRacesByDateQuery
    {
        public DateTime Date { get; set; }

        public GetRacesByDateQuery(string date)
        {
            Date = DateTime.Parse(date); 
        }
    }
}
