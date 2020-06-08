using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Web.Areas.Propietarios.Models;
using Aplicacion.UseCases.Propietario;
using Dominio;

namespace Web.Areas.Propietarios.Controllers
{
    [Area("Propietarios")]
    [AllowAnonymous]
    public class CrearTurneroController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(CrearTurneroVM turnero, [FromServices] CrearTurneroUC uc)
        {
            var req = new CrearTurneroRequest
            {
                IdPropietario = 1,
                Ciudad = turnero.Ciudad,
                Calle = turnero.Calle,
                Numero = turnero.Numero,
                Concepto = turnero.Concepto,
                Ubicacion = new LatLon((double)turnero.Latitud, (double)turnero.Longitud)
            };

            uc.Procesar(req);

            return RedirectToAction("Index", "Home");
        }
    }

}
