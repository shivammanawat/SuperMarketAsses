using Microsoft.AspNetCore.Mvc;
using Supermarket_WebApi.Service;
using System.Threading.Tasks;
using SuperMarket.Models;

namespace SuperMarket_WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IMessagePublisher messagePublisher;
        public TopicController(IMessagePublisher messagePublisher)
        {
            this.messagePublisher = messagePublisher;
        }

        [HttpPost(template: "product")]
        public async Task PublishProductMessage([FromBody] ProductsDataModel product)
        {
            await messagePublisher.PublisherMessage(product);
        }

    }
}
