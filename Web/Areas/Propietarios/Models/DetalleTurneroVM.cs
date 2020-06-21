using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Propietarios.Models
{
    public class DetalleTurneroVM
    {
        public InformacionTurneroVM InfoTurnero { get; set; }
        public int? NumeroTurnoEnLlamada { get; set; }
        public FormFile[] files { get; set; }
    }
}
