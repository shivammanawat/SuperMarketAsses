using System;
using System.Collections.Generic;
using System.Text;
using SuperMarket.Repository;
using SuperMarket.Service;
namespace SuperMarket.Service
{
    public class DiscountService : IDiscountService
    {
        public IDiscountRepository _discountRepository;
        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public double ApplyDiscount(int customerId, double totalPrice)
        {
            var discountedPrices =  _discountRepository.ApplyDiscount(customerId, totalPrice );
            return discountedPrices;
        }

    }
}
