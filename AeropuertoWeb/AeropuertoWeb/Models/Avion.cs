namespace AeropuertoWeb.Models
{
    public class Avion
    {
        public int IdAvion { get; set; }
        public string Modelo { get; set; }
        public int Capacidad { get; set; }
        public int AeropuertoId { get; set; }
    }
}