using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Propietarios.Models
{
    public class AtenderTurnoVM
    {
        public InformacionTurneroVM InfoTurnero { get; set; }
        public int NumeroLeidoEnQr { get; set; }
        public int? NumeroEnLlamada { get; set; }
    }
}
