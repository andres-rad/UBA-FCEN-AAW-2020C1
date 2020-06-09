using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Web.Areas.Propietarios.Models;
using Aplicacion.UseCases.Propietario;
using Aplicacion.Interfaces;
using Dominio;


namespace Web.Areas.Propietarios.Controllers
{
    [Area("Propietarios")]
    [Authorize]
    public class EditarTurneroController : Controller
    {
        ICurrentUserService _userService;
        
        public EditarTurneroController(ICurrentUserService us)
        {
            _userService = us;
        }

        [HttpGet]
        public IActionResult Index(int idTurnero, [FromServices] DetalleTurneroUC uc)
        {
            var req = new DetalleTurneroRequest { IdTurnero = idTurnero };
            var detalleTurnero = uc.Procesar(req);
            var turnero = new EditarTurneroVM(
                idTurnero,
                detalleTurnero.Concepto,
                detalleTurnero.Ciudad,
                detalleTurnero.Calle,
                detalleTurnero.Numero,
                detalleTurnero.Latitud,
                detalleTurnero.Longitud,
                detalleTurnero.CantidadMaxima);
            return View(turnero);
        }

        [HttpPost]
        public IActionResult Editar(EditarTurneroVM turnero, [FromServices] EditarTurneroUC uc)
        {
            var req = new EditarTurneroRequest
            {
                IdPropietario = _userService.UserId,
                IdTurnero = turnero.IdTurnero,
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
