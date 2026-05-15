using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;

namespace AeropuertoWeb.Controllers
{
    public class VueloController : Controller
    {
        // Esta es la pantalla principal del buscador
        public IActionResult Index()
        {
            return View();
        }

        // Esta es la ruta /Vuelo/TEMP_BuscarVuelo a la que apuntará Kevin
        [HttpPost]
        public IActionResult TEMP_BuscarVuelo(string origen, string destino)
        {
            // --- MOCKING: TABLA FALSA DE VUELOS ---
            DataTable dtTEMP_Vuelos = new DataTable();
            dtTEMP_Vuelos.Columns.Add("ID_VUELO");
            dtTEMP_Vuelos.Columns.Add("AEROLINEA");
            dtTEMP_Vuelos.Columns.Add("FECHA_SALIDA");
            dtTEMP_Vuelos.Columns.Add("PRECIO");

            // Vuelos falsos para que Kevin diseñe los resultados
            dtTEMP_Vuelos.Rows.Add("IB-6342", "IBERIA", "2026-05-20 18:00", "$ 850.00");
            dtTEMP_Vuelos.Rows.Add("IB-6343", "IBERIA", "2026-05-21 20:30", "$ 920.00");

            return View("Resultados", dtTEMP_Vuelos);
        }

        // Esta es la ruta /Vuelo/TEMP_ComprarBoleto a la que apuntará Kevin
        [HttpPost]
        public IActionResult TEMP_ComprarBoleto(string idVuelo, string nombre, string pasaporte)
        {
            // --- MOCKING: SIMULACIÓN DE COMPRA ---
            ViewBag.Mensaje = $"¡Reserva confirmada para {nombre} en el vuelo {idVuelo}!";
            ViewBag.NumeroTicket = "TKT-" + new Random().Next(1000, 9999);

            return View("Confirmacion");
        }
    }
}