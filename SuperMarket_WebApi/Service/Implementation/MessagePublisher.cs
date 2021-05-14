using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_WebApi.Service
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly ITopicClient topicClient;

        public MessagePublisher(ITopicClient topicClient)
        {
            this.topicClient = topicClient;
        }

        public async Task PublisherMessage<T>(T request)
        {
            await topicClient.SendAsync(MessageBuilder<T>(request));
        }

        public Message MessageBuilder<T>(T request)
        {
            var message = new Message
            {
                MessageId = Guid.NewGuid().ToString(),
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request))
            };
            message.UserProperties.Add("MessageType", typeof(T).Name);
            return message;
        }
    }
}
