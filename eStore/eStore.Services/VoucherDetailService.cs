using eStore.Repositories.Interfaces;
using Entities.Models;
using eStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStore.Services
{
    public class VoucherDetailService : IVoucherDetailService
    {
        readonly IVoucherDetailRepository _voucherDetailRepository;
        public VoucherDetailService(IVoucherDetailRepository voucherDetailRepository)
        {
            _voucherDetailRepository = voucherDetailRepository;
        }

        public async Task<IEnumerable<VoucherDetail>> GetVoucherDetails(string userGuid)
        {
            return await _voucherDetailRepository.GetVoucherDetails(userGuid);
        }

        public async Task<Voucher> GetVoucherDetail(string voucherGuid)
        {
            return await _voucherDetailRepository.GetVoucherDetail(voucherGuid);
        }
    }
}
