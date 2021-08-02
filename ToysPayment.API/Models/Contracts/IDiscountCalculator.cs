namespace ToysPayment.API.Models.Contracts
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(decimal amount, decimal points);
    }
}
