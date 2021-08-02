namespace ToysPayment.API.Models.Contracts
{
    public interface IPointCalculator
    {
        int CalculateNewPoint(decimal amount);
        //int CalculateUsedPoint(decimal amount);
    }
}
