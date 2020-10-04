using CMS.Repositories.Interfaces;
using CMS.Repositories.Models;
using CMS.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class EVoucherSerivces : IEVoucherServices
    {
        readonly IEVoucherRepository _evoucherRepository;
        public EVoucherSerivces(IEVoucherRepository eVoucherRepository)
        {
            _evoucherRepository = eVoucherRepository;
        }

        public async Task<bool> Create(Voucher voucher)
        {
            await _evoucherRepository.SaveVoucher(voucher);
            return true;
        }

        public async Task<bool> Update(Voucher voucher)
        {
            await _evoucherRepository.UpdateVoucher(voucher);
            return true;
        }

        public async Task<bool> Delete(Voucher voucher)
        {
            // Just deactivate the item
            voucher.Status = "Inactive";
            await _evoucherRepository.DeActivate(voucher);
            return true;
        }

        public async Task<IEnumerable<Voucher>> GetVouchers()
        {
            return await _evoucherRepository.GetVouchers();
        }
        public async Task<Voucher> GetVoucherDetail(string voucherGuid)
        {
            return await _evoucherRepository.GetVoucherDetail(voucherGuid);
        }
    }
}
