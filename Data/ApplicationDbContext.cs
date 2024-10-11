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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example configuration
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentId)
                .IsUnique();
        }

    }
}
