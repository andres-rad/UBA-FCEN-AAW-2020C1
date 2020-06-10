using Dominio;
using System.Collections.Generic;
using System.Linq;
using QRCoder;
using System;

namespace Domain
{
    public class Turnero
    {
        public int Id { get; internal set; }
        public string IdPropietario { get; internal set; }
        public string Concepto { get; internal set; }
        public LatLon Ubicacion { get; internal set; }
        public Direccion Direccion { get; internal set; }
        public int CantidadMaxima { get; internal set; }

        public int ProximoId { get; internal set; }

        public  List<Turno> _turnos {  get;  internal set; } 

        private Turnero() {
        }

        public Turnero(string idPropietario, string concepto, LatLon ubicacion, Direccion direccion, int cantidaMaxima)
        {
            IdPropietario = idPropietario;
            Concepto = concepto;
            Direccion = direccion;
            Ubicacion = ubicacion;
            _turnos = new List<Turno>();
            CantidadMaxima = cantidaMaxima;
            ProximoId = 1;
        }

        public void Actualizar(string concepto, LatLon ubicacion, Direccion direccion, int cantidad)
        {
            Concepto = concepto;
            Ubicacion = ubicacion;
            Direccion = direccion;
            CantidadMaxima = cantidad;
        }

        public Turno ExpedirTurno(string email)
        {
            if (_turnos.Count == CantidadMaxima) 
                throw new Exception("Cantidad maxima alcanzada, no se puede expedir turnos por el momento");

            var turno = new Turno(this.Id, _turnos.Count + 1, email);
            ProximoId += 1;
            _turnos.Add(turno);

            return turno;
        }

        public Turno ProximoTurno()
        {
            return _turnos.FirstOrDefault();
        }

        public void Avanzar()
        {
            if(_turnos.Count > 0)
                _turnos.RemoveAt(0);
        }

        public void Cancelar(int idTurno)
        {
            var turno = _turnos.Find(turno => turno.Id == idTurno);
            _turnos.Remove(turno);
        }
        
        public void Demorar()
        {
            var turno = ProximoTurno();
            Avanzar();
            _turnos.Insert(1, turno);
        }

        public Turno Proximo()
        {
            return _turnos.FirstOrDefault();
        }
    }
}
