using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AeropuertoWeb.Controllers
{
    public class TEMPReportesController : Controller
    {
        public IActionResult Cancelados()
        {
            // --- MOCKING: CREAMOS UNA TABLA VIRTUAL TEMPORAL ---
            DataTable dtFalso = new DataTable();
            dtFalso.Columns.Add("ID_VUELO");
            dtFalso.Columns.Add("ORIGEN");
            dtFalso.Columns.Add("DESTINO");
            dtFalso.Columns.Add("FECHA_SALIDA");
            dtFalso.Columns.Add("ESTADO");

            // Metemos datos inventados para que Kevin diseñe
            dtFalso.Rows.Add("V-101", "Guatemala", "Madrid", "2026-05-16 14:00", "CANCELADO");
            dtFalso.Rows.Add("V-205", "Guatemala", "Miami", "2026-05-17 09:30", "REPROGRAMADO");

            // Le mandamos esta tabla falsa a la vista de Kevin
            return View(dtFalso);

            /* --- CUANDO VENGA ALEX, BORRAS LO DE ARRIBA Y DESCOMENTAS ESTO ---
            DataTable dtReal = _dbManager.ConsultarLectura("SP_REPORTE_CANCELADOS", ...);
            return View(dtReal);
            */
        }
    }
}