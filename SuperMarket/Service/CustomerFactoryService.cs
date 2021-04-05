namespace SuperMarketAssessment
{
    public abstract class CustomerFactoryService
    {
        public abstract ICustomer GetCustomer();
    }
    public class PlatinumCustomerFactory : CustomerFactoryService
    {
        private int customerId;
        private double discountPercent;

        public PlatinumCustomerFactory(int customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public override ICustomer GetCustomer()
        {
            return new platinumCustomer(customerId, discountPercent);
        }
    }

    public class GoldCustomerFactory : CustomerFactoryService
    {
        private int customerId;
        private double discountPercent;

        public GoldCustomerFactory(int customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public override ICustomer GetCustomer()
        {
            return new GoldCustomer(customerId, discountPercent);
        }
    }

    public class SilverCustomerFactory : CustomerFactoryService
    {
        private int customerId;
        private double discountPercent;

        public SilverCustomerFactory(int customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public override ICustomer GetCustomer()
        {
            return new SilverCustomer(customerId, discountPercent);
        }
    }

    public class DefaultCustomerFactory : CustomerFactoryService
    {
        private int customerId;
        private double discountPercent;

        public DefaultCustomerFactory(int customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public override ICustomer GetCustomer()
        {
            return new DefaultCustomer(customerId, discountPercent);
        }
    }
}
 
