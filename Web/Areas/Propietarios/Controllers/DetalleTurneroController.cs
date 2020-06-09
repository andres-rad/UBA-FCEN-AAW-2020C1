using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UseCases.Propietario;
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
    }
}
