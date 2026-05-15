using Microsoft.AspNetCore.Mvc;

namespace AeropuertoWeb.Controllers
{
    public class TEMPUsuarioController : Controller
    {
        [HttpPost]
        public IActionResult LoginCliente(string correo, string password)
        {
            // --- MOCKING: SIMULACIÓN TEMPORAL ---
            // Si Kevin escribe esto, lo dejamos pasar.
            if (correo == "cliente@correo.com" && password == "cliente123")
            {
                return RedirectToAction("Index", "Home"); // Lo manda a la página principal
            }
            else
            {
                ViewBag.Error = "Credenciales incorrectas (Usa: cliente@correo.com / cliente123)";
                return View("~/Views/Home/Login.cshtml"); // Lo regresa al login
            }

            /* --- CUANDO VENGA ALEX, BORRAS LO DE ARRIBA Y DESCOMENTAS ESTO ---
            bool esValido = _dbManager.EjecutarEscritura("SP_LOGIN_USUARIO", ...);
            if(esValido) { return RedirectToAction("Index", "Home"); }
            else { return View("~/Views/Home/Login.cshtml"); }
            */
        }

        [HttpPost]
        public IActionResult LoginAdmin(string usuario, string password, string codigo)
        {
            // Simulación para el Admin
            if (usuario == "admin" && password == "admin123")
            {
                return RedirectToAction("Cancelados", "Reportes"); // Lo manda a ver reportes
            }
            ViewBag.Error = "Error de administrador.";
            return View("~/Views/Home/Login.cshtml");
        }
    }
}