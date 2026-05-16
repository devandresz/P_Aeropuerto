using Microsoft.AspNetCore.Mvc;
using System.Data;
using AeropuertoWeb.Models;
using Oracle.ManagedDataAccess.Client;
using System;

namespace AeropuertoWeb.Controllers
{
    [Route("Vuelo")]
    [Route("Vuelo/[action]")]
    public class VueloController : Controller
    {
        private readonly DatabaseManager _db;

        public VueloController(DatabaseManager databaseManager)
        {
            _db = databaseManager;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return Content(@"
                <!DOCTYPE html>
                <html lang='es'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>AeroPortal - Panel de Control de Vuelos</title>
                    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css'>
                    <style>
                        body { background: linear-gradient(135deg, #122240 0%, #1d3557 100%); min-height: 100vh; color: #f8f9fa; font-family: 'Segoe UI', sans-serif; }
                        .card { border-radius: 16px; border: none; background-color: rgba(255, 255, 255, 0.95); color: #212529; }
                        .btn-primary { background-color: #1d3557; border: none; padding: 12px; font-weight: 600; }
                        .btn-primary:hover { background-color: #457b9d; }
                        .form-control { border-radius: 8px; padding: 12px; }
                    </style>
                </head>
                <body class='d-flex align-items-center justify-content-center'>
                    <div class='container' style='max-width: 600px;'>
                        <div class='card shadow-lg p-4 p-md-5'>
                            <div class='text-center mb-4'>
                                <h2 class='fw-bold text-dark'>✈️ AeroPortal Pasajeros</h2>
                                <p class='text-muted'>Búsqueda en Tiempo Real (Conectado a Réplica .101)</p>
                            </div>
                            
                            <form action='/Vuelo/BuscarVuelo' method='POST'>
                                <div class='mb-3'>
                                    <label class='form-label fw-semibold text-secondary'>Ciudad de Origen</label>
                                    <input type='text' name='origen' class='form-control' placeholder='Ej. Ori 1' required />
                                </div>
                                <div class='mb-4'>
                                    <label class='form-label fw-semibold text-secondary'>Ciudad de Destino</label>
                                    <input type='text' name='destino' class='form-control' placeholder='Ej. Des 1' required />
                                </div>
                                <button type='submit' class='btn btn-primary w-100 shadow-sm mt-2'>Consultar Disponibilidad</button>
                            </form>
                        </div>
                    </div>
                </body>
                </html>", "text/html; charset=utf-8");
        }

        [HttpPost]
        public IActionResult BuscarVuelo(string origen, string destino)
        {
            try
            {
                string busquedaOrigen = string.IsNullOrEmpty(origen) ? "" : origen;
                string busquedaDestino = string.IsNullOrEmpty(destino) ? "" : destino;

                OracleParameter[] parametros = new OracleParameter[]
                {
                    new OracleParameter("P_ORIGEN", OracleDbType.Varchar2, busquedaOrigen, ParameterDirection.Input),
                    new OracleParameter("P_DESTINO", OracleDbType.Varchar2, busquedaDestino, ParameterDirection.Input),
                    new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output)
                };

                DataTable dtVuelos = _db.ConsultarLectura("SP_BUSCAR_VUELOS", parametros);

                System.Text.StringBuilder html = new System.Text.StringBuilder();
                html.Append(@"
                    <!DOCTYPE html>
                    <html lang='es'>
                    <head>
                        <meta charset='UTF-8'>
                        <title>AeroPortal - Resultados</title>
                        <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css'>
                        <style>
                            body { background-color: #f4f6f9; color: #333; padding: 30px; }
                            .navbar-custom { background-color: #1a252f; color: white; padding: 15px; border-radius: 8px; margin-bottom: 20px; }
                            .table-container { background: white; padding: 20px; border-radius: 12px; box-shadow: 0 4px 6px rgba(0,0,0,0.05); }
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='navbar-custom d-flex justify-content-between align-items-center'>
                                <h4 class='m-0'>✈️ AeroPortal - Resultados de Vuelos</h4>
                                <a href='/Vuelo/Index' class='btn btn-outline-light btn-sm'>Nueva Búsqueda</a>
                            </div>
                            <div class='table-container'>
                                <table class='table table-striped table-hover align-middle'>
                                    <thead class='table-dark'>
                                        <tr>
                                            <th>ID VUELO</th>
                                            <th>ORIGEN</th>
                                            <th>DESTINO</th>
                                            <th>ESTADO</th>
                                            <th>RESERVA DE BOLETO</th>
                                        </tr>
                                    </thead>
                                    <tbody>");

                if (dtVuelos != null && dtVuelos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtVuelos.Rows)
                    {
                        string idVuelo = row[0].ToString();
                        string ori = row[1].ToString();
                        string des = row[2].ToString();
                        string est = row[7].ToString();

                        html.Append("<tr>");
                        html.Append($"<td><strong>{idVuelo}</strong></td>");
                        html.Append($"<td>{ori}</td>");
                        html.Append($"<td>{des}</td>");
                        html.Append($"<td><span class='badge bg-success'>{est}</span></td>");
                        html.Append($@"<td>
                                        <form action='/Vuelo/ComprarBoleto' method='POST' class='row g-2 align-items-center'>
                                            <input type='hidden' name='idVuelo' value='{idVuelo}' />
                                            <div class='col-auto'><input type='text' name='nombre' placeholder='Nombre Pasajero' class='form-control form-control-sm' required /></div>
                                            <div class='col-auto'><input type='text' name='pasaporte' placeholder='Pasaporte' class='form-control form-control-sm' required /></div>
                                            <div class='col-auto'><button type='submit' class='btn btn-sm btn-dark'>Confirmar Compra</button></div>
                                        </form>
                                      </td>");
                        html.Append("</tr>");
                    }
                }
                else
                {
                    html.Append("<tr><td colspan='5' class='text-center text-muted py-4'>No se encontraron vuelos activos en Oracle para esta ruta de origen/destino.</td></tr>");
                }

                html.Append("</tbody></table></div></div></body></html>");
                return Content(html.ToString(), "text/html; charset=utf-8");
            }
            catch (Exception ex)
            {
                return Content("ERROR OPERACIONAL EN EL CURSOR DE LECTURA: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult ComprarBoleto(string idVuelo, string nombre, string pasaporte)
        {
            try
            {
                string numeroTicket = "TKT-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                OracleParameter[] parametros = new OracleParameter[]
                {
                    new OracleParameter("P_ID_VUELO", OracleDbType.Int32, Convert.ToInt32(idVuelo), ParameterDirection.Input),
                    new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, nombre, ParameterDirection.Input),
                    new OracleParameter("P_PASAPORTE", OracleDbType.Varchar2, pasaporte, ParameterDirection.Input),
                    new OracleParameter("P_NUMERO_TICKET", OracleDbType.Varchar2, numeroTicket, ParameterDirection.Input)
                };

                _db.EjecutarEscritura("SP_COMPRAR_BOLETO", parametros);

                return Content($@"
                    <script>
                        alert('¡RESERVA CONFIRMADA EXITOSAMENTE!\n\nPasajero: {nombre}\nTicket Asignado: {numeroTicket}\nLínea de Vuelo: {idVuelo}');
                        window.location.href = '/Vuelo/Index';
                    </script>", "text/html; charset=utf-8");
            }
            catch (Exception ex)
            {
                return Content("ERROR OPERACIONAL DE ESCRITURA EN TABLA BOLETOS: " + ex.Message);
            }
        }
    }
}