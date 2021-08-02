using ToysPayment.API.Application.MembershipApp.Point;
using ToysPayment.API.Models.Contracts;

namespace ToysPayment.API.Application.MembershipApp.Discount
{
    public class CustomerPointFactory : ICustomerPointFactory
    {
        private readonly IApplicationConfiguration _applicationConfiguration;

        //should work 
        public CustomerPointFactory(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }
        public IPointCalculator GetCustomerPointCalculator(decimal currentPoints)
        {
            switch (currentPoints)
            {
                case 0:
                    return new DefaultPointCalculator();
                case < 100:
                    return new SilverCustomerPointCalculator(_applicationConfiguration);
                case < 500:
                    return new GoldCustomerPointCalculator(_applicationConfiguration);
                case >= 500:
                    return new PlatiniumCustomerPointCalculator(_applicationConfiguration);
            }
        }
    }
}
