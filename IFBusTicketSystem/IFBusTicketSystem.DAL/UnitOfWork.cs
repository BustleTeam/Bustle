using System;
using IFBusTicketSystem.DAL.Interfaces;

namespace IFBusTicketSystem.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
