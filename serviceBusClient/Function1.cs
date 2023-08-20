using System;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Web;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace serviceBusClient
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public async Task Run([ServiceBusTrigger("sms-queqe", Connection = "ServiceBusConnection")] ServiceBusReceivedMessage myQueueItem)
        {
            _logger.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var config = new ConfigurationBuilder().AddJsonFile("local.settings.json").Build();

            Sms sms = JsonSerializer.Deserialize<Sms>(myQueueItem.Body);

            var client = new RestClient("");

            //var client = new RestClient("https://api.smsapi.pl/sms.do");

            //var request = new RestRequest("https://api.smsapi.pl/sms.do", Method.Post);
            //request.AddQueryParameter("auth_token", System.Environment.GetEnvironmentVariable("Token"));
            //request.AddQueryParameter("to", sms.Phone);
            //request.AddQueryParameter("from", "test");
            //request.AddQueryParameter("message", sms.Message);
            //request.AddQueryParameter("format", "json");
        }
    }
}
