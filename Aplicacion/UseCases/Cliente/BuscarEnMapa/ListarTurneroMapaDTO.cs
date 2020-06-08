using Domain;
using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class ListarTurneroMapaDTO
    {
        public int Id { get; set; }
        public string Concepto{ get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public LatLon Ubicacion { get; internal set; }

        public ListarTurneroMapaDTO(Turnero turnero)
        {
            Id = turnero.Id;
            Concepto = turnero.Concepto;
            Ciudad = turnero.Direccion.Ciudad;
            Calle = turnero.Direccion.Calle;
            Numero = turnero.Direccion.Numero;
        }
    }
}
