using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Repository
{
    public class StockRepository : IStockRepository
    {
        public IEnumerable<ProductsDataModel> CheckStockStatus(List<string> items )
        {
            Random randomNumbers = new Random();
            List<ProductsDataModel> products = new List<ProductsDataModel>();
            for (int i = 0; i < items.Count; i++)
            {
                ProductsDataModel product = new ProductsDataModel();
                product.Name = items[i];
                product.Price = randomNumbers.Next(100, 1000); //pseudo logic to assign random price

                if (randomNumbers.Next(0, 10) % 3 != 0) //some pseudo logic to recreate in-stock / out-of-stock scenario
                {
                    products.Add(product);
                }
            }
            return products;
        }
    }
}
