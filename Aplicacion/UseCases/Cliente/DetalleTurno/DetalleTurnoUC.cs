using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class DetalleTurnoUC : IUseCase
    {
        private readonly IRepository _repository;
        private readonly IQRProvider _qrProvider;

        public DetalleTurnoUC(IRepository repository, IQRProvider qrProvider)
        {
            _repository = repository;
            _qrProvider = qrProvider;
        }

        public DetalleTurnoResponse Procesar(DetalleTurnoRequest request)
        {
            var turnero = _repository.Turneros.Include(t => t._turnos).FirstOrDefault(t => t.Id == request.IdTurnero);

            if(turnero == null)
            {
                throw new Exception("Turnero inexistente");
            }

            var turno = turnero.Turno(request.IdTurno);

            if (turno == null)
            {
                throw new Exception("Turno inexistente");
            }

            return new DetalleTurnoResponse() { 
                IdTurnero = turnero.Id,
                IdTurno = turno.Id,
                NumeroTurno = turno.Numero,
                Concepto = turnero.Concepto,
                Ciudad = turnero.Direccion.Ciudad,
                Calle = turnero.Direccion.Calle,
                Numero = turnero.Direccion.Numero,
                Latitud = turnero.Ubicacion.Latitud,
                Longitud = turnero.Ubicacion.Longitud,
                Qr = _qrProvider.Encode(turnero.Id.ToString()),
                EsperaEstimada = turnero.EsperaParaTurno(turno.Id)
            };
        }
    }
}
