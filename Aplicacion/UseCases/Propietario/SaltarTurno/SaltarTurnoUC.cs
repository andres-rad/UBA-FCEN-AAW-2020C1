using Aplicacion.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class SaltarTurnoUC : IUseCase
    {
        private readonly IRepository _repository;
        private readonly IQRProvider _qrProvider;

        public SaltarTurnoUC(IRepository repo, IQRProvider qrProvider)
        {
            _repository = repo;
            _qrProvider = qrProvider;
        }

        public SaltarTurnoResponse Procesar(SaltarTurnoRequest req)
        {
            var turnero = _repository.Turneros.Include(t => t._turnos).FirstOrDefault(t => t.Id == req.IdTurnero);

            if(turnero == null)
            {
                throw new Exception("Turnero no encontrado");
            }

            var turnoEnLlamada = turnero.LlamarSiguiente();

            _repository.SaveChanges();

            return new SaltarTurnoResponse()
            {
                IdTurnero = turnero.Id,
                IdPropietario = turnero.IdPropietario,
                CantidadEnEspera = turnero.CantidadEnEspera(),
                NumeroEnLlamada = turnoEnLlamada?.Numero,
                Concepto = turnero.Concepto,
                Ciudad = turnero.Direccion.Ciudad,
                Calle = turnero.Direccion.Calle,
                Numero = turnero.Direccion.Numero,
                QrTurnero = _qrProvider.Encode(turnero.Id.ToString()),
                CantidadMaxima = turnero.CantidadMaxima,
                Latitud = turnero.Ubicacion.Latitud,
                Longitud = turnero.Ubicacion.Longitud
            };
        }
    }
}
