using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Propietario
{
    public class DetalleTurneroUC : IUseCase
    {
        private readonly IRepository _repository;
        private readonly IQRProvider _qrProvider;

        public DetalleTurneroUC(IRepository repo, IQRProvider qrProvider)
        {
            _repository = repo;
            _qrProvider = qrProvider;
        }

        public DetalleTurneroResponse Procesar(DetalleTurneroRequest req)
        {
            var turnero = _repository.Turneros.Include(t => t._turnos).FirstOrDefault(t => t.Id == req.IdTurnero);

            if(turnero == null)
            {
                throw new Exception("Turnero no encontrado");
            }

            var proximoTurno = turnero.Proximo();

            return new DetalleTurneroResponse()
            {
                Id = turnero.Id,
                IdPropietario = turnero.IdPropietario,
                IdSiguienteTurno = proximoTurno?.Id.ToString(),
                Concepto = turnero.Concepto,
                Ciudad = turnero.Direccion.Ciudad,
                Calle = turnero.Direccion.Calle,
                Numero = turnero.Direccion.Numero,
                Qr = _qrProvider.Encode(turnero.Id.ToString()),
                CantidadMaxima = turnero.CantidadMaxima,
                Latitud = turnero.Ubicacion.Latitud,
                Longitud = turnero.Ubicacion.Longitud
            };
        }
    }
}
