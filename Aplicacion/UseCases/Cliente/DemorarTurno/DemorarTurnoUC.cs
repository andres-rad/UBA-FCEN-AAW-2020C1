using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class DemorarTurnoUC : IUseCase
    {
        IRepository _repository;

        public DemorarTurnoUC(IRepository repo)
        {
            _repository = repo;
        }

        public DemorarTurnoResponse Procesar(DemorarTurnoRequest req)
        {
            //var turnero = _repository.Turneros.Find(req.IdTurnero);
            var turnero = _repository.Turneros.Include(t => t._turnos).Single(turnero => turnero.Id == req.IdTurnero);
            turnero.Demorar(req.IdTurno);
            return new DemorarTurnoResponse { };
        }
    }
}
