using Microsoft.AspNetCore.Mvc;

namespace AeropuertoWeb.Controllers;

public class ClienteController : Controller
{
    public IActionResult Dashboard()
    {
        if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("UserRole")))
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }
}
