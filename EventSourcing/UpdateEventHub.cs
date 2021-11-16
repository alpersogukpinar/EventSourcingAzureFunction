using System;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.EventHubs;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace EventSourcing
{
    public static class UpdateEventHub
    {
        private static readonly string EventHubName = "event-hub1";

        [FunctionName("UpdateEventHub")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            string eventHubNamespaceConnection = Environment.GetEnvironmentVariable("EventHubNamespaceConnection");

            // Build connection string to access event hub within event hub namespace.
            EventHubsConnectionStringBuilder eventHubConnectionStringBuilder =
                new EventHubsConnectionStringBuilder(eventHubNamespaceConnection)
                {
                    EntityPath = EventHubName
                };

            // Create event hub client to send change feed events to event hub.
            EventHubClient eventHubClient = EventHubClient.CreateFromConnectionString(eventHubConnectionStringBuilder.ToString());

            EventData eventData = new EventData(Encoding.UTF8.GetBytes(requestBody));

            // Use Event Hub client to send the change events to event hub.
            await eventHubClient.SendAsync(eventData);

            string responseMessage = $"Message written to the eventHub, {requestBody}.";

            return new OkObjectResult(responseMessage);
        }
    }
}
