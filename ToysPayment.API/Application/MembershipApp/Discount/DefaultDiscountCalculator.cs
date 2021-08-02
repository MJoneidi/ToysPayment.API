using ToysPayment.API.Models.Contracts;

namespace ToysPayment.API.Application.MembershipApp.Discount
{
    public class DefaultDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(decimal amount, decimal points) => 0;
    }
}
