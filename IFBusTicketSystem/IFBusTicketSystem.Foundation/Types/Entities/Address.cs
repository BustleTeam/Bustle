﻿namespace IFBusTicketSystem.Foundation.Types.Entities
{
    public class Address
    {
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string Building { get; set; }
    }
}
