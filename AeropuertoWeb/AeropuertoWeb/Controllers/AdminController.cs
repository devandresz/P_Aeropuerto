using Microsoft.AspNetCore.Mvc;

namespace AeropuertoWeb.Controllers;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        if (!IsAdmin())
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    private bool IsAdmin()
    {
        var role = HttpContext.Session.GetString("UserRole");
        return string.Equals(role, "Administrador", StringComparison.OrdinalIgnoreCase)
            || string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
    }
}
