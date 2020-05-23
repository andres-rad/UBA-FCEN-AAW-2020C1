using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Propietarios.Models
{
    public class TurneroVM
    {
        public string Id { get; set; }
        public string Concepto { get; set; }
        public Coordenadas Ubicacion { get; set; }

    }
}
