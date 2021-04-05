using System;
using System.Collections.Generic;
using System.Text;
using SuperMarket.Models;

namespace SuperMarket.Repository
{
    public interface IStockRepository
    {
        IEnumerable<ProductsDataModel> CheckStockStatus(List<string> items );
    }
}
