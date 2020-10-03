using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStore.Repositories.Interfaces
{
    public interface IVoucherDetailRepository
    {
        Task<IEnumerable<VoucherDetail>> GetVoucherDetails(string userGuid);
        Task<Voucher> GetVoucherDetail(string voucherGuid);
    }
}
