using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    public interface IQRProvider
    {
        string Encode(string data);
        string Decode(string qr);
    }
}
