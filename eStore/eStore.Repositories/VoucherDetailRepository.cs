using eStore.Repositories.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Repositories
{
    public class VoucherDetailRepository : RepositoryBase<Voucher>, IVoucherDetailRepository
    {
        public VoucherDetailRepository(eVoucherContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<VoucherDetail>> GetVoucherDetails(string userGuid)
        {
            var query = RepositoryContext.VoucherDetail.Where(c => c.VoucherGuid == userGuid);
            return await query.ToListAsync();
        }

        public async Task<Voucher> GetVoucherDetail(string voucherGuid)
        {
            var query = RepositoryContext.Voucher
                .Where(c => c.Guid==voucherGuid)
                .Include(voucher => voucher.VoucherDetail);
        


            return await query.FirstOrDefaultAsync();
        }
    }
}
