using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStore.Services.Interfaces
{
    public interface IVoucherDetailService
    {
        Task<IEnumerable<VoucherDetail>> GetVoucherDetails(string userGuid);
        Task<Voucher> GetVoucherDetail(string voucherGuid);        
    }
}
