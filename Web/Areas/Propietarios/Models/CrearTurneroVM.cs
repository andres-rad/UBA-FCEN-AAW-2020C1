using Domain;
using Dominio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Web.Areas.Propietarios.Models
{
    public class CrearTurneroVM
    {
        public string Concepto { get; set; }
        public string Ciudad{ get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int CantidadMaxima { get; set; }

        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public IFormFile[] files { get; set; }

        public CrearTurneroVM() { }
        public CrearTurneroVM(string concepto, string ciudad, string calle, int numero, IFormFile[] archivos, int cantidad=9)
        {
            Concepto = concepto;
            Ciudad = ciudad;
            Calle = calle;
            Numero = numero;
            CantidadMaxima = cantidad;
            files=archivos;
        }
    }
}
