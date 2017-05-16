using System.Linq;
using IFBusTicketSystem.DAL.Interfaces;
using Microsoft.Practices.Unity;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : class 
    {
        [Dependency]
        public IUnitOfWork UnitOfWork { get; set; }

        protected ISession Session {
            get
            {
                return UnitOfWork.Session;
            }
        }

        public void Create(T entity)
        {
            UnitOfWork.BeginTransaction();
            Session.Save(entity);       
            UnitOfWork.Commit();
        }

        public void Delete(int id)
        {
            Delete(id.ToString());
        }

        public void Delete(string id)
        {
            Session.Delete(Session.Load<T>(id));
        }

        public virtual IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Session.QueryOver<T>()
                .Where(predicate)
                .List();
        }

        public virtual T GetById(int id)
        {
            return Session.Get<T>(id.ToString());
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return Session.QueryOver<T>()
                .Where(predicate)
                .SingleOrDefault();
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }
    }
}
