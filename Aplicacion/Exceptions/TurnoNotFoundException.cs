using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Exceptions
{
    public class TurnoNotFoundException : Exception 
    {
        public TurnoNotFoundException() : base() {}
        public TurnoNotFoundException(string message) : base(message) {}
    }
}
