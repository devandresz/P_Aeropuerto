using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace AeropuertoWeb.Models
{
    public class DatabaseManager
    {
        private readonly string _cadenaProductiva;
        private readonly string _cadenaReplica;

        public DatabaseManager(IConfiguration configuration)
        {
            // Extrae las IPs del appsettings.json
            _cadenaProductiva = configuration.GetConnectionString("Productiva");
            _cadenaReplica = configuration.GetConnectionString("Replica");
        }

        // 1. MÉTODO PARA TRANSACCIONES (Usa la IP .100 Productiva)
        // Se usa para: Comprar vuelos, Registrar clientes, Login.
        public void EjecutarProductiva(string nombreSp, OracleParameter[] parametros = null)
        {
            using (OracleConnection conn = new OracleConnection(_cadenaProductiva))
            {
                using (OracleCommand cmd = new OracleCommand(nombreSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null) cmd.Parameters.AddRange(parametros);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 2. MÉTODO PARA REPORTES (Usa la IP .101 Réplica Standby)
        // Se usa EXCLUSIVAMENTE para los reportes A al H.
        public DataTable ConsultarReplica(string nombreSp, OracleParameter[] parametros = null)
        {
            DataTable dt = new DataTable();
            using (OracleConnection conn = new OracleConnection(_cadenaReplica))
            {
                using (OracleCommand cmd = new OracleCommand(nombreSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null) cmd.Parameters.AddRange(parametros);

                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}