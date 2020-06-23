using Aplicacion.Exceptions;
using Aplicacion.Interfaces;
using Domain;
using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class EditarTurneroUC : IUseCase
    {
        IRepository _repository;

        public EditarTurneroUC(IRepository repo)
        {
            _repository = repo;
        }

        public EditarTurneroResponse Procesar(EditarTurneroRequest req)
        {
            var turnero = _repository.Turneros.Find(req.IdTurnero);

            if(turnero == null) throw new TurneroNotFoundException("Turnero no encontrado");

            var direccion = new Direccion()
            {
                Ciudad = req.Ciudad,
                Calle = req.Calle,
                Numero = req.Numero
            };

            turnero.Actualizar(req.Concepto, req.Ubicacion, direccion, req.CantidadMaxima);

            _repository.SaveChanges();

            var response = new EditarTurneroResponse();

            return response;
        }
    }
}
