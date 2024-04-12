namespace MyRealState.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Type { get; set; } 
        public string Address { get; set; }
        public double Area { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double RentPrice { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Coordenates { get; set; }
        public DateTime DateListed { get; set; } 
        public DateTime LastUpdated { get; set; } 
        public int UserID { get; set; }
        public int YearBuilt { get; set; }
        public string EnergyEfficiencyRating { get; set; }
        public double DistanceToAmenities { get; set; }
        public int Floor { get; set; }
        public int Condition { get; set; }
        public int NeighborhoodSafety { get; set; }
        public int NumberOfParkingSpaces { get; set; } 
        public int GarageCapacity { get; set; }
        public string PropertyViews { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool HasGarden { get; set; } 
        public bool HasGarage { get; set; }       
        public bool HasSecuritySystem { get; set; }     
        public bool HasStorageRoom { get; set; } 
        public bool HasHeating { get; set; }
        public bool HasPets { get; set; }
        public bool HasFurniture { get; set; }
        public bool HasAppliances { get; set; }
        public bool HasAirConditioning { get; set; } 
        public bool HasElevator { get; set; }
        public bool HasSecurityDoor { get; set; } 
        public bool IsInGatedCommunity { get; set; }      
        public bool HasBalcony { get; set; } 
        public string Description { get; set; }
        public string Surroundings { get; set; } 
    }

}
