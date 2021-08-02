using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToysPayment.API.Infrastructure.BankAdaptor;
using ToysPayment.API.Infrastructure.Data;
using ToysPayment.API.Infrastructure.Data.Repositories;
using ToysPayment.API.Models.Contracts;

namespace ToysPayment.API.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBankAdaptor, SBBankAdaptor>();

            services.AddDbContext<CustomerDbContext>(options =>
                   options.UseInMemoryDatabase(databaseName: "CustomerDb"));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
