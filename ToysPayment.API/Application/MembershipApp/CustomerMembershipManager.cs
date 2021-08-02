using System;
using System.Threading.Tasks;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Entities;

namespace ToysPayment.API.Application.MembershipApp
{
    public class CustomerMembershipManager : ICustomerMembershipManager
    {
        private readonly ICustomerDiscountFactory _customerDiscountFactory;
        private readonly ICustomerPointFactory _customePointFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly IApplicationConfiguration _applicationConfiguration;
        private Customer _customer;

        public CustomerMembershipManager(ICustomerDiscountFactory customerDiscountFactory, ICustomerPointFactory customePointFactory, ICustomerRepository customerRepository, IApplicationConfiguration applicationConfiguration)
        {
            _customerDiscountFactory = customerDiscountFactory;
            _customePointFactory = customePointFactory;
            _customerRepository = customerRepository;
            _applicationConfiguration = applicationConfiguration;
        }

        public async Task<bool> SetCustomerAsync(int customerID)
        {
            var customer = await _customerRepository.GetByIdAsync(customerID);
            if (customer != null)
            {
                _customer = customer;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public decimal CalculateDiscount(decimal amount)
        {
            if (_customer != null && _customer.TotalBuy >= _applicationConfiguration.MinTotalBuy)
                return _customerDiscountFactory.GetCustomerDiscountCalculator(_customer.Points).CalculateDiscount( amount, _customer.Points);
            else
                return 0;
        }

        public async Task<decimal> ApplyPointsAsync(decimal amount, decimal discount)
        {
            if (_customer != null)
            {
                var newPoints = _customePointFactory.GetCustomerPointCalculator(_customer.Points).CalculateNewPoint(amount);

                //customerPointCalculator.CalculateUsedPoint(amount);
               
               
                _customer.Points += newPoints - discount;
                _customer.TotalBuy += amount;

                if (_customer.TotalBuy >= _applicationConfiguration.MinTotalBuy && _customer.Points == 0)
                    _customer.Points = 1;

                await _customerRepository.UpdateCustomerAsync(_customer);

                return _customer.Points;
            }
            else
                throw new Exception("Internal error");
        }
    }
}
