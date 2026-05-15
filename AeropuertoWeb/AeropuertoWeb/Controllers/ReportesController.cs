using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AeropuertoWeb.Controllers
{
    public class ReportesController : Controller
    {
        // Pantalla principal del Dashboard de Admin
        public IActionResult Index()
        {
            return View();
        }

        // Reporte C: Vuelos programados
        public IActionResult TEMP_ReporteProgramados()
        {
            DataTable dtTEMP_Programados = new DataTable();
            dtTEMP_Programados.Columns.Add("VUELO");
            dtTEMP_Programados.Columns.Add("DESTINO");
            dtTEMP_Programados.Columns.Add("ESTADO");

            dtTEMP_Programados.Rows.Add("IB-001", "Madrid", "A TIEMPO");
            return View("ListaVuelos", dtTEMP_Programados);
        }

        // Reporte E: Aerolíneas Activas
        public IActionResult TEMP_ReporteAerolineas()
        {
            DataTable dtTEMP_Aero = new DataTable();
            dtTEMP_Aero.Columns.Add("NOMBRE");
            dtTEMP_Aero.Columns.Add("PAIS");
            dtTEMP_Aero.Columns.Add("ESTADO");

            dtTEMP_Aero.Rows.Add("IBERIA", "España", "ACTIVA");
            dtTEMP_Aero.Rows.Add("AVIANCA", "Colombia", "ACTIVA");
            return View("Aerolineas", dtTEMP_Aero);
        }

        // TODO: Dejar el espacio para cuando Alex traiga los demás reportes (Arrestos, Objetos perdidos, etc.)
    }
}