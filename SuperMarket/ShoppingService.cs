using System;
using System.Collections.Generic;
using System.Text;
using SuperMarket.Repository;
using SuperMarket.Service;
using SuperMarket.Logging;
using System.Net.Http;
using System.Linq;
using SuperMarket.Constant;
using SuperMarket.Client;

namespace SuperMarket.Service
{
   public class ShoppingService
    {

        private readonly int _customerId;
        private double OrderValue = 0;
        private IStockService _stockService;
        private IDiscountService _discountService;
        private IPaymentGatewayClient _paymentGatewayClient;
        private ILogger _logger;
        public ShoppingService(int customerId, IStockService stockRepository, IDiscountService discountService, 
        IPaymentGatewayClient paymentGateWay, ILogger logger)
        {
            _customerId = customerId;
            _stockService = stockRepository;
            _discountService = discountService;
            _logger = logger;
            _paymentGatewayClient = paymentGateWay;
        }

        public int BuyItems(List<string> items)
        {
            var products = _stockService.CheckStockStatus(items);
            double price = 0;
            Console.WriteLine("--- Your Bucket Items ---");
            foreach (var item in products)
            {
                Console.WriteLine(item.Name + " - " + item.Price);
                price += item.Price;
            }
            Console.WriteLine("-------------");
            Console.WriteLine("Total price = " + price);
            OrderValue = _discountService.ApplyDiscount(this._customerId, price);
            Console.WriteLine("After discount price = " + OrderValue);
            Console.WriteLine("-------------");
            var requestUri = RequestConstants.RequestUri + OrderValue;
            var result = _paymentGatewayClient.GetAsync(requestUri).Result; //pseudo payment gateway call
            
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Payment processed successfully");
            }
            else
            {
                LogPaymentFailure(result);
            }

            return products.Count();
        }

        private void LogPaymentFailure(HttpResponseMessage result)
        {
            switch (result.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    throw new ArgumentException("Invalid customer : " + _customerId);
                default:
                    _logger.write("Error in processing payment " + _customerId);
                    break;
            }
        }


    }
}
