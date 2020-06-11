using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UseCases.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Web.Areas.Clientes.Models;

namespace Web.Areas.Clientes.Controllers
{
    [Area("Clientes")]
    [AllowAnonymous]
    public class TurnosController : Controller
    {
        SolicitarTurnoUC _solicitarTurnoUC;

        /*
         * Noten que para crear SolicitarTurnoUC se necesita objetos que siguen las interfaces
         *      IQRProvider 
         *      IRepositoryTurnero 
         * Las instancias concretas para esos se resuelven por el Dependency Injection de .Net Core
         * (segun se configuro en Startup.cs)
         */
        public TurnosController(SolicitarTurnoUC solicitarTurnoUC)
        {
            _solicitarTurnoUC = solicitarTurnoUC;
        }


        [HttpGet]
        public IActionResult Detalle(int idTurnero, int idTurno, [FromServices] DetalleTurnoUC detalleTurnoUC)
        {

            var request = new DetalleTurnoRequest
            {
                IdTurnero = idTurnero,
                IdTurno = idTurno
            };

            var response = detalleTurnoUC.Procesar(request);

            var turnoVM = new DetalleTurnoVM
            {
                IdTurnero = response.IdTurnero,
                Concepto = response.Concepto,
                Direccion = $"{response.Calle} {response.Numero}, {response.Ciudad}",
                Latitud = response.Latitud,
                Longitud = response.Longitud,
                IdTurno = response.IdTurno,
                Numero = response.NumeroTurno,
                EsperaEstimadaMsg = response.EsperaEstimada > 0 ? $"{response.EsperaEstimada} personas antes" : "Es tu turno!",
                Qr = response.QrTurno
            };

            return View(turnoVM);
        }

    }
}