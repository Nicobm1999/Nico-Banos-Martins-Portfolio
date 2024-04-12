namespace MyRealState.Models.Repository
{
    public interface IRepository
    {
        public IEnumerable<Property> GetProperties();
        public IEnumerable<Property> GetFilteredProperties(string tipo, string country, string province, string city, int ownerID, string status);
        public Property GetProperty(int? id);
        public void CreateProperty(Property property);
        public void UpdateProperty(Property property);
        public void DeleteProperty(Property property);
        public void ToRent(Property property);
        public void Inactive(Property property);
    }
}
