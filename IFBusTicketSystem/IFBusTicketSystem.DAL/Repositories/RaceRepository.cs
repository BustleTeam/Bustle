using IFBusTicketSystem.DAL.Interfaces;
using IFBusTicketSystem.Foundation.Types.Entities;
using System;
using System.Collections.Generic;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class RaceRepository : Repository<Race>, IRaceRepository
    {
        public IEnumerable<Race> GetByDate(DateTime date)
        {
            return Session.QueryOver<Race>()
                .Where(r => r.Departure.Date == date.Date && r.Departure >= date)
                .List();
        }
    }
}
