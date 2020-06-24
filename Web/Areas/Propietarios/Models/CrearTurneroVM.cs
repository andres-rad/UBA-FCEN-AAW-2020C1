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
        [Required(ErrorMessage = "{0} no puede estar vacio.")]
        public string Concepto { get; set; }
        
        [Required(ErrorMessage = "{0} no puede estar vacio.")]
        public string Ciudad{ get; set; }
        
        [Required(ErrorMessage = "{0} no puede estar vacio.")]
        public string Calle { get; set; }
        
        [Required(ErrorMessage = "{0} no puede estar vacio.")]
        public int Numero { get; set; }

        public int CantidadMaxima { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio.")]
        public string Latitud { get; set; }
        
        [Required(ErrorMessage = "{0} no puede estar vacio.")]
        public string Longitud { get; set; }

        public IFormFile[] Files { get; set; }

        public CrearTurneroVM() { }
        public CrearTurneroVM(string concepto, string ciudad, string calle, int numero, IFormFile[] archivos, int cantidad=9)
        {
            Concepto = concepto;
            Ciudad = ciudad;
            Calle = calle;
            Numero = numero;
            CantidadMaxima = cantidad;
            Files=archivos;
        }
    }
}
