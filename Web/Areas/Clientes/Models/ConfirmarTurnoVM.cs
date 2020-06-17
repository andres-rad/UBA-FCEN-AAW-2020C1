using Aplicacion.UseCases.Cliente;

namespace Web.Areas.Clientes.Models
{
    public class ConfirmarTurnoVM
    {
        public int IdTurnero { get; set; }
        public string Concepto { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string MensajePersonasFila { get; set; }
        public bool FilaLlena { get; set; }
        public ConfirmarTurnoVM(DetalleTurneroClienteResponse response)
        {
            IdTurnero = response.Id;
            Latitud = response.Latitud;
            Longitud = response.Longitud;
            Concepto = response.Concepto;
            Ciudad = response.Ciudad;
            Calle = response.Calle;
            Numero = response.Numero;
            FilaLlena = response.CantidadEnEspera == response.CantidadMaxima;

            if (response.CantidadEnEspera == 0)
            {
                MensajePersonasFila = "No hay gente en la fila!";
            } else
            {
                MensajePersonasFila = $"Hay {response.CantidadEnEspera} persona{(response.CantidadEnEspera == 1 ? "" : "s")} en la fila";
            }
            
        }
    }
}
