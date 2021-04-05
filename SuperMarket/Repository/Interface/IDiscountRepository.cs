using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Repository
{
    public interface IDiscountRepository
    {
        double ApplyDiscount(int customerId, double totalPrice );
    }
}
