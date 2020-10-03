using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStore.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentType>> GetPaymentTypes();
        Task<bool> DoPayment(Voucher voucher);
    }
}
