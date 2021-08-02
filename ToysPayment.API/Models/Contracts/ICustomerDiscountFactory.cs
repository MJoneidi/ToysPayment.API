namespace ToysPayment.API.Models.Contracts
{
    public interface ICustomerDiscountFactory
    {
        IDiscountCalculator GetCustomerDiscountCalculator(decimal currentPoints);
    }
}
