namespace Kalaria.Models
{
    public class RequestJobTeacher
    {
        public int RequestID { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Experience { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public DateTime RequestDate { get; set; }
        public string Comments { get; set; }
    }

}
