using eStore.Repositories.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStore.Repositories
{
    public class PaymentRepository : RepositoryBase<Voucher>, IPaymentRepository
    {
        public PaymentRepository(eVoucherContext repositoryContext) : base(repositoryContext)
        {

        }
    

        public async Task<IEnumerable<PaymentType>> GetPaymentTypes()
        {
            var query = RepositoryContext.PaymentType;
            return await query.ToListAsync();
        }

        public async Task<bool> DoPayment(Voucher voucher)
        {
            throw new NotImplementedException();
        }
    }
}
