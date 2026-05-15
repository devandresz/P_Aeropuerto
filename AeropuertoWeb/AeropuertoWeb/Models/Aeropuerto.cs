namespace AeropuertoWeb.Models
{
    public class Aeropuerto
    {
        public int IdAeropuerto { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int IdAerolinea { get; set; }
    }
}