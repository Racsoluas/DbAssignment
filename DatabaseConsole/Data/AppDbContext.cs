using Microsoft.EntityFrameworkCore;
using DatabaseConsole.Models;

namespace DatabaseConsole.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(p => p.TotalPrice)
                      .HasPrecision(18, 2); // 18 totala siffror, varav 2 decimaler
            });

            base.OnModelCreating(modelBuilder);
        }
    }
} 