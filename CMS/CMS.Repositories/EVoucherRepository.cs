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
            var query = RepositoryContext.Voucher;
            return await query.ToListAsync();
        }


    }
}
