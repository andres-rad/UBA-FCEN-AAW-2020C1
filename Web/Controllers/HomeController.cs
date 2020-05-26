using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQRProvider _qr;

        //IQRProvider esta a modo de ejemplo.
        //es discutible si deberia generar los QR aca o en la capa de aplicacion
        public HomeController(ILogger<HomeController> logger, IQRProvider qrProvider)
        {
            _logger = logger;
            _qr = qrProvider;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string? input)
        {
            
            string imageBase64Data = _qr.Encode(input ?? "Ups.. no me pasaste nada!");
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            ViewBag.QR = imageDataURL;

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
