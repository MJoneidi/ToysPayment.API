using System.Threading.Tasks;
using ToysPayment.API.Models.Dto;

namespace ToysPayment.API.Models.Contracts
{
    public interface IPaymentProcessor
    {
        Task<PaymentResponse> ProcessAsync(PaymentRequest paymentRequest);
    }
}
