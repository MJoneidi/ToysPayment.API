using ToysPayment.API.Models.Contracts;

namespace ToysPayment.API.Application.MembershipApp.Point
{
    public class DefaultPointCalculator : IPointCalculator
    {
        public int CalculateNewPoint(decimal price) => 0;
    }
}
