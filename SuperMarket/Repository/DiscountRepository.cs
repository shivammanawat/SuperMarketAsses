using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMarket.Constant;

namespace SuperMarket.Repository
{
    public class DiscountRepository : IDiscountRepository
    {

        public double ApplyDiscount(int customerId, double totalPrice)
        {
           
            if (CustomerType.platinumCustomers.Contains(customerId) )
            {
                return totalPrice - (totalPrice * DiscountRatesConstants.discountPercent1 / DiscountRatesConstants.TotalPercentage);
            }
            else if (CustomerType.goldCustomers.Contains(customerId))
            {
                return totalPrice - (totalPrice * DiscountRatesConstants.discountPercent2 / DiscountRatesConstants.TotalPercentage);
            }
            else if (CustomerType.silverCustomers.Contains(customerId))
            {
                return totalPrice - (totalPrice * DiscountRatesConstants.discountPercent3 / DiscountRatesConstants.TotalPercentage);
            }
            else if(!CustomerType.platinumCustomers.Contains(customerId) && CustomerType.goldCustomers.Contains(customerId) && CustomerType.silverCustomers.Contains(customerId))
            {
                return totalPrice;
            }
            return totalPrice;
        }

    }
}
