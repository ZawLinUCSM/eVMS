using CMS.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Repositories.Interfaces
{
    public interface IEVoucherRepository
    {
        Task<IEnumerable<Voucher>> GetVouchers();
        Task<Voucher> GetVoucherDetail(string voucherGuid);
        Task<bool> SaveVoucher(Voucher voucher);
        Task<bool> UpdateVoucher(Voucher voucher);
        Task<bool> DeActivate(Voucher voucher);
    }
}
