using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SuperMarket.Models;

namespace ServiceBusTopic.Product
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISubscriptionClient subscriptionClient;
        public Worker(ILogger<Worker> logger, ISubscriptionClient subscriptionClient)
        {
            _logger = logger;
            this.subscriptionClient = subscriptionClient;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            subscriptionClient.RegisterMessageHandler((message, token) =>
            {
                _logger.LogInformation($"message id:{message.MessageId}");
                _logger.LogInformation($"message body:{Encoding.UTF8.GetString(message.Body)}");
                var product = JsonConvert.DeserializeObject<ProductsDataModel>(Encoding.UTF8.GetString(message.Body));
                
                return  subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            }, new MessageHandlerOptions(ex =>
            {
                _logger.LogError(ex.Exception, ex.Exception.Message);
                return Task.FromException(ex.Exception);
            })
            {
                AutoComplete = false,
                MaxConcurrentCalls = 1
            });
            await Task.CompletedTask;
        }
    }
}
