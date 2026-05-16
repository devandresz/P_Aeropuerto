using System.Diagnostics;
using AeropuertoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AeropuertoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Auth");
        }
        public IActionResult ProbarConexion()
        {
            try
            {
                // Copiamos tu cadena exacta del appsettings
                string cadenaConexion = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.100)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=aurorapdb)));User Id=USR_AURORA;Password=1234;";

                using (Oracle.ManagedDataAccess.Client.OracleConnection conn = new Oracle.ManagedDataAccess.Client.OracleConnection(cadenaConexion))
                {
                    conn.Open(); // Intentamos abrir la puerta
                    return Content("¡EXITO! C# se conectó perfectamente a la base de datos de Alex en la IP .100");
                }
            }
            catch (Exception ex)
            {
                return Content("FALLO LA CONEXIÓN: " + ex.Message);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
