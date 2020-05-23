using Aplicacion.Interfaces;
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
            return "soyunqr_codificado";
        }
    }
}
