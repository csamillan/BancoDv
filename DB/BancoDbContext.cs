using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions options) : base(options) { }

        public BancoDbContext() { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(Client =>
            {
                Client.Property(p => p.IdentityDocument).IsRequired().HasMaxLength(12);
                Client.Property(p => p.Name).IsRequired().HasMaxLength(100);
                Client.Property(p => p.Status).IsRequired();
                Client.Property(p => p.Address).IsRequired().HasMaxLength(150);
                Client.Property(p => p.Password).IsRequired().HasMaxLength(25);
                Client.Property(p => p.Phone).IsRequired().HasMaxLength(15);
                Client.Property(p => p.Age).IsRequired();
                Client.Property(p => p.Gender).IsRequired();
            });

            modelBuilder.Entity<Account>(Account =>
            {
                Account.Property(p => p.Status).IsRequired();
                Account.Property(p => p.AccountType).IsRequired().HasPrecision(12,2);
                Account.Property(p => p.InitialBalance).IsRequired().HasPrecision(12, 2);
                Account.Property(p => p.NumberAccount).IsRequired().HasMaxLength(12);
            });
            modelBuilder.Entity<Transactions>(Transactions =>
            {
                Transactions.Property(p => p.TypeMovement).IsRequired().HasMaxLength(50);
                Transactions.Property(p => p.Sald).IsRequired().HasPrecision(12, 2);
                Transactions.Property(p => p.Date).IsRequired();
                Transactions.Property(p => p.Value).IsRequired().HasPrecision(12, 2);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
