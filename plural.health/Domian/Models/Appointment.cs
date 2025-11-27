namespace plural.health.Domian.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientCode { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Clinic { get; set; }
        public int WalletBalance { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }
        public string ProfileImage { get; set; }
    }
}
