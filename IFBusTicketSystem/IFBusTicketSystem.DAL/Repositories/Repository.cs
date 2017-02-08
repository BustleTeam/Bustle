using System;
using System.Linq;
using IFBusTicketSystem.DAL.Interfaces;

namespace IFBusTicketSystem.DAL.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : class 
    {
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
