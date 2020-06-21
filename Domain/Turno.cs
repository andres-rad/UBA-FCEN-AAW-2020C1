using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Turno
    {
        public int Id { get; internal set; }
        public int TurneroId { get; internal set; }
        public int Numero { get; internal set; }
        public string Email { get; internal set; }
        public int Orden { get; set; }

        public Turno(int turneroId, int numero, string email, int orden)
        {
            TurneroId = turneroId;
            Numero = numero;
            Email = email;
            Orden = orden;
        }
    }
}
