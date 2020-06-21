using Dominio;
using System.Collections.Generic;
using System.Linq;
using QRCoder;
using System;
using System.IO;

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

        public int UltimoNumero { get; internal set; }

        public List<FilePath> Files { get; internal set; }

        private List<Turno> _turnos = new List<Turno>();
        
        public List<Turno> Turnos { get { _turnos.Sort((p, q) => p.Numero.CompareTo(q.Numero)); return _turnos; } set { _turnos = value; } }

        private Turnero() {

        }

        public Turnero(string idPropietario, string concepto, LatLon ubicacion, Direccion direccion, int cantidaMaxima, List<FilePath> filePaths)
        {
            IdPropietario = idPropietario;
            Concepto = concepto;
            Direccion = direccion;
            Ubicacion = ubicacion;
            CantidadMaxima = cantidaMaxima;
            UltimoNumero = 0;
            Files = filePaths;
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
            if (Turnos.Count == CantidadMaxima) 
                throw new Exception("Cantidad maxima alcanzada, no se puede expedir turnos por el momento");
            
            UltimoNumero++;

            var turno = new Turno(Id, UltimoNumero, email, UltimoNumero);
            Turnos.Add(turno);

            return turno;
        }

        public Turno LlamarSiguiente()
        {
            if(Turnos.Count > 0)
            {
                Turnos.Remove(this.TurnoEnLlamada());
            }

            return this.TurnoEnLlamada();
        }

        public void Cancelar(int idTurno)
        {
            var turno = Turnos.Find(turno => turno.Id == idTurno);
            Turnos.Remove(turno);
        }
        
        public void Demorar(int idTurno)
        {
            var turnoADemorar = this.Turno(idTurno);
            
            if(turnoADemorar == null)
            {
                throw new Exception($"Turno inexistente: {idTurno}");
            }

            var sigTurnoActual = this.Turnos.Where(t => t.Orden > turnoADemorar.Orden).FirstOrDefault();

            if(sigTurnoActual != null)
            {
                (turnoADemorar.Orden, sigTurnoActual.Orden ) = (sigTurnoActual.Orden , turnoADemorar.Orden);
            }
        }

        public Turno TurnoEnLlamada()
        {
            return Turnos.OrderBy(t => t.Orden).FirstOrDefault();
        }

        public int CantidadEnEspera()
        {
            return Turnos.Count;
        }

        public Turno Turno(int idTurno)
        {
            return Turnos.FirstOrDefault(t => t.Id == idTurno);
        }

        public int EsperaParaTurno(int idTurno)
        {
            var turno = this.Turno(idTurno);

            return Turnos.Where(t=> t.Orden < turno.Orden).Count();
        }


    }
}
