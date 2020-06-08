using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Web.Areas.Propietarios.Models;
using Aplicacion.UseCases.Propietario;
using Aplicacion.Interfaces;
using Dominio;

namespace Web.Areas.Propietarios.Controllers
{
    [Area("Propietarios")]
    [AllowAnonymous]
    public class CrearTurneroController : Controller
    {
        ICurrentUserService _userService;
        
        public CrearTurneroController(ICurrentUserService us)
        {
            _userService = us;
        }

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
                IdPropietario = _userService.UserId,
                Ciudad = turnero.Ciudad,
                Calle = turnero.Calle,
                Numero = turnero.Numero,
                Concepto = turnero.Concepto,
                Ubicacion = new LatLon(turnero.Latitud, turnero.Longitud),
                CantidadMaxima = turnero.CantidadMaxima 
            };

            uc.Procesar(req);

            return RedirectToAction("Index", "Home");
        }
    }

}
