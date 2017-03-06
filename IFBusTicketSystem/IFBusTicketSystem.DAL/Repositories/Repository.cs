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
        public IUnitOfWork UnitOfWork { get; set; }
        
        [Dependency]
        protected ISession Session {
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

        public virtual IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public virtual T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }
    }
}
