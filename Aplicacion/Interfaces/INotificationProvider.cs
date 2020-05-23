using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    public interface INotificationProvider
    {
        void Send(string message, string toAddress);
    }
}
