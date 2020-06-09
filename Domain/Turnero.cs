using Dominio;
using System.Collections.Generic;
using System.Linq;
using QRCoder;

namespace Domain
{
    public class Turnero
    {
        public int Id { get; internal set; }
        public string IdPropietario { get; internal set; }
        public string Concepto { get; internal set; }
        public LatLon Ubicacion { get; internal set; }
        public Direccion Direccion{ get; internal set; }
        public int CantidadMaxima { get; set; }

        List<Turno> _turnos;

        private Turnero() { }

        public Turnero(string idPropietario, string concepto, LatLon ubicacion, Direccion direccion, int cantidaMaximaGenteEnEspera)
        {
            IdPropietario = idPropietario;
            Concepto = concepto;
            Direccion = direccion;
            Ubicacion = ubicacion;
            _turnos = new List<Turno>();
            CantidadMaxima = cantidaMaximaGenteEnEspera;
        }

        public Turno ExpedirTurno(string email)
        {
            var turno = new Turno(_turnos.Count + 1, this.Id, _turnos.Count + 1, email);

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
