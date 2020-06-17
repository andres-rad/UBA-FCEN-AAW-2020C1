using Aplicacion.UseCases.Cliente;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Clientes.Models
{
    public class ListarTurnerosVM
    {
        public int Id { get; set; }

        public string IdPropietario { get; set; }
        public string Concepto { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int CantidadEnEspera { get; set; }
        public LatLon Ubicacion { get; set; }
        public string DisplayEspera { get; set; }

        public ListarTurnerosVM(ListarTurneroMapaDTO turnero)
        {
            Id = turnero.Id;
            Concepto = turnero.Concepto;
            Ciudad = turnero.Ciudad;
            Calle = turnero.Calle;
            Numero = turnero.Numero;
            Ubicacion = turnero.Ubicacion;

            if(turnero.CantidadMaxima == int.MaxValue)
            {
                DisplayEspera = $"{turnero.CantidadEnEspera} / ∞";
            } else
            {
                DisplayEspera = $"{turnero.CantidadEnEspera} / {turnero.CantidadMaxima}";
            }
        }
    }
}
