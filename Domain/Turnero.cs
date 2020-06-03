using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Domain
{
    public class Turnero
    {
        public int PropietarioId { get; }
        public string Concepto { get; }
        public LatLon Ubicacion { get; }
        public Direccion Direccion{ get; }

        List<Turno> _turnos;

        public Turnero(int propietarioId, string concepto, LatLon ubicacion)
        {
            PropietarioId = propietarioId;
            Concepto = concepto;
            Ubicacion = ubicacion;
            _turnos = new List<Turno>();
        }

        public Turno ExpedirTurno()
        {
            var turno = new Turno()
            {

            };

            _turnos.Add(turno);

            return turno;
        }

        public Turno ProximoTurno()
        {
            return _turnos.FirstOrDefault();
        }

        public void Avanzar()
        {
            _turnos.RemoveAt(0);
        }
    }
}
