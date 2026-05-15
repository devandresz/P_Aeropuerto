using Microsoft.AspNetCore.Mvc;
using AeropuertoWeb.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace AeropuertoWeb.Controllers
{
    public class VueloController : Controller
    {
        private readonly DatabaseManager _dbManager;

        public VueloController(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        // 1. Vista del Buscador (Tipo Iberia)
        public IActionResult Index()
        {
            return View();
        }

        // 2. Buscar Vuelos (CONSULTA -> REPLICA .101)
        [HttpPost]
        public IActionResult Buscar(string origen, string destino)
        {
            DataTable dt = new DataTable();
            OracleParameter[] paramsBusqueda = new OracleParameter[]
            {
                new OracleParameter("P_ORIGEN", OracleDbType.Varchar2) { Value = origen },
                new OracleParameter("P_DESTINO", OracleDbType.Varchar2) { Value = destino },
                new OracleParameter("P_CURSOR", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };

            // Regla de oro: Lecturas pesadas van a la réplica
            dt = _dbManager.ConsultarReplica("SP_BUSCAR_VUELOS", paramsBusqueda);
            return View("Resultados", dt);
        }

        // 3. Confirmar Compra (TRANSACCIÓN -> PRODUCTIVA .100)
        [HttpPost]
        public IActionResult Reservar(int idVuelo, string nombre, string apellido, string pasaporte)
        {
            try
            {
                OracleParameter[] paramsReserva = new OracleParameter[]
                {
                    new OracleParameter("P_ID_VUELO", OracleDbType.Int32) { Value = idVuelo },
                    new OracleParameter("P_NOMBRE", OracleDbType.Varchar2) { Value = nombre },
                    new OracleParameter("P_APELLIDO", OracleDbType.Varchar2) { Value = apellido },
                    new OracleParameter("P_PASAPORTE", OracleDbType.Varchar2) { Value = pasaporte }
                };

                // Regla de oro: Escrituras van a la primaria
                _dbManager.EjecutarProductiva("SP_REGISTRAR_RESERVA", paramsReserva);

                ViewBag.Mensaje = "¡Reserva completada con éxito!";
                return View("Confirmacion");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "No se pudo procesar la reserva: " + ex.Message;
                return View("Error");
            }
        }
    }
}