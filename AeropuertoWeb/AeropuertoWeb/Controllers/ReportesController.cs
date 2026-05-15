using Microsoft.AspNetCore.Mvc;
using AeropuertoWeb.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace AeropuertoWeb.Controllers
{
    public class ReportesController : Controller
    {
        private readonly DatabaseManager _dbManager;

        // Inyectamos el gestor de base de datos que creaste antes
        public ReportesController(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        // Esta es la ruta a la que Kevin accederá: /Reportes/Cancelados
        public IActionResult Cancelados()
        {
            DataTable dtVuelos = new DataTable();

            try
            {
                // Preparamos los parámetros (igualitos a los de tu PL/SQL)
                OracleParameter[] parametros = new OracleParameter[]
                {
                    new OracleParameter("P_TIPO_REPORTE", OracleDbType.Varchar2) { Value = "DIA" },
                    new OracleParameter("P_FECHA", OracleDbType.Date) { Value = DateTime.Now },
                    // Parámetro de salida que recibe la tabla de Oracle
                    new OracleParameter("P_CURSOR", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                // ¡ATENCIÓN A LA RÚBRICA! Usamos ConsultarReplica (IP .101)
                dtVuelos = _dbManager.ConsultarReplica("SP_REPORTE_CANCELADOS", parametros);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al conectar con la Réplica: " + ex.Message;
            }

            // Le mandamos los datos a la vista de Kevin
            return View(dtVuelos);
        }
    }
}