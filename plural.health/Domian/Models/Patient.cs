namespace plural.health.Domian.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string PatientCode { get; set; }
        public DateTime DateOfBirt { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNewPatient { get; set; }
        public string ProfileImage { get; set; }
        public string FingerPrint { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
