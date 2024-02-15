namespace Kalaria.Models
{
    public class RequestHomeAcademy
    {
        public int RequestID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public DateTime RequestDate { get; set; }
        public string Comments { get; set; }
    }
  
}
