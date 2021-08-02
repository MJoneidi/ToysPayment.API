namespace ToysPayment.API.Models.Contracts
{
    public interface ICustomerPointFactory
    {
        IPointCalculator GetCustomerPointCalculator(decimal currentPoints);
    }
}
