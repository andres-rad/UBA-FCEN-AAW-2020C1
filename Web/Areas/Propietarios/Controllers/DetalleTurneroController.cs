using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UseCases.Propietario;
using Aplicacion.UseCases.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Propietarios.Controllers
{
    [Area("Propietarios")]
    //[Authorize]
    [AllowAnonymous]
    public class DetalleTurneroController : Controller
    {
        public IActionResult Index(int idTurnero, [FromServices] DetalleTurneroUC uc)
        {
            var req = new DetalleTurneroRequest { IdTurnero = idTurnero };
            var turnero = uc.Procesar(req);

            //TO-DO: Agregar DetalleTurneroVM

            return View(turnero);
        }
        public IActionResult CancelarTurno(int idTurno, int idTurnero, [FromServices] CancelarTurnoUC uc)
        {
            var req = new CancelarTurnoRequest
            {
                IdTurnero = idTurnero,
                IdTurno = idTurno
            };

            uc.Procesar(req);

            return RedirectToAction("Index", new { idTurnero });
        }

        public IActionResult DemorarTurno(int idTurnero, [FromServices] DemorarTurnoUC uc)
        {
            var req = new DemorarTurnoRequest { IdTurnero = idTurnero};
            uc.Procesar(req);

            return RedirectToAction("Index", new { idTurnero });
        }
    }
}
