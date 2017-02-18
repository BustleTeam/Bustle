namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class EntityBaseQuery
    {
        public int Id { get; set; }

        public EntityBaseQuery() { }

        public EntityBaseQuery(int id)
        {
            Id = id;
        }
    }
}
