using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceBusTopic.Product
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<ISubscriptionClient>(serviceProvider => new SubscriptionClient(
                    connectionString: "Endpoint=sb://supermarket.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=dEK+q1xyVD8CbF6SYBlFp6vjbqUph0hXXSojxom4J30=",
                    topicPath: "my-topic", 
                    subscriptionName: "Azure Pass - Sponsorship"));
                });
    }
}
