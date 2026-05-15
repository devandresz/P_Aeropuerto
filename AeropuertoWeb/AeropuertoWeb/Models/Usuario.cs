namespace AeropuertoWeb.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; } // 'ADMIN' o 'CLIENTE'
    }
}