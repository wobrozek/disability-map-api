using System;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Web;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

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
        public async Task Run([ServiceBusTrigger("sms-queqe", Connection = "BusConnect")] string myQueueItem)
        {
            _logger.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            Sms sms = JsonSerializer.Deserialize<Sms>(myQueueItem);

            HttpClient client = new HttpClient();

            var query = HttpUtility.ParseQueryString("https://api.smsapi.pl/sms.do");
            query["foo"] = "bar<>&-baz";
            query["bar"] = "bazinga";
            string queryString = query.ToString();

            var response = await client.GetAsync("");

            



        }
    }
}
