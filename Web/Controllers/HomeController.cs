using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Exceptions;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using static QRCoder.PayloadGenerator;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            string ExceptionMessage = String.Empty;
            if (exceptionHandlerPathFeature?.Error is TurneroNotFoundException)
            {
                ExceptionMessage = "El turnero al que trataste de acceder no existe!";
            }
            //if (exceptionHandlerPathFeature?.Path == "/index")
            //{
            //    ExceptionMessage += " from home page";
            //}

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = ExceptionMessage });
        }
    }
}
