using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Propietarios
{
    class Propietario
    {
        public int UserId { get; set; }

        List<Turnero> _turneros;

        private Propietario() { }

        public Propietario(int userId) 
        {
            UserId = userId;
        }

        public void AgregarTurnero(Turnero turnero)
        {
            _turneros.Add(turnero);
        }

        public void EliminarTurnero(Turnero turnero)
        {
            _turneros.Remove(turnero);
        }
    }
}
