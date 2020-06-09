using Dominio;

namespace Aplicacion.UseCases.Propietario
{
    public class EditarTurneroRequest
    {
        public string IdPropietario { get; set; }
        public LatLon Ubicacion { get; set; }
        public int IdTurnero { get; set;}
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Concepto { get; set; }
        public int CantidadMaxima { get; set; }
    }
}
