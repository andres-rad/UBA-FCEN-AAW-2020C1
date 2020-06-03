using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Turno
    {
        public int Id { get; private set; }
        public int TurneroId { get; private set; }
        public int Numero { get; private set; }
        public string Email { get; private set; }
    }
}
