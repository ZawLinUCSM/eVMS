using CMS.Repositories.Interfaces;
using CMS.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public class EVoucherRepository : RepositoryBase<Voucher>, IEVoucherRepository
    {
        public EVoucherRepository(eVoucherContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<bool> SaveVoucher(Voucher voucher)
        {
            try
            {
                await CreateAsync(voucher);                              
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> UpdateVoucher(Voucher voucher)
        {
            try
            {
                await UpdateAsync(voucher);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeActivate(Voucher voucher)
        {
            try
            {
                await UpdateAsync(voucher);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Voucher>> GetVouchers()
        {
            var query = RepositoryContext.Voucher.Where(c=>c.Status=="Active");
            return await query.ToListAsync();
        }

        public async Task<Voucher> GetVoucherDetail(string voucherGuid)
        {
            var query = RepositoryContext.Voucher
                .Where(c => c.Guid == voucherGuid)
                .Include(voucher => voucher.VoucherDetail);

            return await query.FirstOrDefaultAsync();
        }
    }
}
