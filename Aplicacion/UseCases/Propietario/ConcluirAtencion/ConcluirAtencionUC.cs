using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class ConcluirAtencionUC : IUseCase
    {
        private readonly IRepository _repository;

        public ConcluirAtencionUC(IRepository repository)
        {
            _repository = repository;
        }

        public ConcluirAtencionResponse Procesar(ConcluirAtencionRequest req)
        {
            var turnero = _repository.Turneros.Include(t => t.Turnos).FirstOrDefault(t => t.Id == req.IdTurnero);

            turnero.LlamarSiguiente();

            _repository.SaveChanges();

            return new ConcluirAtencionResponse();
        }
    }
}
