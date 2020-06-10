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

        public ListarTurneroMapaResponse Procesar()
        {
            var turneros = _repository.Turneros.ToList();
            var turnerosList = turneros.ConvertAll(new Converter<Turnero, ListarTurneroMapaDTO>(TurneroToListarTurneroDTO));
            var response = new ListarTurneroMapaResponse { turneros = turnerosList };
            return response;
        }

        static ListarTurneroMapaDTO TurneroToListarTurneroDTO(Turnero turnero)
        {
            return new ListarTurneroMapaDTO
            {
                Id = turnero.Id,
                Concepto = turnero.Concepto,
                Ciudad = turnero.Direccion.Ciudad,
                Calle = turnero.Direccion.Calle,
                Numero = turnero.Direccion.Numero,
                Ubicacion = turnero.Ubicacion
            };
        
        }
    }
}
