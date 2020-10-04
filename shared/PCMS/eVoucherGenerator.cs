using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCode_MS
{
    public class eVoucherGenerator
    {


        /// <summary>
        /// Create evoucher code and return
        /// </summary>
        /// <param name="numberofVoucher"></param>
        /// <returns>List of eVouchers based on the numberofVoucher</returns>
        public List<eVoucher> Create(int numberofVoucher)
        {
            List<eVoucher> eVouchers = new List<eVoucher>();
            for (int i = 0; i < numberofVoucher; i++)
            {
                PromoCode promoCode = new PromoCode();
                QRCode qRCode = new QRCode();

                var code = promoCode.Create();
                var _qr = qRCode.Create(code);

                eVoucher eVoucher = new eVoucher();
                eVoucher.PromoCode = code;
                eVoucher.QRCode = _qr;
                eVouchers.Add(eVoucher);// Add to collection
            }

            return eVouchers;
        }
    }
}
