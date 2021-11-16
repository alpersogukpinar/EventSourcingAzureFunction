

using Microsoft.Azure.Cosmos;

namespace EventSourcing
{
    public class CustomerOverviewRepository : BaseRepository<CustomerOverview>
    {
        public CustomerOverviewRepository(Database database)
        {
            Container = database.CreateContainerIfNotExistsAsync("events","/customerId").Result.Container;
        }
    }
}