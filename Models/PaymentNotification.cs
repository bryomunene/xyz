namespace xyz.Models
{
    public class PaymentNotification
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string CustomerId { get; set; }
        public string PaymentMethod { get; set; }
    }
}
