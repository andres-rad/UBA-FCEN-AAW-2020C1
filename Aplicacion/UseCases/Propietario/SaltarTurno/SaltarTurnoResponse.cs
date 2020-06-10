using Domain;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class SaltarTurnoResponse
    {
        public int Id { get; set; }
        public string IdPropietario { get; set; }
        public string SiguienteTurno_Id { get; set; }
        public string SiguienteTurno_Numero { get; set; }
        public int CantidadEnEspera { get; set; }
        public string Concepto { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Qr { get; set; }
        public int CantidadMaxima { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
