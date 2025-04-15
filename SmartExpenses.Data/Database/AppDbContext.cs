using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartExpenses.Shared.Models;
using SmartExpenses.Shared.Models.Identity;

namespace SmartExpenses.Data.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Expense>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
            
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Settings)
                .WithOne(s => s.Account)
                .HasForeignKey<Settings>(s => s.AccountId);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.ApplicationUser)
                .WithMany(u => u.Members)
                .HasForeignKey(m => m.ApplicationUserId)
                .IsRequired(false);

        }
    }
}
