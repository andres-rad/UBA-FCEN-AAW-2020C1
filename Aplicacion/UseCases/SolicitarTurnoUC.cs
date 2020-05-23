using Aplicacion.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases
{
    public class SolicitarTurnoUC
    {
        IQRProvider _qrp;
        IRepositoryTurnero _repositoryTurnero;

        public SolicitarTurnoUC(IQRProvider qrp, IRepositoryTurnero repositoryTurnero)
        {
            _qrp = qrp;
            _repositoryTurnero = repositoryTurnero;
        }

        public SolicitarTurnoResponse Procesar(SolicitarTurnoRequest request)
        {

            var turnero = _repositoryTurnero.GetTurneroById(request.idTurnero);

            var turno = turnero.NuevoTurno();

            var response = new SolicitarTurnoResponse
            {
                Concepto = request.idTurnero,
                QR = _qrp.Encode(turno.ToString())
            };

            return response;
        }
    }

}
