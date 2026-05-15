using AeropuertoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AeropuertoWeb.Controllers;

public class AuthController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        HttpContext.Session.Clear();
        return View(new LoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        var isAdmin = IsAdminRole(model.SelectedRole);
        var role = isAdmin ? "Administrador" : "Cliente";
        var userName = isAdmin ? model.AdminUser : model.ClientEmail;

        if (!isAdmin && (model.ClientEmail != "cliente@correo.com" || model.ClientPassword != "cliente123"))
        {
            model.Message = "Credenciales incorrectas. Usa: cliente@correo.com / cliente123";
            model.SelectedRole = "Cliente";
            return View(model);
        }

        if (isAdmin && (model.AdminUser != "admin" || model.AdminPassword != "admin123"))
        {
            model.Message = "Credenciales administrativas incorrectas.";
            model.SelectedRole = "Administrador";
            return View(model);
        }

        HttpContext.Session.SetString("AuthToken", "test-session");
        HttpContext.Session.SetString("UserId", isAdmin ? "admin-test" : "1");
        HttpContext.Session.SetString("UserName", string.IsNullOrWhiteSpace(userName) ? "Usuario de prueba" : userName);
        HttpContext.Session.SetString("UserRole", role);

        return RedirectToAction("Dashboard", isAdmin ? "Admin" : "Cliente");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    private static bool IsAdminRole(string? role)
    {
        return string.Equals(role, "Administrador", StringComparison.OrdinalIgnoreCase)
            || string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
    }
}
