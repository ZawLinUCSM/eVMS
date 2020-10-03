using eStore.Repositories.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace eStore.Repositories
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

        public async Task<Voucher> GetVoucherDetail(string voucherGuid)
        {
            var query = RepositoryContext.Voucher
                .Where(c => c.Guid == voucherGuid)
                .Include(voucher => voucher.VoucherDetail);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PurchaseHistory> GetPurchaseHistories(string customerGuid)
        {
            var query = from d in RepositoryContext.VoucherDetail
                        join v in RepositoryContext.Voucher
                        on d.VoucherGuid equals v.Guid
                        where v.CustomerGuid == customerGuid
                        select d;

            var unusedHistory = query.Where(c => c.PromoCodeStatus == false);
            var usedHistory = query.Where(c => c.PromoCodeStatus == true);

            var usedVouchers = await usedHistory.ToListAsync();
            var unusedVouchers = await unusedHistory.ToListAsync();
            var purchaseHistory = new PurchaseHistory()
            {
                Used = usedVouchers,
                UnUsed = unusedVouchers
            };
            return purchaseHistory;
        }

        public async Task<bool> CheckPromoCode(string promocode)
        {
            var query = RepositoryContext.VoucherDetail.Where(c => c.PromoCode == promocode);
            var voucherDetail = await query.FirstOrDefaultAsync();
            if (voucherDetail != null && !string.IsNullOrEmpty(voucherDetail.Guid))
                return true;
            else return false;

        }

    }
}
