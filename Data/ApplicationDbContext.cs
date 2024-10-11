using Microsoft.EntityFrameworkCore;
using xyz.Models;

namespace xyz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Payment> Payments { get; set; } = null!;

        public DbSet<PaymentNotification> PaymentNotifications { get; set; } = null!;

        public List<Payment> Payment { get; set; } = new();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example configuration
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentId)
                .IsUnique();

            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, TransactionId = "trans123", Amount = 100, Status = "Pending" },
                new Payment { Id = 2, TransactionId = "trans456", Amount = 200, Status = "Pending" }
            );

            modelBuilder.Entity<PaymentNotification>().HasKey(p => p.Id);

            // Seed data
            modelBuilder.Entity<PaymentNotification>().HasData(
                new PaymentNotification
                {
                    Id = 1,
                    TransactionId = "txn_001",
                    Amount = 100.00m,
                    Currency = "USD",
                    Status = "Completed",
                    Timestamp = DateTime.UtcNow,
                    CustomerId = "cust_001",
                    PaymentMethod = "Credit Card"
                },
                new PaymentNotification
                {
                    Id = 2,
                    TransactionId = "txn_002",
                    Amount = 200.00m,
                    Currency = "EUR",
                    Status = "Pending",
                    Timestamp = DateTime.UtcNow,
                    CustomerId = "cust_002",
                    PaymentMethod = "PayPal"
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
