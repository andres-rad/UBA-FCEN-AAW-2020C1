using Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructura
{
    public class EmailNotificationProvider : INotificationProvider
    {
        public void Send(string message, string toAddress)
        {
            //Send email
        }
    }
}
