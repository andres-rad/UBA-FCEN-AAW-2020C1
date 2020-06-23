using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Aplicacion.Exceptions
{
    public class TurneroNotFoundException : Exception
    {
        public TurneroNotFoundException(string message): base(message)
        {
            
        }
    }
}
