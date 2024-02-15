using System.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Connections;

namespace Kalaria.Models.Repository
{
    public class Repository : IRepository
    {
        private readonly Connection _connection;
        public Repository(Connection connection)
        {
            _connection = connection;
        }

        //----------------------EVENTS----------------------------------------------------------------

        public IEnumerable<Event> GetAllEvents()
        {
            var query = "SELECT * FROM _Events";
            using (var conn = _connection.GetConnection())
            {
                var events = conn.Query<Event>(query);
                return events;
            }
        }

        public Event GetEventById(int EventID)
        {
            using (var conn = _connection.GetConnection())
            {
                string query = "SELECT * FROM _Events WHERE EventID = @EventID";
                return conn.QueryFirstOrDefault<Event>(query, new { EventID = EventID });
            }
        }

        public void InsertEvent(Event newEvent)
        {
            using (var conn = _connection.GetConnection())
            {
                string query = @"INSERT INTO _Events (EventName, EventDescription, EventUrlImagen, EventLocation, EventType, MaxAttendees, RegistrationStartDate, RegistrationEndDate, EventStartDate, EventEndDate)
                             VALUES (@EventName, @EventDescription, @EventUrlImagen, @EventLocation, @EventType, @MaxAttendees, @RegistrationStartDate, @RegistrationEndDate, @EventStartDate, @EventEndDate)";

                conn.Execute(query, newEvent);
            }
        }

        public void UpdateEvent(Event updatedEvent)
        {
            using (var conn = _connection.GetConnection())
            {
                string query = @"UPDATE _Events
                             SET EventName = @EventName, EventDescription = @EventDescription, EventUrlImagen = @EventUrlImagen, EventLocation = @EventLocation, EventType = @EventType,
                                 MaxAttendees = @MaxAttendees, RegistrationStartDate = @RegistrationStartDate, RegistrationEndDate = @RegistrationEndDate, EventStartDate = @EventStartDate, EventEndDate = @EventEndDate
                             WHERE EventID = @EventID";

                conn.Execute(query, updatedEvent);
            }
        }

        public void DeleteEvent(int eventId)
        {
            using (var conn = _connection.GetConnection())
            {
                string query = "DELETE FROM _Events WHERE EventID = @EventID";
                conn.Execute(query, new { EventID = eventId });
            }
        }


        //----------------------EMPLOYEES----------------------------------------------------------------


        public IEnumerable<Employee> GetAllEmployees()
        {
            var query = "SELECT * FROM Employee";
            using (var conn = _connection.GetConnection())
            {
                var e = conn.Query<Employee>(query);
                return e;
            }
        }


        //------------------------FACILITY--IMAGES----------------------------------------------------------------------


        public IEnumerable<FacilityImages> GetAllFacilityImages()
        {
            var query = "SELECT * FROM FacilityImages";
            using (var conn = _connection.GetConnection())
            {
                var e = conn.Query<FacilityImages>(query);
                return e;
            }
        }


    }
}
