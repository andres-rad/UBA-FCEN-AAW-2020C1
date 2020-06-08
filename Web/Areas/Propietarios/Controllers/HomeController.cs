using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Aplicacion.UseCases.Propietario;
using Aplicacion.Interfaces;

namespace Web.Areas.Propietarios.Controllers
{
    [Area("Propietarios")]
    [Authorize]
    public class HomeController : Controller
    {
        // GET: HomeController
        ICurrentUserService _userService;

        public HomeController(ICurrentUserService cus)
        {
            _userService = cus;
        }
        public ActionResult Index([FromServices] ListarTurneroUC uc)
        {
            var response = uc.Procesar(new ListarTurneroRequest { IdPropietario = _userService.UserId });
            
            return View(response.turneros);
        }
    }
}