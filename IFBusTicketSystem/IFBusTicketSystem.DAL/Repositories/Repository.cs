using System;
using System.Linq;
using IFBusTicketSystem.DAL.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : class 
    {
        private ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public void Create(T entity)
        {
            _session.Save(entity);
        }

        public void Delete(int id)
        {
            _session.Delete(_session.Load<T>(id));
        }

        public IQueryable<T> GetAll()
        {
            return _session.Query<T>();
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public void Update(T entity)
        {
            _session.Update(entity);
        }
    }
}
