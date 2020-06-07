using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Domain
{
    public class Turnero
    {
        public int Id { get; internal set; }
        public int PropietarioId { get; internal set; }
        public string Concepto { get; internal set; }
        public LatLon Ubicacion { get; internal set; }
        public Direccion Direccion{ get; internal set; }

        List<Turno> _turnos;

        private Turnero() { }

        public Turnero(int propietarioId, string concepto, LatLon ubicacion, Direccion direccion)
        {
            PropietarioId = propietarioId;
            Concepto = concepto;
            Ubicacion = ubicacion;
            Direccion = direccion;
            _turnos = new List<Turno>();
        }

        public Turnero(int propietarioId, string concepto, /*LatLon ubicacion,*/ Direccion direccion)
        {
            PropietarioId = propietarioId;
            Concepto = concepto;
            //Ubicacion = ubicacion;
            Direccion = direccion;
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

        public void Cancelar(int idTurno)
        {
            var turno = _turnos.Find(turno => turno.Id == idTurno);
            _turnos.Remove(turno);
        }
    }
}
