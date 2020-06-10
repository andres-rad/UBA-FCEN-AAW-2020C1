using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Aplicacion.UseCases.Cliente;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Areas.Clientes.Models;

namespace Web.Areas.Clientes.Controllers
{

    [Area("Clientes")]
    [AllowAnonymous]
    public class SolicitarTurnoController : Controller
    {

        [HttpGet]
        public IActionResult Mapa([FromServices] ListarEnMapaUC uc)
        {
            var response = uc.Procesar();

            return View(response.turneros);
        }
        
        [HttpGet]
        public IActionResult LeerQR()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarQR(string data, [FromServices] LeerQrUC leerQrUC)
        {
            
            return RedirectToAction(nameof(ConfirmarTurno), new { idTurnero = Int32.Parse(data) });
        }

        [HttpGet]
        public IActionResult ConfirmarTurno(int idTurnero, [FromServices] DetalleTurneroClienteUC uc)
        {
            var req = new DetalleTurneroClienteRequest { IdTurnero = idTurnero };
            var turneroData = uc.Procesar(req);
            return View(turneroData);
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

            return RedirectToAction("Detalle", "Turnos",  new { idTurnero = response.IdTurnero, idTurno = response.IdTurno });
        }

    }
}
