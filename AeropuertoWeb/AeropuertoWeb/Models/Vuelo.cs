namespace AeropuertoWeb.Models
{
    public class Vuelo
    {
        public string IdVuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string FechaSalida { get; set; }
        public string Precio { get; set; }
        public string Estado { get; set; }
    }
}