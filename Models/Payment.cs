using System;
using System.ComponentModel.DataAnnotations;

namespace xyz.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TransactionId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // e.g., "Pending", "Processed", "Failed"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set to current time

        public DateTime? UpdatedAt { get; set; } // Nullable to allow for initial state
    }
}
