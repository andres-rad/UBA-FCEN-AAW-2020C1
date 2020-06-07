using Dominio;
using System.Collections.Generic;
using System.Linq;
using QRCoder;

namespace Domain
{
    public class Turnero
    {
        public int Id { get; internal set; }
        public string IdPropietario { get; internal set; }
        public string Concepto { get; internal set; }
        public LatLon Ubicacion { get; internal set; }
        public Direccion Direccion{ get; internal set; }
        public string Qr { get; internal set; }

        List<Turno> _turnos;

        private Turnero() { }
        public Turnero(string idPropietario, string concepto, Direccion direccion)
        {
            IdPropietario = idPropietario;
            Concepto = concepto;
            Direccion = direccion;
            Qr = GenerarQr();
            _turnos = new List<Turno>();
        }

        string GenerarQr()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(GetQRHash(), QRCodeGenerator.ECCLevel.Q);
            return new Base64QRCode(qrCodeData).GetGraphic(20);
        }

        string GetQRHash()
        {
            return IdPropietario + Concepto + Direccion.Ciudad + Direccion.Calle + Direccion.Numero.ToString();
        }
        public Turno ExpedirTurno()
        {
            var turno = new Turno()
            {

            };

            _turnos.Add(turno);

            return turno;
        }

        public Turno ProximoTurno()
        {
            return _turnos.FirstOrDefault();
        }

        public void Avanzar()
        {
            _turnos.RemoveAt(0);
        }

        public void Cancelar(int idTurno)
        {
            var turno = _turnos.Find(turno => turno.Id == idTurno);
            _turnos.Remove(turno);
        }
    }
}
