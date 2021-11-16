using System;
using Microsoft.Azure.Cosmos;

namespace EventSourcing
{
    public class HubOverviewRepository : BaseRepository<HubOverview>
    {
        public HubOverviewRepository(Database database)
        {
            Container = database.CreateContainerIfNotExistsAsync("hub-monitoring", "/partitionKey").Result;
        }
    }
}