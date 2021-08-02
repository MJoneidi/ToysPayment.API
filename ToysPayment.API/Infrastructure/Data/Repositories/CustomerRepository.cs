using System.Threading.Tasks;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Entities;

namespace ToysPayment.API.Infrastructure.Data.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext) { }

        public async Task UpdateCustomerAsync(Customer entity)
        {
            _dbContext.Customers.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}