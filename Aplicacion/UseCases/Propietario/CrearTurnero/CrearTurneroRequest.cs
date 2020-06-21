using Domain;
using Dominio;
using System;
using System.Collections.Generic;

namespace Aplicacion.UseCases.Propietario
{
    public class CrearTurneroRequest
    {
        public string IdPropietario { get; set; }
        public LatLon Ubicacion { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Concepto { get; set; }
        public int CantidadMaxima { get; set; }
        public List<FilePath> Files { get; set; }
    }
}
