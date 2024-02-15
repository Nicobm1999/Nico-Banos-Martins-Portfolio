using System.Data.SqlClient;

namespace Kalaria.Models
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
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
