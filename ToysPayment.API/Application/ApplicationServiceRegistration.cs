using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToysPayment.API.Application.Configurations;
using ToysPayment.API.Application.Mappers;
using ToysPayment.API.Application.MembershipApp;
using ToysPayment.API.Application.MembershipApp.Discount;
using ToysPayment.API.Application.Processors;
using ToysPayment.API.Models.Contracts;

namespace ToysPayment.API.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IApplicationConfiguration>(x => new ApplicationConfiguration(configuration));

            services.AddScoped<IPaymentProcessor, PaymentProcessor>();
            services.AddScoped<ICustomerMembershipManager, CustomerMembershipManager>();
            services.AddScoped<ICustomerDiscountFactory, CustomerDiscountFactory>();
            services.AddScoped<ICustomerPointFactory, CustomerPointFactory>();

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper());

            //services.AddScoped<ICommandHandler<CreatePaymentCommand>, PaymentCommandHandler>();
            //services.AddScoped<IPaymentProcessor, PaymentProcessor>();
            return services;
        }
    }
}
