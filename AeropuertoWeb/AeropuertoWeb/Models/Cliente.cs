using System;

namespace AeropuertoWeb.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nit { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Pasaporte { get; set; }
        public int IdUsuario { get; set; }
    }
}