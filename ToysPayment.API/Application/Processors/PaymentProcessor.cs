using AutoMapper;
using System.Threading.Tasks;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Dto;
using ToysPayment.API.Models.Entities;

namespace ToysPayment.API.Application.Processors
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly ICustomerMembershipManager _customerMembershipManager;
        private readonly IBankAdaptor _bankAdaptor;
        private readonly IMapper _mapper;

        public PaymentProcessor(ICustomerMembershipManager customerMembershipManager, IBankAdaptor bankAdaptor, IMapper mapper)
        {
            _customerMembershipManager = customerMembershipManager;
            _bankAdaptor = bankAdaptor;
            _mapper = mapper;
        }


        public async Task<PaymentResponse> ProcessAsync(PaymentRequest request)
        {
            try
            {
                decimal discount = 0;
                decimal newAmount = request.Amount;
                if (await _customerMembershipManager.SetCustomerAsync(request.CustomerID))  //isValidCustomer
                {
                    discount = _customerMembershipManager.CalculateDiscount(request.Amount);
                    newAmount = request.Amount - discount;
                }

                var card = _mapper.Map<CardInfo>(request);
                var response = await _bankAdaptor.DoPaymentAsync(newAmount, card);
                if (response)
                {
                   var point= await _customerMembershipManager.ApplyPointsAsync(request.Amount, discount);
                    return await Task.FromResult(new PaymentResponse { Discount = discount, Point= point });
                }
                return await Task.FromResult(new PaymentResponse());
            }
            catch
            {
                //need to handle the log
                return await Task.FromResult(new PaymentResponse());
            }
        }
    }
}
