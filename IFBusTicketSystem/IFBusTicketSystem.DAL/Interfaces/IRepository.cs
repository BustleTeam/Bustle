using System;
using System.Linq;
using System.Linq.Expressions;

namespace IFBusTicketSystem.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
