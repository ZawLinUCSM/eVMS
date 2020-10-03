using eStore.Repositories.Interfaces;
using Entities.Models;
using eStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStore.Services
{
    public class PaymentService : IPaymentService
    {
        readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<PaymentType>> GetPaymentTypes()
        {
            return await _paymentRepository.GetPaymentTypes();
            //throw new System.NotImplementedException();
        }

        public async Task<bool> DoPayment(Voucher voucher)
        {
            throw new System.NotImplementedException();
        }
    }
}
