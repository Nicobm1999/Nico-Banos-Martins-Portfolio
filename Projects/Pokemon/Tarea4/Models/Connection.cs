using System.Data.SqlClient;

namespace Tarea4.Models
{
    public class Connection
    {
        private readonly string _connectionString;

        public Connection(string valor)
        {
            _connectionString = valor;
        }

        public SqlConnection GetConnection()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
