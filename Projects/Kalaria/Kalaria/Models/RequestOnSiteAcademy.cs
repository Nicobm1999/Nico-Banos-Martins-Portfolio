namespace Kalaria.Models
{
    public class RequestOnSiteAcademy
    {
        public int RequestID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string Comments { get; set; }
    }
}
