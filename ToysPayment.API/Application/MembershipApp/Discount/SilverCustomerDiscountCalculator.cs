using System;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Enums;

namespace ToysPayment.API.Application.MembershipApp.Discount
{
    public class SilverCustomerDiscountCalculator : IDiscountCalculator
    {
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly MembershipType _membershipType;

        public SilverCustomerDiscountCalculator(IApplicationConfiguration applicationConfiguration)
        {
            _membershipType = MembershipType.Silver;
            _applicationConfiguration = applicationConfiguration;
        }
        public decimal CalculateDiscount(decimal amount, decimal points)
        {
            var discount = points * _applicationConfiguration.MembershipsList[_membershipType].DiscountPercentage / 100;
           
            
            if (discount > amount)
                discount = amount;
            if (discount > _applicationConfiguration.MaxDiscount)
                discount= _applicationConfiguration.MaxDiscount;

            return Math.Floor(discount);
        }
    }
}
