using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Service
{
    public interface IDiscountService
    {
        double ApplyDiscount(int customerId,double totalPrice );
    }
}
