using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UseCases;
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
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SolicitarPorTurnero(string idTurnero)
        {
            
            var request = new SolicitarTurnoRequest
            {
                idTurnero = idTurnero
            };

            var response = _solicitarTurnoUC.Procesar(request);

            var turnoVM = new TurnoVM
            {
                Concepto = response.Concepto,
                QR = response.QR
            };

            return View(turnoVM);
        }

    }
}