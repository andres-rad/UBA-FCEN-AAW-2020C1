using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Propietarios.Models
{
    public class ListarTurneroVM
    {
        public int Id { get; }
        public string Concepto { get; }
        public string Ciudad { get; }
        public string Calle { get; }
        public int Numero { get; }

        public ListarTurneroVM(int id, string concepto, string ciudad, string calle, int numero)
        {
            Id = id;
            Concepto = concepto;
            Ciudad = ciudad;
            Calle = calle;
            Numero = numero;
        }
    }
}
