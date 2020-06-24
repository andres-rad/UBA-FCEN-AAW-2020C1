using Aplicacion.Exceptions;
using Aplicacion.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class DetallarTurneroUC : IUseCase
    {
        private readonly IRepository _repository;
        private readonly IQRProvider _qrProvider;

        public DetallarTurneroUC(IRepository repo, IQRProvider qrProvider)
        {
            _repository = repo;
            _qrProvider = qrProvider;
        }

        public DetallarTurneroResponse Procesar(DetallarTurneroRequest req)
        {
            var turnero = _repository.Turneros.Include(t => t.Turnos).Include(t => t.Files).FirstOrDefault(t => t.Id == req.IdTurnero);

            if(turnero == null)
            {
                throw new TurneroNotFoundException();
            }

            var turnoEnLlamada = turnero.TurnoEnLlamada();

            return new DetallarTurneroResponse()
            {
                IdTurnero = turnero.Id,
                IdPropietario = turnero.IdPropietario,
                CantidadEnEspera = turnero.CantidadEnEspera(),
                NumeroTurnoEnLlamada = turnoEnLlamada?.Numero,
                Concepto = turnero.Concepto,
                Ciudad = turnero.Direccion.Ciudad,
                Calle = turnero.Direccion.Calle,
                Numero = turnero.Direccion.Numero,
                QrTurnero = _qrProvider.Encode(turnero.Id.ToString()),
                CantidadMaxima = turnero.CantidadMaxima,
                Latitud = turnero.Ubicacion.Latitud,
                Longitud = turnero.Ubicacion.Longitud,
                Files = turnero.Files
            };
        }
    }
}
