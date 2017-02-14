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
        public ISession Session { get; set; }

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
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }
    }
}
