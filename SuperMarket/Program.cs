using SuperMarket.Client;
using SuperMarket.Logging;
using SuperMarket.Repository;
using SuperMarket.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SuperMarket
{    
    class Program
    {    
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter your customer id ->");
            int customerId = Int32.Parse(Console.ReadLine());
            while(customerId.ToString() == null)
            {
                Console.WriteLine("Customer id cannot be empty.");
                customerId = Int32.Parse(Console.ReadLine());
            }
            var stockService = new StockService(new StockRepository());
            var discountService = new DiscountService(new DiscountRepository());
            var paymentGateWay = new PaymentGatewayClient(new HttpClient());
            var logger = new Logger();
            List<string> items = new List<string>()
            {
                "Breads",
                "Milk",
                "Cheese",
                "Butter",
                "Biscuits",
                "Dryfruits"
            };
            ShoppingService shopping = new ShoppingService(customerId, stockService, discountService, paymentGateWay, logger);
            var count = shopping.BuyItems(items);
            Console.WriteLine($"Shopping done for {count} products ");
        }
    }
}
