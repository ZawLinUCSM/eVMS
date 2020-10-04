using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PromoCode_MS
{
    public class QRCode
    {
        public string Create(string encodedText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(encodedText, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            //string qrCodeImageAsBase64 = qrCode.GetGraphic(20);
            var imgType = Base64QRCode.ImageType.Jpeg;
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20, Color.Black, Color.White, true, imgType);
            return qrCodeImageAsBase64;
        }

        public string Based64ToHTML(string qrCodeImageAsBase64)
        {
            var imgType = Base64QRCode.ImageType.Jpeg;
            var htmlPictureTag = $"<img alt=\"Embedded QR Code\" src=\"data:image/{imgType.ToString().ToLower()};base64,{qrCodeImageAsBase64}\" />";
            return htmlPictureTag;
        }
    }
}
