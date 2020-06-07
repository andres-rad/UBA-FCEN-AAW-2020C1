namespace Dominio
{
    public struct LatLon
    {
        public double Latitud { get;  }
        public double Longitud { get; }

        public LatLon(double lat, double lon)
        {
            Latitud = lat;
            Longitud = lon;
        }
    }
}