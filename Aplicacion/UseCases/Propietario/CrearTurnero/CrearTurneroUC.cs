using Aplicacion.Interfaces;
using Domain;
using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class CrearTurneroUC : IUseCase
    {
        IRepository _repository;

        public CrearTurneroUC(IRepository repo)
        {
            _repository = repo;
        }

        public CrearTurneroResponse Procesar(CrearTurneroRequest req)
        {
            var direccion = new Direccion()
            {
                Ciudad = req.Ciudad,
                Calle = req.Calle,
                Numero = req.Numero
            };

            var turnero = new Turnero(
                req.IdPropietario,
                req.Concepto,
                direccion,
                req.Ubicacion
            );

            _repository.Turneros.Add(turnero);
            _repository.SaveChanges();

            var response = new CrearTurneroResponse();

            return response;
        }
    }
}
