using System;

namespace KafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            string brokerList = "<eventHubsNamespaceURL>";
            string password = "<eventHubsConnStr>";
            string topicName = "<eventHubName>";
            string caCertLocation = ".\\cacert.pem";
            //string consumerGroup = ConfigurationManager.AppSettings["consumerGroup"];

            Console.WriteLine("Initiating Producer");
            Console.WriteLine("");
            Worker.Producer(brokerList, password, topicName, caCertLocation).Wait();
        }
    }
}
