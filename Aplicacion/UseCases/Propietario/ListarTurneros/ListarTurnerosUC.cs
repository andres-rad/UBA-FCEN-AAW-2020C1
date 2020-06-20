using System;
using System.Linq;
using Aplicacion.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.UseCases.Propietario
{
    public class ListarTurnerosUC : IUseCase
    {
        IRepository _repository;

        public ListarTurnerosUC(IRepository repo)
        {
            _repository = repo;
        }

        public ListarTurnerosResponse Procesar(ListarTurnerosRequest request)
        {
            var turneros = _repository.Turneros.Include(t => t.Turnos).Where(t => t.IdPropietario == request.IdPropietario).ToList();
            var turnerosList = turneros.ConvertAll(new Converter<Turnero, ListarTurnerosDTO>(TurneroToListarTurneroDTO));
            var response = new ListarTurnerosResponse { turneros = turnerosList };
            return response;
        }

        static ListarTurnerosDTO TurneroToListarTurneroDTO(Turnero turnero)
        {
            return new ListarTurnerosDTO(turnero);
        }
    }
}
