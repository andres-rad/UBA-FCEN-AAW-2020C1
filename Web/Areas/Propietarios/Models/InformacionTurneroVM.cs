using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Propietarios.Models
{
    public class InformacionTurneroVM
    {
        public int IdTurnero { get; set; }
        public int CantidadEnEspera { get; set; }
        public string Concepto { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Qr { get; set; }
        public int CantidadMaxima { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public List<string> Files {get; set;}
    }
}
