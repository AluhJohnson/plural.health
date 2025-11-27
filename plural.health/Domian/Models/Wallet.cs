namespace plural.health.Domian.Models
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Amount { get; set; }
    }
}
