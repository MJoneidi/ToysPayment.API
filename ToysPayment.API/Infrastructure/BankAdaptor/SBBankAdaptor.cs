using System.Threading.Tasks;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Entities;

namespace ToysPayment.API.Infrastructure.BankAdaptor
{
    public class SBBankAdaptor : IBankAdaptor
    {
        public SBBankAdaptor()
        {
            //load bank service url from config or db
        }

        public async Task<bool> DoPaymentAsync(decimal amount, CardInfo card)
        {
            return await Task.FromResult(true);
            //  throw new NotImplementedException();
        }
    }
}
