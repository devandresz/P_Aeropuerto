using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace AeropuertoWeb.Models
{
    public class DatabaseManager
    {
        private readonly string _prodConn;
        private readonly string _replConn;

        public DatabaseManager(IConfiguration config)
        {
            _prodConn = config.GetConnectionString("Productiva");
            _replConn = config.GetConnectionString("Replica");
        }

        // Para LOGIN y COMPRAS (IP .100)
        public void EjecutarEscritura(string spNombre, OracleParameter[] parametros = null)
        {
            using (OracleConnection conn = new OracleConnection(_prodConn))
            {
                using (OracleCommand cmd = new OracleCommand(spNombre, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Para REPORTES A-H (IP .101 - REPLICA)
        public DataTable ConsultarLectura(string spNombre, OracleParameter[] parametros = null)
        {
            DataTable dt = new DataTable();
            using (OracleConnection conn = new OracleConnection(_replConn))
            {
                using (OracleCommand cmd = new OracleCommand(spNombre, conn))
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