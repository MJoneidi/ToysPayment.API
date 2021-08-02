using System.Threading.Tasks;
using ToysPayment.API.Models.Entities;

namespace ToysPayment.API.Models.Contracts
{
    public interface IBankAdaptor
    {
        Task<bool> DoPaymentAsync(decimal amount, CardInfo card);
    }
}
