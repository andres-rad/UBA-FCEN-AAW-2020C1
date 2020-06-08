using Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class DetalleTurneroUC : IUseCase
    {
        IRepository _repository;

        public DetalleTurneroUC(IRepository repo)
        {
            _repository = repo;
        }

        public DetalleTurneroResponse Procesar(DetalleTurneroRequest req)
        {
            var turnero = _repository.Turneros.Find(req.IdTurnero);

            return new DetalleTurneroResponse(turnero);
        }
    }
}
