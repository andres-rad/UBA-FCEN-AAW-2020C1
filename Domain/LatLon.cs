namespace Dominio
{
    public struct LatLon
    {
        public double Latitud { get; internal set; }
        public double Longitud { get; internal set; }

        public LatLon(double lat, double lon)
        {
            Latitud = lat;
            Longitud = lon;
        }
    }
}