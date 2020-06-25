namespace Aplicacion.UseCases.Propietario
{
    public class AtenderTurnoResponse
    {
        public int IdTurnero { get; set; }
        public string IdPropietario { get; set; }
        public int? NumeroTurnoEnLlamada { get; set; }
        public int NumeroTurnoEnQr { get; set; }
        public int CantidadEnEspera { get; set; }
        public string Concepto { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string QrTurnero { get; set; }
        public int CantidadMaxima { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public System.Collections.Generic.List<string> Files { get; set; }

    }
}