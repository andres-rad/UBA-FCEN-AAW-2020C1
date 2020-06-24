namespace Aplicacion.UseCases.Cliente
{
    public class DetallarTurnoResponse
    {
        public int IdTurnero { get; set; }
        public string Concepto { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int IdTurno { get; set; }
        public int NumeroTurno { get; set; }
        public int EsperaEstimada { get; set; }
       public string QrTurno { get; set; }
    }
}