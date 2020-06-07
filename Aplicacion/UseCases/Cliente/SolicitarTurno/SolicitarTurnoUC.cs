using Aplicacion.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class SolicitarTurnoUC
    {
        IQRProvider _qrp;
        IRepository _repository;

        public SolicitarTurnoUC(IQRProvider qrp, IRepository repo)
        {
            _qrp = qrp;
            _repository = repo;
        }

        public SolicitarTurnoResponse Procesar(SolicitarTurnoRequest request)
        {

            var turnero = _repository.Turneros.Find(request.IdTurnero);

            if(turnero == null)
            {
                throw new Exception("Turnero no existente");
            }

            var turno = turnero.ExpedirTurno();

            _repository.SaveChanges();

            var response = new SolicitarTurnoResponse
            {
                Concepto = turnero.Concepto,
                QR = _qrp.Encode(turno.ToString())
            };

            return response;
        }
    }

}
