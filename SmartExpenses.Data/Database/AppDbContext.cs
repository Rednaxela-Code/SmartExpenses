using Microsoft.EntityFrameworkCore;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
