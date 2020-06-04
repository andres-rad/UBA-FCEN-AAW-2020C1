using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public string ProcesarQR(string data)
        {
            return data;
        }
        
    }
}
