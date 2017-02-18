﻿using NHibernate.Validator.Constraints;

namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Seat : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }
        [NotNull]
        public virtual Race Race { get; set; }
        public virtual bool IsAvailable { get; set; }
    }
}
