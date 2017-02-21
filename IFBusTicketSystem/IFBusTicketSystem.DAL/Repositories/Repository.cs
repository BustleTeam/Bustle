using System.Linq;
using IFBusTicketSystem.DAL.Interfaces;
using Microsoft.Practices.Unity;
using NHibernate.Linq;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : class 
    {
        [Dependency]
        public UnitOfWork UnitOfWork { get; set; }

        public void Create(T entity)
        {
            UnitOfWork.BeginTransaction();
            UnitOfWork.Session.Save(entity);
            UnitOfWork.Commit();          
        }

        public void Delete(int id)
        {
            UnitOfWork.BeginTransaction();
            UnitOfWork.Session.Delete(UnitOfWork.Session.Load<T>(id));
            UnitOfWork.Commit();
        }

        public IQueryable<T> GetAll()
        {
            UnitOfWork.BeginTransaction();
            var query = UnitOfWork.Session.Query<T>();
            UnitOfWork.Commit();
            return query;
        }

        public T GetById(int id)
        {
            UnitOfWork.BeginTransaction();
            var type = UnitOfWork.Session.Get<T>(id);
            UnitOfWork.Commit();
            return type;
        }

        public void Update(T entity)
        {
            UnitOfWork.BeginTransaction();
            UnitOfWork.Session.Update(entity);
            UnitOfWork.Commit();
        }
    }
}
