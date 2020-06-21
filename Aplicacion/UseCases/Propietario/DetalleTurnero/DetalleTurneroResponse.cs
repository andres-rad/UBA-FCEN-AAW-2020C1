using Domain;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class DetalleTurneroResponse
    {
        public int IdTurnero { get; set; }
        public string IdPropietario { get; set; }
        public int? NumeroTurnoEnLlamada { get; set; }
        public int CantidadEnEspera { get; set; }
        public string Concepto { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string QrTurnero { get; set; }
        public int CantidadMaxima { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public List<FilePath> Files { get; set; }
    }
}
