using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Aplicacion.UseCases.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Clientes.Models;

namespace Web.Areas.Clientes.Controllers
{

    [Area("Clientes")]
    [AllowAnonymous]
    public class DemorarTurnoController : Controller
    {

        [HttpPost]
        public IActionResult DemorarTurno(int idTurnero, int idTurno, string email, [FromServices] DemorarTurnoUC uc)
        {
            var request = new DemorarTurnoRequest
            {
                IdTurnero = idTurnero,
                IdTurno = idTurno
            };

            var response = uc.Procesar(request);

            return RedirectToAction("Index", "Home"); 
        }
    }
}
