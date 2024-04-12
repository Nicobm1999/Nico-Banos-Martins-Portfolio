using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace MyRealState.Models.Repository
{
    public class Repository : IRepository
    {
        private readonly Connection _connection;
        public Repository(Connection conn) 
        {
            _connection = conn;
        }

        public IEnumerable<Property> GetProperties()
        {
            var query = "SELECT * FROM properties";
            using (var connection = _connection.GetConnection())
            {
                var properties = connection.Query<Property>(query);
                return properties;
            }
        }

        public IEnumerable<Property> GetFilteredProperties(string tipo, string country, string province, string city, int ownerID, string status)
        {
            var query = "SELECT * FROM Property WHERE 1=1";

            if (!string.IsNullOrEmpty(tipo))
            {
                query += $" AND Type = '{tipo}'";
            }

            if (!string.IsNullOrEmpty(country))
            {
                query += $" AND Country = '{country}'";
            }

            if (!string.IsNullOrEmpty(city))
            {
                query += $" AND City = '{city}'";
            }

            if (!string.IsNullOrEmpty(province))
            {
                query += $" AND City = '{province}'";
            }

            if (ownerID != 0)
            {
                query += $" AND OwnerID = {ownerID}";
            }

            if (!string.IsNullOrEmpty(status))
            {
                query += $" AND Status = '{status}'";
            }

            using (var connection = _connection.GetConnection())
            {
                var properties = connection.Query<Property>(query);
                return properties;
            }
        }

 


        public Property GetProperty(int? id)
        {
            // Definimos la consulta SQL para seleccionar una propiedad por su ID
            var query = "SELECT * FROM Property WHERE id = @Id";

            // Utilizamos un bloque using para asegurarnos de que la conexión se cierre correctamente
            using (var conn = _connection.GetConnection())
            {
                // Ejecutamos la consulta y especificamos el parámetro @Id con el valor proporcionado
                var property = conn.QueryFirstOrDefault<Property>(query, new { Id = id });

                // Devolvemos la propiedad encontrada (o null si no se encuentra ninguna)
                return property;
            }
        }

        public void CreateProperty(Property property)
        {
            var parameters = new DynamicParameters();

            parameters.Add("Type", property.Type, DbType.String);
            parameters.Add("Address", property.Address, DbType.String);
            parameters.Add("Area", property.Area, DbType.Double);
            parameters.Add("Bedrooms", property.Bedrooms, DbType.Int32);
            parameters.Add("Bathrooms", property.Bathrooms, DbType.Int32);
            parameters.Add("RentPrice", property.RentPrice, DbType.Double);
            parameters.Add("Status", property.Status, DbType.String);
            parameters.Add("Country", property.Country, DbType.String);
            parameters.Add("Province", property.Province, DbType.String); 
            parameters.Add("City", property.City, DbType.String);
            parameters.Add("Coordenates", property.Coordenates, DbType.String);
            parameters.Add("DateListed", property.DateListed, DbType.DateTime);
            parameters.Add("LastUpdated", property.LastUpdated, DbType.DateTime);
            parameters.Add("UserID", property.UserID, DbType.Int32);
            parameters.Add("YearBuilt", property.YearBuilt, DbType.Int32);
            parameters.Add("EnergyEfficiencyRating", property.EnergyEfficiencyRating, DbType.String);
            parameters.Add("DistanceToAmenities", property.DistanceToAmenities, DbType.Double);
            parameters.Add("Floor", property.Floor, DbType.Int32);
            parameters.Add("Condition", property.Condition, DbType.Int32);
            parameters.Add("NeighborhoodSafety", property.NeighborhoodSafety, DbType.Int32);
            parameters.Add("NumberOfParkingSpaces", property.NumberOfParkingSpaces, DbType.Int32);
            parameters.Add("GarageCapacity", property.GarageCapacity, DbType.Int32);
            parameters.Add("PropertyViews", property.PropertyViews, DbType.String);
            parameters.Add("HasSwimmingPool", property.HasSwimmingPool, DbType.Boolean);
            parameters.Add("HasGarden", property.HasGarden, DbType.Boolean);
            parameters.Add("HasGarage", property.HasGarage, DbType.Boolean);
            parameters.Add("HasSecuritySystem", property.HasSecuritySystem, DbType.Boolean);
            parameters.Add("HasStorageRoom", property.HasStorageRoom, DbType.Boolean);
            parameters.Add("HasHeating", property.HasHeating, DbType.Boolean);
            parameters.Add("HasPets", property.HasPets, DbType.Boolean);
            parameters.Add("HasFurniture", property.HasFurniture, DbType.Boolean);
            parameters.Add("HasAppliances", property.HasAppliances, DbType.Boolean);
            parameters.Add("HasAirConditioning", property.HasAirConditioning, DbType.Boolean);
            parameters.Add("HasElevator", property.HasElevator, DbType.Boolean);
            parameters.Add("HasSecurityDoor", property.HasSecurityDoor, DbType.Boolean);
            parameters.Add("IsInGatedCommunity", property.IsInGatedCommunity, DbType.Boolean);
            parameters.Add("HasBalcony", property.HasBalcony, DbType.Boolean);
            parameters.Add("Description", property.Description, DbType.String);
            parameters.Add("Surroundings", property.Surroundings, DbType.String);

            var query = @"
            INSERT INTO Property (Type, Address, Area, Bedrooms, Bathrooms, RentPrice, Status, 
                             Country, Province, City, Coordenates, DateListed, LastUpdated, UserID,
                             YearBuilt, EnergyEfficiencyRating, DistanceToAmenities, Floor, Condition,
                             NeighborhoodSafety, NumberOfParkingSpaces, GarageCapacity, PropertyViews,
                             HasSwimmingPool, HasGarden, HasGarage, HasSecuritySystem, HasStorageRoom,
                             HasHeating, HasPets, HasFurniture, HasAppliances, HasAirConditioning,
                             HasElevator, HasSecurityDoor, IsInGatedCommunity, HasBalcony, Description,
                             Surroundings)
            VALUES (@Type, @Address, @Area, @Bedrooms, @Bathrooms, @RentPrice, @Status, 
                    @Country, @Province, @City, @Coordenates, @DateListed, @LastUpdated, @UserID,
                    @YearBuilt, @EnergyEfficiencyRating, @DistanceToAmenities, @Floor, @Condition,
                    @NeighborhoodSafety, @NumberOfParkingSpaces, @GarageCapacity, @PropertyViews,
                    @HasSwimmingPool, @HasGarden, @HasGarage, @HasSecuritySystem, @HasStorageRoom,
                    @HasHeating, @HasPets, @HasFurniture, @HasAppliances, @HasAirConditioning,
                    @HasElevator, @HasSecurityDoor, @IsInGatedCommunity, @HasBalcony, @Description,
                    @Surroundings);
            ";

            using (var conn = _connection.GetConnection())
            {
                conn.Execute(query, parameters);
            }
        }



        public void UpdateProperty(Property property)
        {
            var parameters = new DynamicParameters();

            parameters.Add("Id", property.Id, DbType.Int32); 
            parameters.Add("Type", property.Type, DbType.String);
            parameters.Add("Address", property.Address, DbType.String);
            parameters.Add("Area", property.Area, DbType.Double);
            parameters.Add("Bedrooms", property.Bedrooms, DbType.Int32);
            parameters.Add("Bathrooms", property.Bathrooms, DbType.Int32);
            parameters.Add("RentPrice", property.RentPrice, DbType.Double);
            parameters.Add("Status", property.Status, DbType.String);
            parameters.Add("Country", property.Country, DbType.String);
            parameters.Add("Province", property.Province, DbType.String);
            parameters.Add("City", property.City, DbType.String);
            parameters.Add("Coordenates", property.Coordenates, DbType.String);
            parameters.Add("DateListed", property.DateListed, DbType.DateTime);
            parameters.Add("LastUpdated", property.LastUpdated, DbType.DateTime);
            parameters.Add("UserID", property.UserID, DbType.Int32);
            parameters.Add("YearBuilt", property.YearBuilt, DbType.Int32);
            parameters.Add("EnergyEfficiencyRating", property.EnergyEfficiencyRating, DbType.String);
            parameters.Add("DistanceToAmenities", property.DistanceToAmenities, DbType.Double);
            parameters.Add("Floor", property.Floor, DbType.Int32);
            parameters.Add("Condition", property.Condition, DbType.String);
            parameters.Add("NeighborhoodSafety", property.NeighborhoodSafety, DbType.Int32);
            parameters.Add("NumberOfParkingSpaces", property.NumberOfParkingSpaces, DbType.Int32);
            parameters.Add("GarageCapacity", property.GarageCapacity, DbType.Int32);
            parameters.Add("PropertyViews", property.PropertyViews, DbType.String);
            parameters.Add("HasSwimmingPool", property.HasSwimmingPool, DbType.Boolean);
            parameters.Add("HasGarden", property.HasGarden, DbType.Boolean);
            parameters.Add("HasGarage", property.HasGarage, DbType.Boolean);
            parameters.Add("HasSecuritySystem", property.HasSecuritySystem, DbType.Boolean);
            parameters.Add("HasStorageRoom", property.HasStorageRoom, DbType.Boolean);
            parameters.Add("HasHeating", property.HasHeating, DbType.Boolean);
            parameters.Add("HasPets", property.HasPets, DbType.Boolean);
            parameters.Add("HasFurniture", property.HasFurniture, DbType.Boolean);
            parameters.Add("HasAppliances", property.HasAppliances, DbType.Boolean);
            parameters.Add("HasAirConditioning", property.HasAirConditioning, DbType.Boolean);
            parameters.Add("HasElevator", property.HasElevator, DbType.Boolean);
            parameters.Add("HasSecurityDoor", property.HasSecurityDoor, DbType.Boolean);
            parameters.Add("IsInGatedCommunity", property.IsInGatedCommunity, DbType.Boolean);
            parameters.Add("HasBalcony", property.HasBalcony, DbType.Boolean);
            parameters.Add("Description", property.Description, DbType.String);
            parameters.Add("Surroundings", property.Surroundings, DbType.String);

            var query = @"
                        UPDATE Property 
                        SET Type = @Type, 
                            Address = @Address, 
                            Area = @Area, 
                            Bedrooms = @Bedrooms, 
                            Bathrooms = @Bathrooms, 
                            RentPrice = @RentPrice, 
                            Status = @Status, 
                            Country = @Country, 
                            Province = @Province, 
                            City = @City, 
                            Coordenates = @Coordenates, 
                            DateListed = @DateListed, 
                            LastUpdated = @LastUpdated, 
                            UserID = @UserID,
                            YearBuilt = @YearBuilt,
                            EnergyEfficiencyRating = @EnergyEfficiencyRating,
                            DistanceToAmenities = @DistanceToAmenities,
                            Floor = @Floor,
                            Condition = @Condition,
                            NeighborhoodSafety = @NeighborhoodSafety,
                            NumberOfParkingSpaces = @NumberOfParkingSpaces,
                            GarageCapacity = @GarageCapacity,
                            PropertyViews = @PropertyViews,
                            HasSwimmingPool = @HasSwimmingPool,
                            HasGarden = @HasGarden,
                            HasGarage = @HasGarage,
                            HasSecuritySystem = @HasSecuritySystem,
                            HasStorageRoom = @HasStorageRoom,
                            HasHeating = @HasHeating,
                            HasPets = @HasPets,
                            HasFurniture = @HasFurniture,
                            HasAppliances = @HasAppliances,
                            HasAirConditioning = @HasAirConditioning,
                            HasElevator = @HasElevator,
                            HasSecurityDoor = @HasSecurityDoor,
                            IsInGatedCommunity = @IsInGatedCommunity,
                            HasBalcony = @HasBalcony,
                            Description = @Description,
                            Surroundings = @Surroundings
                        WHERE Id = @Id;
                        ";

            using (var conn = _connection.GetConnection())
            {
                conn.Execute(query, parameters);
            }
        }



        public void DeleteProperty(Property property)
        {
            // Creamos un objeto DynamicParameters para manejar los parámetros de forma dinámica
            var parameters = new DynamicParameters();

            
            // Agregamos el parámetro del ID de la propiedad a eliminar
            parameters.Add("Id",property.Id, DbType.Int32);

            // Definimos la consulta SQL para eliminar la propiedad por su ID
            var query = "DELETE FROM Property WHERE Id = @Id";

            // Utilizamos Dapper para ejecutar la consulta y pasar los parámetros
            using (var conn = _connection.GetConnection())
            {
                conn.Execute(query, parameters);
            }
        }


        public void Rent(Property property)
        {
            // Creamos un objeto DynamicParameters para manejar los parámetros de forma dinámica
            var parameters = new DynamicParameters();

            // Agregamos los parámetros al objeto DynamicParameters
            parameters.Add("Id", property.Id, DbType.Int32); // Asumiendo que el Id es necesario para identificar la propiedad a actualizar


            // Definimos la consulta SQL para actualizar la propiedad
            var query = @"UPDATE properties SET Status = 'rented' WHERE Id = @Id;";

            // Utilizamos Dapper para ejecutar la consulta y pasar los parámetros
            using (var conn = _connection.GetConnection())
            {

                conn.Execute("DELETE FROM RentalContracts WHERE PropertyID = @PropertyID", new { PropertyID = property.Id });

                conn.Execute(query, parameters);
            }
        }

        public void ToRent(Property property)
        {
            // Creamos un objeto DynamicParameters para manejar los parámetros de forma dinámica
            var parameters = new DynamicParameters();

            // Agregamos los parámetros al objeto DynamicParameters
            parameters.Add("Id", property.Id, DbType.Int32); // Asumiendo que el Id es necesario para identificar la propiedad a actualizar


            // Definimos la consulta SQL para actualizar la propiedad
            var query = @"UPDATE properties SET Status = 'to-rent' WHERE Id = @Id;";

            // Utilizamos Dapper para ejecutar la consulta y pasar los parámetros
            using (var conn = _connection.GetConnection())
            {

                conn.Execute("DELETE FROM RentalContracts WHERE PropertyID = @PropertyID", new { PropertyID = property.Id });

                conn.Execute(query, parameters);
            }
        }


        public void Inactive(Property property)
        {
            // Creamos un objeto DynamicParameters para manejar los parámetros de forma dinámica
            var parameters = new DynamicParameters();

            // Agregamos los parámetros al objeto DynamicParameters
            parameters.Add("Id", property.Id, DbType.Int32); // Asumiendo que el Id es necesario para identificar la propiedad a actualizar


            // Definimos la consulta SQL para actualizar la propiedad
            var query = @"UPDATE properties SET Status = 'inactive' WHERE Id = @Id;";

            // Utilizamos Dapper para ejecutar la consulta y pasar los parámetros
            using (var conn = _connection.GetConnection())
            {

                conn.Execute("DELETE FROM RentalContracts WHERE PropertyID = @PropertyID", new { PropertyID = property.Id });

                conn.Execute(query, parameters);
            }
        }


        

   










    }
}
