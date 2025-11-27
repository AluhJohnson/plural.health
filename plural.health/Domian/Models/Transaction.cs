namespace plural.health.Domian.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public Guid PatientId { get; set; }
        public Guid? WalletId { get; set; }
        public string Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
