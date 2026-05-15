using System;

namespace AeropuertoWeb.Models
{
    public class Asiento
    {
        public int IdAsiento { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public string EstadoReserva { get; set; } // 'CONFIRMADA', 'PENDIENTE'
    }
}