namespace AeropuertoWeb.Models
{
    public class Aerolinea
    {
        public int IdAerolinea { get; set; }
        public string CodigoAita { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; } // 'ACTIVA' o 'INACTIVA'
    }
}