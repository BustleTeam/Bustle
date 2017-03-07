using System;

namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class DateTimeQuery : EntityBaseQuery
    {
        public DateTime Date { get; set; }

        public DateTimeQuery(string date)
        {
            Date = DateTime.Parse(date); 
        }
    }
}
