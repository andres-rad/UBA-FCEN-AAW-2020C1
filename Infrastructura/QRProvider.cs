using Aplicacion.Interfaces;
using QRCoder;
using System;

namespace Infrastructura
{
    public class QRProvider : IQRProvider
    {
        public string Decode(string qr)
        {
            return "soyunqr_decodificado";
        }
        //
        public string Encode(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20);

            return qrCodeImageAsBase64;
        }
    }
}
