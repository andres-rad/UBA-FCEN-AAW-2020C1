using Aplicacion.Interfaces;
using Domain;
using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

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

            Turnero turnero;

            turnero = new Turnero(
                 req.IdPropietario,
                 req.Concepto,
                 req.Ubicacion,
                 direccion,
                 req.CantidadMaxima == 0 ? int.MaxValue : req.CantidadMaxima
             );

            _repository.Turneros.Add(turnero);
            _repository.SaveChanges();

            var response = new CrearTurneroResponse();

            return response;
        }
    }
}
