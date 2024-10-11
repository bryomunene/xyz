using Microsoft.EntityFrameworkCore;
using xyz.Models;

namespace xyz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Student> Students { get; set; } = null;

        public DbSet<Payment> Payments { get; set; }
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

            base.OnModelCreating(modelBuilder);
        }

    }
}
