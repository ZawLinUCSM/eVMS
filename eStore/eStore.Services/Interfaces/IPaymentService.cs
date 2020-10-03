using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentType>> GetPaymentTypes();
        Task<bool> DoPayment(Voucher voucher);       
    }
}
