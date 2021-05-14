using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using SuperMarket.Client;
using SuperMarket.Logging;
using SuperMarket.Repository;
using SuperMarket.Service;

namespace SuperMarket_WebApi.Controllers
{
 
        [ApiController]
        [Route("[controller]")]
        public class CustomerController : Controller
        {
            private readonly IConfiguration _configuration;
            private IStockRepository _stockRepository;
            private IStockService _stockService;
            private IDiscountService _discountService;
            private IPaymentGatewayClient _paymentGatewayClient;
            private ILogger _logger;

            public CustomerController(IConfiguration configuration, IStockRepository stockRepository, IStockService stockService,
              IDiscountService discountService, IPaymentGatewayClient paymentGatewayClient
                , ILogger logger)
            {
                _configuration = configuration;
                _stockRepository = stockRepository;
                _stockService = stockService;
                _discountService = discountService;
                _paymentGatewayClient = paymentGatewayClient;
                _logger = logger;
            }

            [HttpGet]
            [Route("Shopping/{customerId}")]
            public JsonResult Register(int customerId)
            {
                if (customerId.ToString() != null)
                {
                    _paymentGatewayClient = new PaymentGatewayClient(new HttpClient());
                    List<string> items = new List<string>() { "Breads", "Milk", "Biscuits", "Dryfruits" };
                    ShoppingService shoppingService = new ShoppingService(customerId, _stockService, _discountService, _paymentGatewayClient, _logger);
                    var count = shoppingService.BuyItems(items);
                    var result = count > 0 ? $"Shopping done for {count} products" : $"Shopping done for { count} product";
                    return Json(result);
                }
                return Json("Invalid Customer Id");
            }

        }
    
}
