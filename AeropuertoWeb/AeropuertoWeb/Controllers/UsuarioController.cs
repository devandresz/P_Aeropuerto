using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using AeropuertoWeb.Models;

namespace AeropuertoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DatabaseManager _db;

        // Inyectamos el DatabaseManager
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

                // Llamamos a la Productiva
                _db.EjecutarEscritura("SP_LOGIN_USUARIO", parametros);

                // Sacamos el valor de P_RESULTADO
                int resultado = Convert.ToInt32(parametros[2].Value.ToString());

                if (resultado == 1)
                {
                    return RedirectToAction("Index", "Home"); // Éxito
                }
                else
                {
                    ViewBag.Error = "Credenciales incorrectas.";
                    return View("~/Views/Home/Login.cshtml"); // Fallo
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error de conexión: " + ex.Message;
                return View("~/Views/Home/Login.cshtml");
            }
        }
    }
}