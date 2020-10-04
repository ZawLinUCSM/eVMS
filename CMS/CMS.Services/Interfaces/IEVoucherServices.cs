using CMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Interfaces
{
    public interface IEVoucherServices
    {
        Task<IEnumerable<Voucher>> GetVouchers();
        Task<Voucher> GetVoucherDetail(string voucherGuid);
        Task<bool> Create(Voucher voucher);
        Task<bool> Update(Voucher voucher);
        Task<bool> Delete(Voucher voucher);
    }
}
