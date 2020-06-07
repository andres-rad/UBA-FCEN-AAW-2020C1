using Domain;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class DetalleTurneroResponse
    {
        public int Id { get; }
        public string IdPropietario { get; }
        public string Concepto { get; }
        public string Ciudad { get; }
        public string Calle { get; }
        public int Numero { get; }
        public string Qr { get; }

        public DetalleTurneroResponse(Turnero turnero)
        {
            Id = turnero.Id;
            IdPropietario = turnero.IdPropietario;
            Concepto = turnero.Concepto;
            Ciudad = turnero.Direccion.Ciudad;
            Calle = turnero.Direccion.Calle;
            Numero = turnero.Direccion.Numero;
            Qr = turnero.Qr;
        }
    }
}
