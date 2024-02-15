namespace Kalaria.Models.Repository
{
    public interface IRepository
    {
       public IEnumerable<Event> GetAllEvents();
       public IEnumerable<Employee> GetAllEmployees();
       public IEnumerable<FacilityImages> GetAllFacilityImages();
       public Event GetEventById(int eventId);
       public void InsertEvent(Event newEvent);
       public void UpdateEvent(Event updatedEvent);
       public void DeleteEvent(int eventId);
    }
}
