using Aplicacion.Exceptions;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class DetallarTurnoUC : IUseCase
    {
        private readonly IRepository _repository;
        private readonly IQRProvider _qrProvider;

        public DetallarTurnoUC(IRepository repository, IQRProvider qrProvider)
        {
            _repository = repository;
            _qrProvider = qrProvider;
        }

        public DetallarTurnoResponse Procesar(DetallarTurnoRequest request)
        {
            var turnero = _repository.Turneros.Include(t => t.Turnos).FirstOrDefault(t => t.Id == request.IdTurnero);

            if(turnero == null)
            {
                throw new TurneroNotFoundException($"{request.IdTurnero}");
            }

            var turno = turnero.Turno(request.IdTurno);

            if (turno == null)
            {
                throw new TurnoNotFoundException($"{request.IdTurno}");
            }

            return new DetallarTurnoResponse() { 
                IdTurnero = turnero.Id,
                IdTurno = turno.Id,
                NumeroTurno = turno.Numero,
                Concepto = turnero.Concepto,
                Ciudad = turnero.Direccion.Ciudad,
                Calle = turnero.Direccion.Calle,
                Numero = turnero.Direccion.Numero,
                Latitud = turnero.Ubicacion.Latitud,
                Longitud = turnero.Ubicacion.Longitud,
                QrTurno = _qrProvider.Encode(turno.Id.ToString()),
                EsperaEstimada = turnero.EsperaParaTurno(turno.Id)
            };
        }
    }
}
