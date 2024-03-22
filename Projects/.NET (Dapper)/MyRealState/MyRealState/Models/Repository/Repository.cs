using Dapper;

namespace MyRealState.Models.Repository
{
    public class Repository : IRepository
    {
        private readonly Connection _connection;
        public Repository(Connection conn) 
        {
            _connection = conn;
        }

        public IEnumerable<Properties> GetProperties()
        {
            var query = "SELECT * FROM properties";
            using (var connection = _connection.GetConnection())
            {
                var properties = connection.Query<Properties>(query);
                return properties;
            }
        }
    }
}
