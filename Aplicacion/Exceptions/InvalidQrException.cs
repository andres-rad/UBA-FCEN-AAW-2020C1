using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Exceptions
{
    public class InvalidQrException: Exception 
    {

        public InvalidQrException() : base() { }
        public InvalidQrException(string message) : base(message) { }
        
    }
}
