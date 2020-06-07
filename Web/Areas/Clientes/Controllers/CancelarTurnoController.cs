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
    public class CancelarTurnoController : Controller
    {

        [HttpPost]
        public IActionResult CancelarTurno(int idTurnero, string email, [FromServices] CancelarTurnoUC uc)
        {
            var request = new CancelarTurnoRequest
            {
                IdTurnero = idTurnero
            };

            var response = uc.Procesar(request);

            return View();
        }

    }
}
