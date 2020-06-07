using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class SolicitarTurnoRequest
    {
        public int IdTurnero { get; set; }
        public string Email { get; set; }
    }
}
