using Aplicacion.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class SolicitarTurnoUC : IUseCase
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

            var turnero = _repository.Turneros.Include(t => t._turnos).FirstOrDefault(t => t.Id == request.IdTurnero);

            if(turnero == null)
            {
                throw new Exception("Turnero no existente");
            }

            var turno = turnero.ExpedirTurno(request.Email);

            _repository.SaveChanges();
            
            var response = new SolicitarTurnoResponse
            {
                Concepto = turnero.Concepto,
                QR = _qrp.Encode(turno.Id.ToString())
            };

            return response;
        }
    }

}
