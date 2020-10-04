using eStore.Repositories.Interfaces;
using Entities.Models;
using eStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using PromoCode_MS;
using System;

namespace eStore.Services
{
    public class PaymentService : IPaymentService
    {
        readonly IPaymentRepository _paymentRepository;
        readonly IEVoucherRepository _evoucherRepository;
        public PaymentService(IPaymentRepository paymentRepository, IEVoucherRepository eVoucherRepository)
        {
            _paymentRepository = paymentRepository;
            _evoucherRepository = eVoucherRepository;
        }

        public async Task<IEnumerable<PaymentType>> GetPaymentTypes()
        {
            return await _paymentRepository.GetPaymentTypes();
        }

        public async Task<bool> DoPayment(Voucher voucher)
        {
            var paidSuccess = true;// with VISA , Master or something           
            if (paidSuccess)
            {                
                voucher.Guid = Guid.NewGuid().ToString();                
                voucher.VoucherDetail = CreateVoucherDetails(voucher);
            }
            return await _evoucherRepository.SaveVoucher(voucher);           
        }
        private List<VoucherDetail> CreateVoucherDetails(Voucher voucher)
        {
            var orderQty = (int)voucher.Qty;
            eVoucherGenerator generator = new eVoucherGenerator();
            var eVouchers = generator.Create(orderQty);          
            List<VoucherDetail> voucherDetails = new List<VoucherDetail>();
            foreach (var item in eVouchers)
            {
                VoucherDetail detail = new VoucherDetail();
                detail.Guid = Guid.NewGuid().ToString();
                detail.VoucherGuid = voucher.Guid;
                detail.PromoCodeStatus = false;// unused (new)
                detail.PromoCode = item.PromoCode;
                detail.Qrcode = item.QRCode;
                voucherDetails.Add(detail);
            }
            return voucherDetails;
        }
    }
}
