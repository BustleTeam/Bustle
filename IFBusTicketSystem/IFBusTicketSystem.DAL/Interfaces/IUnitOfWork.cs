namespace IFBusTicketSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRaceRepository Races { get; set; }
        IRouteRepository Routes { get; set; }
        ISeatRepository Seats { get; set; }
        IStationRepository Stations { get; set; }
        IStopRepository Stops { get; set; }
        ITicketRepository Tickets { get; set; }
        IUserRepository Users { get; set; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
