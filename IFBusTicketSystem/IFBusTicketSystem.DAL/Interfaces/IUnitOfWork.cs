using NHibernate;

namespace IFBusTicketSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ISession Session { get; set; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
