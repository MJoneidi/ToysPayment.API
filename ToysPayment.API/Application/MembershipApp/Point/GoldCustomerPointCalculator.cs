using System;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Enums;

namespace ToysPayment.API.Application.MembershipApp.Point
{
    public class GoldCustomerPointCalculator : IPointCalculator
    {
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly MembershipType _membershipType;

        public GoldCustomerPointCalculator(IApplicationConfiguration applicationConfiguration)
        {
            _membershipType = MembershipType.Gold;
            _applicationConfiguration = applicationConfiguration;
        }

        public int CalculateNewPoint(decimal amount)
        {
            var membership = _applicationConfiguration.MembershipsList[_membershipType];
            return Convert.ToInt32(amount / membership.BuyPoint.Amount * membership.BuyPoint.Point);
        }
    }
}
