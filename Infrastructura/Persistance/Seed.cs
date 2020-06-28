using Domain;
using Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructura.Persistance
{
    public static class Seed
    {
        public static void Load(ApplicationDbContext context)
        {
            FilePath p1 = new FilePath(0, "Carrefour.png");
            FilePath p2 = new FilePath(0, "Coto.png");
            FilePath p3 = new FilePath(0, "Disco.jpg");
            FilePath p4 = new FilePath(0, "Dia.jpg");

            var turneros = new Turnero[] { new Turnero(
                    idPropietario: "seedUser",
                  concepto: "Carrefour",
                  ubicacion: new Dominio.LatLon ( lat: -34.61066273180164, lon: -58.41436768925822 ),
                  direccion: new Dominio.Direccion { Calle = "Uriarte", Ciudad = "CABA", Numero = 812 },
                  cantidaMaxima: 100,
                  new List<FilePath> { p1 }
                  ),


                //new Turnero(
                //    idPropietario: "seedUser",
                //  concepto: "Walmart",
                //  ubicacion: new Dominio.LatLon ( lat: -34.611510422952044, lon: -58.454536451464705 ),
                //  direccion: new Dominio.Direccion { Calle = "CaleRoja", Ciudad = "CABA", Numero = 756 },
                //  cantidaMaxima: 100,
                //  new List<FilePath> { p1 }
                //  ),

                //new Turnero(
                //    idPropietario: "seedUser",
                //  concepto: "Disco",
                //  ubicacion: new Dominio.LatLon ( lat: -34.611510422952064, lon: -58.454536451464705 ),
                //  direccion: new Dominio.Direccion { Calle = "CalleX", Ciudad = "CABA", Numero = 256 },
                //  cantidaMaxima: 2,
                //  new List<FilePath> { p3 }
                //  ),

                //new Turnero(
                //    idPropietario: "2",
                //  concepto: "Carpinteria Maderas",
                //  ubicacion: new Dominio.LatLon (lat:-34.604446065572695, lon :-58.40338136113314 ),
                //  direccion: new Dominio.Direccion { Calle = "Arboles", Ciudad = "CABA", Numero = 1563 },
                //  cantidaMaxima: int.MaxValue,
                //  new List<FilePath>()
                // ),

                new Turnero(
                    idPropietario: "seedUser",
                  concepto: "Disco",
                  ubicacion: new Dominio.LatLon ( lat: -34.611510422952264, lon: -58.454536451464705 ),
                  direccion: new Dominio.Direccion { Calle = "La Rioja", Ciudad = "CABA", Numero = 210 },
                  cantidaMaxima: 2,
                  new List<FilePath> { p3 }
                  )
            };

            context.Turneros.AddRange(turneros);
            context.SaveChanges();

            turneros[0].ExpedirTurno("email1@email.com");
            turneros[0].ExpedirTurno("email2@email.com");
            turneros[0].ExpedirTurno("email1@email.com");
            turneros[0].ExpedirTurno("email2@email.com");
            turneros[0].ExpedirTurno("email3@email.com");
            turneros[1].ExpedirTurno("email4@email.com");
            //turneros[2].ExpedirTurno("email1@email.com");
            //turneros[2].ExpedirTurno("email2@email.com");
            
            context.SaveChanges();

        }
    }
}
