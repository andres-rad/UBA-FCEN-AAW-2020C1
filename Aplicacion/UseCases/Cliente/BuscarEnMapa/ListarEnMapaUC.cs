using System;
using System.Linq;
using Aplicacion.Interfaces;
using Domain;

namespace Aplicacion.UseCases.Cliente
{
    public class ListarEnMapaUC : IUseCase
    {
        IRepository _repository;

        public ListarEnMapaUC(IRepository repo)
        {
            _repository = repo;
        }


        public ListarTurneroMapaResponse Procesar(/*ListarTurneroRequest request*/)
        {
            var turneros = _repository.Turneros./*Where(t => t.PropietarioId == request.IdPropietario).*/ToList();
            var turnerosList = turneros.ConvertAll(new Converter<Turnero, ListarTurneroMapaDTO>(TurneroToListarTurneroDTO));
            var response = new ListarTurneroMapaResponse { turneros = turnerosList };
            return response;
        }
        static ListarTurneroMapaDTO TurneroToListarTurneroDTO(Turnero turnero)
        {
            return new ListarTurneroMapaDTO(turnero);
        }
    }
}
