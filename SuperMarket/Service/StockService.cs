using SuperMarket.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using SuperMarket.Models; 

namespace SuperMarket.Service
{
  public class StockService : IStockService
    {

        IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IEnumerable<ProductsDataModel> CheckStockStatus(List<string> items)
        {
            IEnumerable<ProductsDataModel> products = _stockRepository.CheckStockStatus(items );
            return products;
        }
    }
}
