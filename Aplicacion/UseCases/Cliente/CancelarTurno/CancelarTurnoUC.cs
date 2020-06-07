using Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class CancelarTurnoUC : IUseCase
    {
        IRepository _repository;

        public CancelarTurnoUC(IRepository repo)
        {
            _repository = repo;
        }

        public CancelarTurnoResponse Procesar(CancelarTurnoRequest request)
        {
            var turnero = _repository.Turneros.Single(turnero => turnero.Id == request.idTurnero);
            turnero.Cancelar(request.IdTurno);

            _repository.SaveChanges();

            return new CancelarTurnoResponse();
        }
    }
}
