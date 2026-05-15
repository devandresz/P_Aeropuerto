using System;

namespace AeropuertoWeb.Models
{
    public class Migracion
    {
        public int IdMigracion { get; set; }
        public int IdCliente { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public string HoraSalida { get; set; }
    }
}