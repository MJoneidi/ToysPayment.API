using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using ToysPayment.API.Models;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Enums;

namespace ToysPayment.API.Application.Configurations
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public ApplicationConfiguration(IConfiguration configuration)
        {
            decimal decimalValue;
            
            if (decimal.TryParse(configuration["CustomerMemberships:MinTotalBuy"], out decimalValue))
                this.MinTotalBuy = decimalValue;
            else
                this.MinTotalBuy = 100; //default value

            if (decimal.TryParse(configuration["CustomerMemberships:MaxDiscount"], out decimalValue))
                this.MaxDiscount = decimalValue;
            else
                this.MaxDiscount = 1000; //default value

            int discountPercentage;
            decimal amount;
            decimal point;

            int.TryParse(configuration["CustomerMemberships:Silver:DiscountPercentage"], out discountPercentage);
            decimal.TryParse(configuration["CustomerMemberships:Silver:MinBuy:Amount"], out amount);
            decimal.TryParse(configuration["CustomerMemberships:Silver:MinBuy:Point"], out point);

            var silver = new CustomerMembership() { DiscountPercentage = discountPercentage , BuyPoint = new BuyPoint { Amount = amount, Point = point } };

            int.TryParse(configuration["CustomerMemberships:Gold:DiscountPercentage"], out discountPercentage);
            decimal.TryParse(configuration["CustomerMemberships:Gold:MinBuy:Amount"], out amount);
            decimal.TryParse(configuration["CustomerMemberships:Gold:MinBuy:Point"], out point);
            var gold = new CustomerMembership() { DiscountPercentage = discountPercentage, BuyPoint = new BuyPoint { Amount = amount, Point = point } };

            int.TryParse(configuration["CustomerMemberships:Platinum:DiscountPercentage"], out discountPercentage);
            decimal.TryParse(configuration["CustomerMemberships:Platinum:MinBuy:Amount"], out amount);
            decimal.TryParse(configuration["CustomerMemberships:Platinum:MinBuy:Point"], out point);
            var platinum = new CustomerMembership() { DiscountPercentage = discountPercentage, BuyPoint = new BuyPoint { Amount = amount, Point = point } };

            MembershipsList = new Dictionary<MembershipType, CustomerMembership>();
            MembershipsList.Add(MembershipType.Silver, silver);
            MembershipsList.Add(MembershipType.Gold, gold);
            MembershipsList.Add(MembershipType.Platinum, platinum);
        }

        public Dictionary<MembershipType, CustomerMembership> MembershipsList { get; }
        public decimal MaxDiscount { get; }
        public decimal MinTotalBuy { get; }
    }
}
