using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var turnero = _repository.Turneros.Include(t=> t._turnos).Single(turnero => turnero.Id == request.IdTurnero);

            turnero.Cancelar(request.IdTurno);

            _repository.SaveChanges();

            return new CancelarTurnoResponse();
        }
    }
}
