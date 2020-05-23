using System;
using System.Collections.Generic;
using System.Threading;

namespace Domain
{
    public class Turnero
    {

        List<Turno> _turnos;

        public Turnero()
        {
            _turnos = new List<Turno>();
        }

        public Turno NuevoTurno()
        {
            var turno = new Turno();

            _turnos.Add(turno);

            return turno;
        }
    }
}
