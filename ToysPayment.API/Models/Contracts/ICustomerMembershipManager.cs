using System.Threading.Tasks;

namespace ToysPayment.API.Models.Contracts
{
    public interface ICustomerMembershipManager
    {
        decimal CalculateDiscount(decimal amount);


        Task<decimal> ApplyPointsAsync(decimal amount, decimal discount);
        Task<bool> SetCustomerAsync(int customerID);
    }
}
