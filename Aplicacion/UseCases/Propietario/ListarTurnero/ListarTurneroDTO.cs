using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class ListarTurneroDTO
    {
        public int Id { get; set; }

        public string IdPropietario { get; set; }
        public string Concepto{ get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }

        public ListarTurneroDTO(Turnero turnero)
        {
            Id = turnero.Id;
            IdPropietario = turnero.IdPropietario;
            Concepto = turnero.Concepto;
            Ciudad = turnero.Direccion.Ciudad;
            Calle = turnero.Direccion.Calle;
            Numero = turnero.Direccion.Numero;
        }
    }
}
