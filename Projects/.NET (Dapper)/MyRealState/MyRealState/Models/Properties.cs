namespace MyRealState.Models
{
    public class Properties
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public double Area { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double SellPrice { get; set; }
        public double RentPrice { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Coordenates { get; set; }
        public DateTime DateListed { get; set; } 
        public DateTime LastUpdated { get; set; } 
        public string Description { get; set; } 
        public int OwnerID { get; set; }
    }

}
