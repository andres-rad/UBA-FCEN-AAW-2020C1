using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class DetalleTurneroClienteUC : IUseCase
    {
        private readonly IRepository _repository;
        private readonly IQRProvider _qrProvider;

        public DetalleTurneroClienteUC(IRepository repo, IQRProvider qrProvider)
        {
            _repository = repo;
            _qrProvider = qrProvider;
        }

        public DetalleTurneroClienteResponse Procesar(DetalleTurneroClienteRequest req)
        {
            var turnero = _repository.Turneros.Include(t => t.Turnos).FirstOrDefault(t => t.Id == req.IdTurnero);

            if(turnero == null)
            {
                throw new Exception("Turnero no encontrado");
            }

            return new DetalleTurneroClienteResponse()
            {
                Id = turnero.Id,
                IdPropietario = turnero.IdPropietario,
                Concepto = turnero.Concepto,
                Ciudad = turnero.Direccion.Ciudad,
                Calle = turnero.Direccion.Calle,
                Numero = turnero.Direccion.Numero,
                Latitud = turnero.Ubicacion.Latitud,
                Longitud = turnero.Ubicacion.Longitud,
                Qr = _qrProvider.Encode(turnero.Id.ToString()),
                CantidadMaxima = turnero.CantidadMaxima,
                CantidadEnEspera = turnero.CantidadEnEspera(),
            };
        }
    }
}
