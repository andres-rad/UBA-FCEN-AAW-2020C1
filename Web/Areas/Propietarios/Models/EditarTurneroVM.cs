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
    public class EditarTurneroVM
    {
        public int IdTurnero { get; set;}
        public string Concepto { get; set; }
        public string Ciudad{ get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int CantidadMaxima { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public IFormFile[] Imagenes { get; set; }

        public EditarTurneroVM() { }
        public EditarTurneroVM(int id, string concepto, string ciudad, string calle, int numero, double latitud, double longitud, IFormFile[] imagenes, int cantidad=9)        {
            IdTurnero = id;
            Concepto = concepto;
            Ciudad = ciudad;
            Calle = calle;
            Numero = numero;
            CantidadMaxima = cantidad;
            Latitud = latitud;
            Longitud = longitud;
            Imagenes = imagenes;
        }
    }
}
