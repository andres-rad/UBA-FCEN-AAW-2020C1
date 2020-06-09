using Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class DemorarTurnoUC : IUseCase
    {
        private readonly IRepository _repository;

        public DemorarTurnoUC(IRepository repo) {
            _repository = repo;
        }

        public DemorarTurnoResponse Procesar(DemorarTurnoRequest req)
        {
            var turnero = _repository.Turneros.Find(req.IdTurnero);
            turnero.Demorar();
            return new DemorarTurnoResponse { };
        }
    }
}
