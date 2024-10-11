namespace xyz.Models
{
    public class PaymentNotification
    {
        public int Id { get; set; }

        public PaymentNotification() { }

        public PaymentNotification(string transactionId, string currency)
        {
            TransactionId = transactionId ?? throw new ArgumentNullException(nameof(transactionId));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string CustomerId { get; set; }
        public string PaymentMethod { get; set; }
    }
}
