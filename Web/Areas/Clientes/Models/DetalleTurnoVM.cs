using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Clientes.Models
{
    public class DetalleTurnoVM
    {
        public int IdTurnero { get; set; }
        public string Concepto { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int IdTurno { get; set; }
        public int Numero { get; set; }
        public int EsperaEstimada { get; set; }
        public string Qr { get; set; }
    }
}
