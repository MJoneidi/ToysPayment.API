using ToysPayment.API.Application.MembershipApp.Point;
using ToysPayment.API.Models.Contracts;

namespace ToysPayment.API.Application.MembershipApp.Discount
{
    public class CustomerDiscountFactory : ICustomerDiscountFactory
    {
        private readonly IApplicationConfiguration _applicationConfiguration;

        //should work 
        public CustomerDiscountFactory(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        public IDiscountCalculator GetCustomerDiscountCalculator(decimal currentPoints)
        {
            switch (currentPoints)
            {
                case 0:
                    return new DefaultDiscountCalculator();
                case < 100:
                    return new SilverCustomerDiscountCalculator(_applicationConfiguration);
                case < 500:
                    return new GoldCustomerDiscountCalculator(_applicationConfiguration);
                case >= 500:
                    return new PlatiniumCustomerDiscountCalculator(_applicationConfiguration);
            }
        }
    }
}
