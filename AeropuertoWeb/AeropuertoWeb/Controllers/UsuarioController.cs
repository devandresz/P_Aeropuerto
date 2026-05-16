using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using AeropuertoWeb.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace AeropuertoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DatabaseManager _db;

        public UsuarioController(DatabaseManager dbManager)
        {
            _db = dbManager;
        }

        [HttpPost]
        public IActionResult LoginCliente(string correo, string password)
        {
            try
            {
                OracleParameter[] parametros = new OracleParameter[]
                {
                    new OracleParameter("P_CORREO", OracleDbType.Varchar2, correo, ParameterDirection.Input),
                    new OracleParameter("P_PASSWORD", OracleDbType.Varchar2, password, ParameterDirection.Input),
                    new OracleParameter("P_RESULTADO", OracleDbType.Int32, ParameterDirection.Output)
                };

                // Consulta a la productiva (.100)
                _db.EjecutarEscritura("SP_LOGIN_USUARIO", parametros);

                string valorResultado = parametros[2].Value?.ToString() ?? "0";
                int resultado = Convert.ToInt32(valorResultado);

                if (resultado == 1)
                {
                    if (correo.Equals("admin@aeroport.com", StringComparison.OrdinalIgnoreCase) ||
                        correo.Contains("admin") ||
                        correo.Equals("mcano@mail.com", StringComparison.OrdinalIgnoreCase))
                    {
                        HttpContext.Session.SetString("UserRole", "Administrador");
                        HttpContext.Session.SetString("UserName", "Andres Admin");

                        return RedirectToAction("Dashboard", "Modules");
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserRole", "Cliente");
                        HttpContext.Session.SetString("UserName", "Juan Pasajero");

                        return RedirectToAction("Index", "Vuelo");
                    }
                }
                else
                {
                    ViewBag.Error = "Credenciales incorrectas. Verifica tu correo y contraseña.";
                    return View("~/Views/Auth/Login.cshtml");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error de conexión con la infraestructura de Oracle: " + ex.Message;
                return View("~/Views/Auth/Login.cshtml");
            }
        }
    }
}