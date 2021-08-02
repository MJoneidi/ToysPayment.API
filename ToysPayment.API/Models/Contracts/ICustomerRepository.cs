using System.Threading.Tasks;
using ToysPayment.API.Models.Entities;

namespace ToysPayment.API.Models.Contracts
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task UpdateCustomerAsync(Customer customer);
    }
}