using System;
using System.Linq;
using Aplicacion.Interfaces;
using Domain;

namespace Aplicacion.UseCases.Propietario
{
    public class ListarTurneroUC : IUseCase
    {
        IRepository _repository;

        public ListarTurneroUC(IRepository repo)
        {
            _repository = repo;
        }

        public ListarTurneroResponse Procesar(/*ListarTurneroRequest request*/)
        {
            var turneros = _repository.Turneros./*Where(t => t.PropietarioId == request.IdPropietario).*/ToList();
            var turnerosList = turneros.ConvertAll(new Converter<Turnero, ListarTurneroDTO>(TurneroToListarTurneroDTO));
            var response = new ListarTurneroResponse { turneros = turnerosList };
            return response;
        }
        static ListarTurneroDTO TurneroToListarTurneroDTO(Turnero turnero)
        {
            return new ListarTurneroDTO(turnero);
        }
    }
}
