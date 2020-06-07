using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Web.Areas.Propietarios.Models;
using Domain;
using Aplicacion.UseCases.Propietario;

namespace Web.Areas.Propietarios.Controllers
{
    [Area("Propietarios")]
    [AllowAnonymous]
    //[Authorize]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index([FromServices] ListarTurneroUC uc)
        {
            var response = uc.Procesar();
            
            return View(response.turneros);
        }
    }
}