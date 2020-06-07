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
    public class SolicitarTurnoController : Controller
    {

        [HttpGet]
        public IActionResult Mapa()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult LeerQR()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarQR(string data)
        {
            return RedirectToAction(nameof(ConfirmarTurno), new { idTurero = 18765});
        }

        [HttpGet]
        public IActionResult ConfirmarTurno(string data)
        {
            return View();
        }


        [HttpPost]
        public IActionResult ConfirmarTurno(int idTurnero, string email, [FromServices] SolicitarTurnoUC uc)
        {
            var request = new SolicitarTurnoRequest
            {
                IdTurnero = idTurnero,
                Email = email
            };

            var response = uc.Procesar(request);

            var turnoVM = new TurnoVM
            {
                Concepto = response.Concepto,
                QR = response.QR
            };

            return View(turnoVM);
        }

    }
}
