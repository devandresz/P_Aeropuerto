using Microsoft.AspNetCore.Mvc;
using System.Data;
using AeropuertoWeb.Models;
using Oracle.ManagedDataAccess.Client;
using System;

namespace AeropuertoWeb.Controllers
{
    public class ModulesController : Controller
    {
        private readonly DatabaseManager _db;

        public ModulesController(DatabaseManager dbManager)
        {
            _db = dbManager;
        }

        // Vistas Básicas de Kevin
        public IActionResult Dashboard() { return View(); }
        public IActionResult Usuarios() { return View(); }
        public IActionResult Aerolineas() { return View(); }
        public IActionResult Equipaje() { return View(); }
        public IActionResult Factura() { return View(); }
        public IActionResult Tripulacion() { return View(); }
        public IActionResult HistorialVuelo() { return View(); }

        // ==========================================
        // PERSISTENCIA REAL PARA NUEVO TRIPULANTE
        // ==========================================
        [HttpPost]
        public IActionResult GuardarTripulacion(int idTripulacion, string nombre, string apellido, string rol)
        {
            try
            {
                OracleParameter[] parametros = new OracleParameter[]
                {
                    new OracleParameter("ID", OracleDbType.Int32, idTripulacion, ParameterDirection.Input),
                    new OracleParameter("NOM", OracleDbType.Varchar2, nombre, ParameterDirection.Input),
                    new OracleParameter("APE", OracleDbType.Varchar2, apellido, ParameterDirection.Input),
                    new OracleParameter("ROL", OracleDbType.Varchar2, rol, ParameterDirection.Input)
                };

                string query = "INSERT INTO AER_TRIPULACION (ID_TRIPULACION, NOMBRE, APELLIDO, ROL) VALUES (:ID, :NOM, :APE, :ROL)";

                // CORRECCIÓN: Usamos el método que sí existe en tu DatabaseManager
                _db.EjecutarEscritura(query, parametros);

                return Content("<script>alert('¡Tripulante guardado con éxito en Oracle!'); window.location.href='/Modules/Tripulacion';</script>", "text/html; charset=utf-8");
            }
            catch (Exception ex)
            {
                return Content("ERROR AL INSERTAR TRIPULACIÓN EN BD: " + ex.Message);
            }
        }

        // ==========================================
        // PERSISTENCIA REAL PARA HISTORIAL DE VUELO
        // ==========================================
        [HttpPost]
        public IActionResult GuardarHistorial(int idHistorial, int idTripulacion, int idAvion, DateTime fechaSalida)
        {
            try
            {
                OracleParameter[] parametros = new OracleParameter[]
                {
                    new OracleParameter("ID_H", OracleDbType.Int32, idHistorial, ParameterDirection.Input),
                    new OracleParameter("ID_T", OracleDbType.Int32, idTripulacion, ParameterDirection.Input),
                    new OracleParameter("ID_A", OracleDbType.Int32, idAvion, ParameterDirection.Input),
                    new OracleParameter("FECHA", OracleDbType.Date, fechaSalida, ParameterDirection.Input)
                };

                string query = "INSERT INTO AER_HISTORIALVUELO (ID_HISTORIAL, ID_TRIPULACION, ID_AVION, FECHA_SALIDA) VALUES (:ID_H, :ID_T, :ID_A, :FECHA)";

                // CORRECCIÓN: Usamos el método que sí existe en tu DatabaseManager
                _db.EjecutarEscritura(query, parametros);

                return Content("<script>alert('¡Historial de vuelo registrado con éxito!'); window.location.href='/Modules/HistorialVuelo';</script>", "text/html; charset=utf-8");
            }
            catch (Exception ex)
            {
                return Content("ERROR AL INSERTAR HISTORIAL EN BD: " + ex.Message);
            }
        }
    }
}