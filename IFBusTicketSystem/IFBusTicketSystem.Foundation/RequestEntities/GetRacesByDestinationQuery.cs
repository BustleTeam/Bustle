namespace IFBusTicketSystem.Foundation.RequestEntities
{
    public class GetRacesByDestinationQuery
    {
        public string Destination { get; set; }

        public GetRacesByDestinationQuery(string destination)
        {
            Destination = destination;
        }
    }
}
