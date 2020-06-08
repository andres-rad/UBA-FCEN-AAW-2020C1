using Domain;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Propietarios.Models
{
    public class CrearTurneroVM
    {
        public string Concepto { get; set; }
        public string Ciudad{ get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }

        public CrearTurneroVM() { }
        public CrearTurneroVM(string concepto, string ciudad, string calle, int numero, decimal latitud, decimal longitud )
        {
            Concepto = concepto;
            Ciudad = ciudad;
            Calle = calle;
            Numero = numero;
            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
