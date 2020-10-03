using eStore.Repositories.Interfaces;
using Entities.Models;
using eStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace eStore.Services
{
    public class EVoucherSerivce : IEVoucherService
    {
        readonly IEVoucherRepository _evoucherRepository;
        public EVoucherSerivce(IEVoucherRepository eVoucherRepository)
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

        public async Task<PurchaseHistory> GetPurchaseHistories(string customerGuid)
        {
            return await _evoucherRepository.GetPurchaseHistories(customerGuid);
        }

        public async Task<bool> CheckPromoCode(string promocode)
        {
            return await _evoucherRepository.CheckPromoCode(promocode);
        }
    }
}
