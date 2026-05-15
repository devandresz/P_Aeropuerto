using Microsoft.AspNetCore.Mvc;

namespace AeropuertoWeb.Controllers;

public class InfoController : Controller
{
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
}
