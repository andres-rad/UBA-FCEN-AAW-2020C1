using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class AtenderTurnoUC :IUseCase
    {
        private readonly IRepository _repository;
        private readonly IQRProvider _qrProvider;

        public AtenderTurnoUC(IRepository repository, IQRProvider qrProvider)
        {
            _qrProvider = qrProvider;
            _repository = repository;
        }

        public AtenderTurnoResponse Procesar(AtenderTurnoRequest request)
        {
            int idturnoEnQr;
            try
            {
                idturnoEnQr = int.Parse(request.QrData);
            }
            catch
            {
                throw new Exception("Qr invalido");
            }

            var turnero = _repository.Turneros.Include(t => t._turnos).FirstOrDefault(t => t.Id == request.IdTurnero);

            if (turnero == null)
            {
                throw new Exception("Turnero inexistente");
            }

            var turnoEnQr = turnero.Turno(idturnoEnQr);

            if(turnoEnQr == null) 
            {
                throw new Exception("Qr invalido: no contiene data de un turnero");
            }

            var turnoEnLlamada = turnero.TurnoEnLlamada();

            return new AtenderTurnoResponse
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
                NumeroTurnoEnQr = turnoEnQr.Numero
            };
        }
    }
}
