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
            var turneros = new Turnero[] { new Turnero(
                    idPropietario: "1",
                  concepto: "Carniceria La Vaca",
                  ubicacion: new Dominio.LatLon ( lat: -34.61066273180164, lon: -58.41436768925822 ),
                  direccion: new Dominio.Direccion { Calle = "CalleAzul", Ciudad = "CABA", Numero = 122 },
                  cantidaMaxima: 100
                  ),


                new Turnero(
                    idPropietario: "1",
                  concepto: "Merceria Mercedes",
                  ubicacion: new Dominio.LatLon ( lat: -34.611510422952044, lon: -58.454536451464705 ),
                  direccion: new Dominio.Direccion { Calle = "CaleRoja", Ciudad = "CABA", Numero = 756 },
                  cantidaMaxima: 100
                  ),

                new Turnero(
                    idPropietario: "2",
                  concepto: "Carpinteria Maderas",
                  ubicacion: new Dominio.LatLon (lat:-34.604446065572695, lon :-58.40338136113314 ),
                  direccion: new Dominio.Direccion { Calle = "Arboles", Ciudad = "CABA", Numero = 1563 },
                  cantidaMaxima: int.MaxValue
                 )
            };

            turneros[0].ExpedirTurno("email1@email.com");
            turneros[0].ExpedirTurno("email1@email.com");
            turneros[1].ExpedirTurno("email1@email.com");
            turneros[1].ExpedirTurno("email1@email.com");
            turneros[1].ExpedirTurno("email1@email.com");
            turneros[1].ExpedirTurno("email1@email.com");
            turneros[2].ExpedirTurno("email1@email.com");
            turneros[2].ExpedirTurno("email1@email.com");

            context.Turneros.AddRange(turneros);
            context.SaveChanges();
        }
    }
}
