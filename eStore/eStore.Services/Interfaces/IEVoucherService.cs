using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Services.Interfaces
{
    public interface IEVoucherService
    {
        Task<IEnumerable<Voucher>> GetVouchers();
        Task<Voucher> GetVoucherDetail(string voucherGuid);
        Task<PurchaseHistory> GetPurchaseHistories(string customerGuid);
        Task<bool> CheckPromoCode(string promocode);
        Task<bool> Create(Voucher voucher);
        Task<bool> Update(Voucher voucher);
        Task<bool> Delete(Voucher voucher);
    }
}
