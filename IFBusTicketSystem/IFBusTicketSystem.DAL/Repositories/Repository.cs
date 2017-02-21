using System.Linq;
using IFBusTicketSystem.DAL.Interfaces;
using Microsoft.Practices.Unity;
using NHibernate;
using NHibernate.Linq;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : class 
    {
        [Dependency]
        public UnitOfWork UnitOfWork { get; set; }

        protected ISession Session
        {
            get
            {
                return UnitOfWork.Session;
            }
        }

        public void Create(T entity)
        {
            Session.Save(entity);       
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }

        public IQueryable<T> GetAll()
        {
            return UnitOfWork.Session.Query<T>();
        }

        public T GetById(int id)
        {
            return UnitOfWork.Session.Get<T>(id);
        }

        public void Update(T entity)
        {
            UnitOfWork.Session.Update(entity);
        }
    }
}
