using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Aplicacion.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

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
            var turneros = _repository.Turneros.Include(t => t.Turnos).Include(t => t.Files).ToList();
            var turnerosList = turneros.ConvertAll(new Converter<Turnero, ListarTurneroMapaDTO>(TurneroToListarTurneroDTO));
            var response = new ListarTurneroMapaResponse { turneros = turnerosList };
            return response;
        }

        static ListarTurneroMapaDTO TurneroToListarTurneroDTO(Turnero turnero)
        {
            var paths = ToListOfPath(turnero);

            return new ListarTurneroMapaDTO
            {
                Id = turnero.Id,
                Concepto = turnero.Concepto,
                Ciudad = turnero.Direccion.Ciudad,
                Calle = turnero.Direccion.Calle,
                Numero = turnero.Direccion.Numero,
                Ubicacion = turnero.Ubicacion,
                CantidadMaxima = turnero.CantidadMaxima,
                CantidadEnEspera = turnero.CantidadEnEspera(),
                Files = paths
            };
        }

        private static List<String> ToListOfPath(Turnero t) 
        { 
            List<string> ret = new List<string>();
            foreach (var f in t.Files) ret.Add(f.Path);
            return ret;
        }
    }
}
