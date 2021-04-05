using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Service
{
   public interface IStockService
    {
        IEnumerable<ProductsDataModel> CheckStockStatus(List<string> items );
    }
}
