using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStore.Repositories.Interfaces
{
    public interface IEVoucherRepository
    {
        Task<IEnumerable<Voucher>> GetVouchers();
        Task<Voucher> GetVoucherDetail(string voucherGuid);
        Task<PurchaseHistory> GetPurchaseHistories(string customerGuid);
        Task<bool> CheckPromoCode(string promocode);
        Task<bool> SaveVoucher(Voucher voucher);
        Task<bool> UpdateVoucher(Voucher voucher);
        Task<bool> DeActivate(Voucher voucher);
    }
}
