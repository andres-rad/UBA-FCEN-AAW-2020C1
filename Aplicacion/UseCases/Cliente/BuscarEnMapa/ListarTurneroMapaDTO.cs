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
        public LatLon Ubicacion { get;  set; }
        public int CantidadMaxima { get; set; }
        public int CantidadEnEspera { get; set; }
        public List<String> Files { get; set; }
    }
}
